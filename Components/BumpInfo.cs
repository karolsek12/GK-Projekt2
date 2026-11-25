using System;
using System.Drawing;

namespace GK_Projekt2.Components
{
    /// <summary>
    /// Height-map based bump mapping (normal perturbation).
    /// Mirrors NormalInfo, but the texture stores height instead of a normal.
    /// </summary>
    public class BumpInfo : IDisposable
    {
        private Bitmap _image;
        private double[,] _heights;
        private int _width;
        private int _mapHeight;
        private double _scale;

        public BumpInfo(Bitmap image) : this(image, 1.0)
        {
        }

        public BumpInfo(Bitmap image, double scale)
        {
            _image = image;
            _width = image.Width;
            _mapHeight = image.Height;
            _heights = new double[_width, _mapHeight];
            _scale = scale;

            ReadImage();
        }

        /// <summary>
        /// Strength of the perturbation. Larger values produce deeper-looking bumps.
        /// </summary>
        public double Scale
        {
            get { return _scale; }
            set { _scale = Math.Max(0.0, value); }
        }

        public void Dispose()
        {
            _image.Dispose();
        }

        public void ReadImage()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    Color rgb = _image.GetPixel(x, y);

                    _heights[x, y] = (0.299 * rgb.R + 0.587 * rgb.G + 0.114 * rgb.B) / 255.0;
                }
            }
        }

        private double Sample(int x, int y)
        {
            x = Math.Clamp(x, 0, _width - 1);
            y = Math.Clamp(y, 0, _mapHeight - 1);

            return _heights[x, y];
        }

        /// <summary>
        /// Perturbs an interpolated surface normal with the height-map formula:
        /// D = h_u * (N x Pv) - h_v * (N x Pu),  N' = normalize(N + scale/|Pu x Pv| * D)
        /// </summary>
        public Vector<double> GetNormal(double u, double v,
            Vector<double> tangentu, Vector<double> tangentv, Vector<double> old)
        {
            int x = Math.Clamp((int)(u * _width), 0, _width - 1);
            int y = Math.Clamp((int)(v * _mapHeight), 0, _mapHeight - 1);

            // Central differences converted from texel steps to derivatives w.r.t. u and v.
            double hu = 0.5 * (Sample(x + 1, y) - Sample(x - 1, y)) * _width;
            double hv = 0.5 * (Sample(x, y + 1) - Sample(x, y - 1)) * _mapHeight;

            Vector<double> n = new Vector<double>(old);
            n.Normalise();

            Vector<double> nCrossPv = Vector<double>.GetCrossProduct(n, tangentv);
            Vector<double> nCrossPu = Vector<double>.GetCrossProduct(n, tangentu);

            Vector<double> d = new Vector<double>(nCrossPv);
            d.Mult(hu);
            d.AddMultiplied(nCrossPu, -hv);

            double lambda = _scale;
            d.Mult(lambda);

            Vector<double> result = new Vector<double>(n);
            result.Add(d);

            result.Normalise();

            return result;
        }
    }
}
