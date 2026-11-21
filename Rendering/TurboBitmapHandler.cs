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

        private bool _fillTriangles;
        private bool _drawMesh;
        private bool _drawPoly;

        public TurboBitmapHandler(int width, int height) {
        
            _width = width;
            _height = height;
            _colors = new Point<double>[width*height];
            _zBuffer = new double[width*height];
            _fillTriangles = true;
            _drawMesh = true;
            _drawPoly = true;
        }

        private void FillTriangles(Mesh mesh, LightInfo li)
        {
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

                        if (z >= _zBuffer[id])
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
        }

        private void Drawline(Point<int> da, Point<int> db, Point<double> a, Point<double> b,Point<double> color)
        {
            List<Point<int>> pts = Bresenham.GetPoints(da, db);
            double z;

            for (int i = 0; i < pts.Count; i++)
            {
                z = Bresenham.InterpolateLineZ(pts[i].X, pts[i].Y, a, b, da, db);

                int id = pts[i].Y * _width + pts[i].X;

                if (z >= _zBuffer[id])
                {
                    _zBuffer[id] = z;

                    _colors[id] = color;
                }
            }
        }

        private void DrawMesh(Mesh mesh)
        {
            Point<double> black = new Point<double>();
            foreach (Triangle t in mesh.Triangles)
            {
                DiscreteTriangle dt = new DiscreteTriangle(ToDiscrete(t.A), ToDiscrete(t.B), ToDiscrete(t.C));
                t.PreCalcFull(dt);

                Drawline(dt.A, dt.B, t.A, t.B,black);
                Drawline(dt.A, dt.C, t.A, t.C, black);
                Drawline(dt.C, dt.B, t.C, t.B, black);
            }
        }

        private void DrawPoly(Mesh mesh)
        {
            List<Point<double>> control = mesh.ControlPointsAfter;
            int n = Constants.MaxControlDimension;
            Point<double> white = new Point<double>(1.0,1.0,1.0);

            for (int i = 0; i < n; i++)
            {
                for(int j = 1; j < n; j++)
                {
                    Point<double> cur = control[i*n+j];
                    Point<double> prev = control[i * n + j-1];
                    Drawline(ToDiscrete(cur), ToDiscrete(prev), cur, prev,white);
                    cur = control[j* n + i];
                    prev = control[(j-1) * n + i];
                    Drawline(ToDiscrete(cur), ToDiscrete(prev), cur, prev,white);
                }
                
            }

        }

        public void Render(Bitmap bm,Mesh mesh,LightInfo li)
        {
            Array.Fill(_colors, new Point<double>(0.7, 0.7, 0.7));
            Array.Fill(_zBuffer, double.MinValue);

            if (_fillTriangles)
            {
                FillTriangles(mesh,li);
            }

            if (_drawMesh)
            {
                DrawMesh(mesh);
            }
        
            if(_drawPoly)
            {
                DrawPoly(mesh);
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
