using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_Projekt2.Components;

namespace GK_Projekt2.Algorithms
{
    public static class FillTriangleVertexSort
    {

        private static int FastInterpolate(Point<int> p1, Point<int> p2, int y)
        {

            if(p1.Y == p2.Y)
            {
                return p1.X;
            }


            Point<int>[] pts = new Point<int>[2];

            double alpha = (double)(y - p2.Y);

            alpha/= (p1.Y - p2.Y);

            double beta = 1 - alpha;

            int x = (int)(alpha*p1.X + beta*p2.X);

            return x;

        }

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
