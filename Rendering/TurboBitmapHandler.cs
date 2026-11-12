using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_Projekt2.Algorithms;
using GK_Projekt2.Components;

namespace GK_Projekt2.Rendering
{
    public class TurboBitmapHandler
    {
        private int _width;
        private int _height;
        private Mesh _mesh;

        private byte[,] _colors;
        private double[,] _zBuffer;

        public TurboBitmapHandler(int width, int height,Mesh mesh) {
        
            _width = width;
            _height = height;
            _colors = new byte[width,height];
            _zBuffer = new double[width,height];
            _mesh = mesh;
            
        }

        public void Render(Bitmap bm)
        {
            for (int x = 0; x < _width; x++)
            {
                for(int y = 0; y < _height; y++)
                {
                    _colors[x, y] = 255;
                    _zBuffer[x, y] = double.MinValue;
                }
            }

            List<Triangle> triangles = _mesh.Triangles;

            DiscreteTriangle dt;
            List<Point<int>> pts;
            Random r = new Random();
            byte[] silly = new byte[triangles.Count];
            int pos = 0;
            double[] zs = new double[1];

            r.NextBytes(silly);


            foreach (Triangle t in triangles)
            {
                dt = new DiscreteTriangle(t.Points.Select(v => ToDiscrete(v)).ToArray());

                pts = FillTriangleVertexSort.FillTriangle(dt);
                zs = new double[pts.Count];

                for(int i = 0; i < pts.Count; i++)
                {
                    zs[i] = t.InterpolateZ(pts[i], dt);


                    _colors[pts[i].X, pts[i].Y] = silly[pos];
                    //_colors[pts[i].X, pts[i].Y] = (byte)(255*(zs[i]/0.35));
                }

                pos++;
            }

            

            WriteToBitmap(bm);
        }

        private void WriteToBitmap(Bitmap bm)
        {
            Rectangle rect = new Rectangle(0, 0, _width, _height);
            BitmapData bmData = bm.LockBits(rect, ImageLockMode.ReadWrite, bm.PixelFormat);

            int bytesPerPixel = Image.GetPixelFormatSize(bm.PixelFormat) / 8;
            int stride = bmData.Stride;
            int id;
            double z;

            unsafe
            {
                byte* start = (byte*)bmData.Scan0;
                byte* curline = start;
                byte color;

                for (int y = 0; y < _height; y++)
                {
                    
                    for (int x = 0; x < _width; x++)
                    {
                        id = x * bytesPerPixel;

                        color = _colors[x, y];

                        curline[id] = color;
                        curline[id + 1] = color;
                        curline[id + 2] = color;
                    }
                    curline += stride;
                }
            }
            bm.UnlockBits(bmData);
            
        }

        public Point<int> ToDiscrete(Point<double> d)
        {
            Point<int> p = new Point<int>();

            int x = (int)(_width * 0.5*(1.0 + d.X/Constants.MaxDistance));
            int y = (int)(_height * 0.5*(1.0 + d.Y / Constants.MaxDistance));

            return new Point<int>(x, y, 0);
        }
    }
}
