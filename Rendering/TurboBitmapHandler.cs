using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
        private object[] _locks;

        private bool _fillTriangles;
        private bool _drawMesh;
        private bool _drawPoly;
        private bool _drawBezier;

        public TurboBitmapHandler(int width, int height) {
        
            _width = width;
            _height = height;
            _colors = new Point<double>[width*height];
            _zBuffer = new double[width*height];
            _locks = new object[width*height];

            Array.Fill(_locks, new object());

            _fillTriangles = true;
            _drawMesh = true;
            _drawPoly = true;
            _drawBezier = true;
        }


        public void SetTriangles(bool set)
        {
            _fillTriangles = set;
        }

        public void SetMesh(bool set)
        {
            _drawMesh = set;
        }

        public void SetPoly(bool set)
        {
            _drawPoly = set;
        }

        public void SetBezier(bool set)
        {
            _drawBezier = set;
        }

        private void FillTriangles(Mesh mesh, LightInfo li)
        {
            List<Triangle> triangles = mesh.Triangles;

            Parallel.For(0, triangles.Count, (j) =>

            {
                Triangle t = triangles[j];
                DiscreteTriangle dt = new DiscreteTriangle(ToDiscrete(t.A), ToDiscrete(t.B), ToDiscrete(t.C));
                t.PreCalcFull(dt);

                List<Point<int>> points = FillTriangleVertexSort.GetPoints(dt,_width,_height);

                for (int i = 0; i < points.Count; i++)
                {
                    int y = points[i].Y;
                    int x = points[i].X;

                    t.Interpolate(x, y, dt);

                    int id = y * _width + x;

                    double z = t.InterpolateZ();

                    double u = t.InterpolateU();
                    double v = t.InterpolateV();
                    Vector<double> normal = t.InterpolateNormal();

                    Vector<double> tu = default;
                    Vector<double> tv = default;
                    bool needTangents = mesh.NormalInfo != null || mesh.BumpInfo != null;

                    if (needTangents)
                    {
                        tu = t.InterpolateTangentu();
                        tv = t.InterpolateTangentv();
                    }

                    if (mesh.NormalInfo != null)
                    {
                        normal = mesh.NormalInfo.GetNormal(u, v, tu, tv, normal);
                    }

                    Point<double> col = LightCalculation.GetColor(
                                t.InterpolatePos(),
                                u,
                                v,
                                normal,
                                mesh.CI,
                                li,
                                mesh.BumpInfo,
                                tu,
                                tv);

                    lock (_locks[id])
                    {
                        if (z >= _zBuffer[id])
                        {
                            _zBuffer[id] = z;

                            _colors[id] = col;
                        }
                    }


                }
            });
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

        private void DrawBezier(LightInfo li)
        {
            List<Point<double>> points = BezierCalculation.GetPoints(li.ControlPoints);

            for(int i = 1; i < points.Count; i++)
            {
                Drawline(ToDiscrete(points[i]), ToDiscrete(points[i - 1]), points[i], points[i - 1], new Point<double>(0.0, 0.0, 0.0));
            }

            for (int j = 0; j < li.GetAmount(); j++)
            {
                Point<int> pos = ToDiscrete(li.Pos[j]);
                List<Point<int>> star = new List<Point<int>>();

                star.Add(pos);

                if (pos.X - 1 >= 0)
                {
                    star.Add(new Point<int>(pos.X - 1, pos.Y, 0));
                }
                if (pos.Y - 1 >= 0)
                {
                    star.Add(new Point<int>(pos.X, pos.Y - 1, 0));
                }
                if (pos.X + 1 < _width)
                {
                    star.Add(new Point<int>(pos.X + 1, pos.Y, 0));
                }
                if (pos.Y + 1 < 0)
                {
                    star.Add(new Point<int>(pos.X, pos.Y + 1, 0));
                }
                double z = li.Pos[j].Z;
                for (int i = 0; i < star.Count; i++)
                {

                    int id = star[i].Y * _width + star[i].X;

                    if (z >= _zBuffer[id])
                    {
                        _zBuffer[id] = z;

                        _colors[id] = new Point<double>(1.0, 0, 0);
                    }
                }

            }

        }

        private void Render(Mesh mesh, LightInfo li)
        {
            if (_fillTriangles)
            {
                FillTriangles(mesh, li);
            }

            if (_drawMesh)
            {
                DrawMesh(mesh);
            }

            if (_drawPoly)
            {
                DrawPoly(mesh);
            }

            if (_drawBezier)
            {
                DrawBezier(li);
            }
        }

        public void Render(Bitmap bm,List<Mesh> meshes,LightInfo li)
        {
            Array.Fill(_colors, new Point<double>(0.7, 0.7, 0.7));
            Array.Fill(_zBuffer, double.MinValue);

            foreach (Mesh m in meshes)
            {
                Render(m, li);

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

                        curline[id] = (byte)Math.Clamp((_colors[x + y * _width][2] * 255), 0, 255);
                        curline[id + 1] = (byte)Math.Clamp((_colors[x + y * _width][1] * 255), 0, 255);
                        curline[id + 2] = (byte)Math.Clamp((_colors[x+ y*_width][0]*255),0,255);
                        
                        
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
