using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private Point<double>[,] _colors;
        private double[,] _zBuffer;

        public TurboBitmapHandler(int width, int height) {
        
            _width = width;
            _height = height;
            _colors = new Point<double>[width,height];
            _zBuffer = new double[width,height];
            
        }

        public void Render(Bitmap bm,Mesh mesh,LightInfo li)
        {

            for (int x = 0; x < _width; x++)
            {
                for(int y = 0; y < _height; y++)
                {
                    _colors[x, y] = new Point<double>(1.0,1.0,1.0);
                    _zBuffer[x, y] = double.MinValue;
                }
            }

            List<Triangle> triangles = mesh.Triangles;

            DiscreteTriangle dt;
            List<Point<int>> pts;
            Vector<double> normal;
            Point<double> pos;
            Point<double> uv;
          
            foreach (Triangle t in triangles)
            {
                dt = new DiscreteTriangle(ToDiscrete(t.Points));

                pts = FillTriangleVertexSort.FillTriangle(dt);

                for(int i = 0; i < pts.Count; i++)
                {
                    t.Interpolate(pts[i], dt);

                    pos = t.InterpolatePos();   

                    if (pos.Z >= _zBuffer[pts[i].X, pts[i].Y])
                    {
                        _zBuffer[pts[i].X, pts[i].Y] = pos.Z;
                        uv = t.InterpolateUV();
                        normal = t.InterpolateNormal();
                        _colors[pts[i].X, pts[i].Y] = Algorithms.LightCalculation.GetColor(pos, uv[0], uv[1], normal, mesh.CI, li);
                    }
                    
                }
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

            unsafe
            {
                byte* start = (byte*)bmData.Scan0;
                byte* curline = start;

                for (int y = 0; y < _height; y++)
                {
                    
                    for (int x = 0; x < _width; x++)
                    {
                        id = x * bytesPerPixel;


                        curline[id] = (byte)(_colors[x,y][0]*255);
                        curline[id + 1] = (byte)(_colors[x, y][1] * 255);
                        curline[id + 2] = (byte)(_colors[x, y][2] * 255);
                    }
                    curline += stride;
                }
            }
            bm.UnlockBits(bmData);
            
        }

        public Point<int>[] ToDiscrete(Point<double>[] real)
        {
            Point<int>[] discrete = new Point<int>[3];


            for(int i = 0; i < 3; i++)
            {
                int x = (int)(_width * 0.5 * (1.0 + real[i].X / Constants.MaxDistance));
                int y = (int)(_height * 0.5 * (1.0 + real[i].Y / Constants.MaxDistance));
                discrete[i] = new Point<int>(x, y, 0);
            }


            return discrete;
        }
    }
}
