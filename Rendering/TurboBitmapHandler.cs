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

        private Point<double>[] _colors;
        private double[] _zBuffer;

        public TurboBitmapHandler(int width, int height) {
        
            _width = width;
            _height = height;
            _colors = new Point<double>[width*height];
            _zBuffer = new double[width*height];
            
        }

        public void Render(Bitmap bm,Mesh mesh,LightInfo li)
        {
            Array.Fill(_colors, new Point<double>(1.0, 1.0, 1.0));
            Array.Fill(_zBuffer, double.MinValue);

            foreach (Triangle t in mesh.Triangles)
            {
                DiscreteTriangle dt = new DiscreteTriangle(ToDiscrete(t.A), ToDiscrete(t.B), ToDiscrete(t.C));
                t.PreCalcFull(dt);

                foreach (FillTriangleVertexSort.ScanlineSpan span in
                         FillTriangleVertexSort.GetSpans(dt, _width, _height))
                {
                    int y = span.Y;

                    for (int x = span.X1; x <= span.X2; x++)
                    {
                        t.Interpolate(x, y, dt);

                        int id = y * _width + x;

                        double z = t.InterpolateZ();

                        if(z >= _zBuffer[id])
                        {
                            _zBuffer[id] = z;

                            _colors[id] = LightCalculation.GetColor(
                                t.InterpolatePos(),
                                t.InterpolateU(),
                                t.InterpolateV(),
                                t.InterpolateNormal(),
                                mesh.CI, li);
                        }

                        
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

                        curline[id] = (byte)Math.Clamp((_colors[x+ y*_width][0]*255),0,255);
                        curline[id + 1] = (byte)Math.Clamp((_colors[x + y * _width][1] * 255), 0, 255);
                        curline[id + 2] = (byte)Math.Clamp((_colors[x + y * _width][2] * 255), 0, 255);
                    }
                    curline += stride;
                }
            }
            bm.UnlockBits(bmData);
            
        }

        public Point<int>ToDiscrete(Point<double> real)
        {
            Point<int> discrete = new Point<int>();



                int x = (int)(_width * 0.5 * (1.0 + real.X / Constants.MaxDistance));
                int y = (int)(_height * 0.5 * (1.0 + real.Y / Constants.MaxDistance));
                discrete = new Point<int>(x, y, 0);


            return discrete;
        }
    }
}
