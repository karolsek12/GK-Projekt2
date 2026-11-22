using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Projekt2.Components
{
    public class NormalInfo: IDisposable
    {
        private Bitmap _image;
        private Vector<double>[,] _map;
        private int _width;
        private int _height;

        public NormalInfo(Bitmap image)
        {
            _image = image;
            _width = image.Width;
            _height = image.Height;
            _map = new Vector<double>[_width, _height];

            ReadImage();
        }

        public void Dispose()
        {
            _image.Dispose();
        }

        public void ReadImage()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    Vector<double> n = new Vector<double>();
                    Color rgb = _image.GetPixel(x, y);

                    n.X = Math.Clamp((rgb.R - 127) / 128.0,-1.0,1.0);
                    n.Y = Math.Clamp((rgb.G - 127) / 128.0, -1.0, 1.0);
                    n.Z = Math.Clamp((rgb.B - 127) / 128.0, 0.0, 1.0);

                    _map[x, y] = n; 
                        
                }
            }
        }

        public Vector<double> GetNormal(double u, double v,Vector<double> tangentu, Vector<double> tangentv, Vector<double> old)
        {
            int x = Math.Clamp((int)(u * _width), 0, _width - 1);
            int y = Math.Clamp((int)(v * _height), 0, _height - 1);

            Vector<double> normal = _map[x, y];

            Matrix3<double> M = new Matrix3<double>();

            for(int i = 0; i < 3; i++)
            {
                M[i, 0] = tangentu[i];
                M[i,1] = tangentv[i];
                M[i, 2] = old[i];
            }

            return M * normal;
        }
    }
}
