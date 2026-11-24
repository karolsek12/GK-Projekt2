using System;
using System.Collections.Generic;
using GK_Projekt2.Components;

namespace GK_Projekt2.Algorithms
{

    public static class FillTriangleVertexSort
    {
        private sealed class Edge
        {
            public int LastY;
            public double X;
            public double Step;
        }

        public static List<Point<int>> GetPoints(List<Point<int>> vertices, int width, int height)
        {
            List<Point<int>> result = new List<Point<int>>();

            if (vertices == null || vertices.Count < 3 || width <= 0 || height <= 0)
                return result;

            List<Edge>?[] buckets = new List<Edge>?[height];

            int minY = int.MaxValue;
            int maxY = int.MinValue;

            for (int i = 0; i < vertices.Count; i++)
            {
                minY = Math.Min(minY, vertices[i].Y);
                maxY = Math.Max(maxY, vertices[i].Y);
            }

            int firstScanline = Math.Max(0, minY);
            int lastScanline = Math.Min(height - 1, maxY);

            for (int i = 0; i < vertices.Count; i++)
            {
                AddEdge(buckets, vertices[i], vertices[(i + 1) % vertices.Count], height);
            }

            List<Edge> active = new List<Edge>();

            for (int y = firstScanline; y <= lastScanline; y++)
            {
                List<Edge>? bucket = buckets[y];
                if (bucket != null)
                {
                    active.AddRange(bucket);
                    buckets[y] = null;
                }

                for (int i = active.Count - 1; i >= 0; i--)
                {
                    if (active[i].LastY < y)
                        active.RemoveAt(i);
                }

                if (active.Count >= 2)
                {
                    active.Sort(static (e1, e2) => e1.X.CompareTo(e2.X));

                    for (int i = 0; i + 1 < active.Count; i += 2)
                    {
                        int x1 = (int)Math.Floor(active[i].X);
                        int x2 = (int)Math.Floor(active[i + 1].X);

                        if (x1 < 0) x1 = 0;
                        if (x2 >= width) x2 = width - 1;

                        for (int x = x1; x <= x2; x++)
                        {
                            result.Add(new Point<int>(x, y, 0));
                        }
                    }
                }

                foreach (Edge edge in active)
                    edge.X += edge.Step;
            }

            return result;
        }


        public static List<Point<int>> GetPoints(DiscreteTriangle dt, int width, int height){
            return GetPoints([dt.A,dt.B,dt.C], width, height);
        }

        private static void AddEdge(List<Edge>?[] buckets, Point<int> from, Point<int> to, int height)
        {
            if (from.Y == to.Y)
                return;

            if (from.Y > to.Y)
                (from, to) = (to, from);

            int firstY = Math.Max(0, from.Y);
            int lastY = Math.Min(height - 1, to.Y - 1);

            if (firstY > lastY)
                return;

            double step = (double)(to.X - from.X) / (to.Y - from.Y);
            double x = from.X + step * (firstY - from.Y);

            (buckets[firstY] ??= new List<Edge>()).Add(new Edge
            {
                LastY = lastY,
                X = x,
                Step = step
            });
        }

        [Obsolete]
        private static int FastInterpolate(Point<int> p1, Point<int> p2, int y)
        {

            if (p1.Y == p2.Y)
            {
                return p1.X;
            }


            Point<int>[] pts = new Point<int>[2];

            double alpha = (double)(y - p2.Y);

            alpha /= (p1.Y - p2.Y);

            double beta = 1 - alpha;

            int x = (int)(alpha * p1.X + beta * p2.X);

            return x;

        }

        [Obsolete] // implementation assuming that the polygon is a triangle, probably faster
        public static List<Point<int>> FillTriangle(DiscreteTriangle dt)
        {
            Point<int>[] pts = dt.Points;
            List<Point<int>> fill = new List<Point<int>>();

            Array.Sort(pts, (p1, p2) => p1.Y.CompareTo(p2.Y));

            int ymin = pts[0].Y;
            int ymax = pts[2].Y;
            int ymid = pts[1].Y;
            int x1 = 0;
            int x2 = 0;


            for (int y = ymin; y <= ymax; y++)
            {
                if (y <= ymid)
                {
                    (x1, x2) = (FastInterpolate(pts[1], pts[0], y), FastInterpolate(pts[2], pts[0], y));
                }
                else
                {
                    (x1, x2) = (FastInterpolate(pts[1], pts[2], y), FastInterpolate(pts[2], pts[0], y));
                }

                if (x1 > x2)
                {
                    (x1, x2) = (x2, x1);
                }


                for (int x = x1; x <= x2; x++)
                {
                    fill.Add(new Point<int>(x, y, 0));
                }

            }

            return fill;
        }
    }
}
