using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_Projekt2.Components;

namespace GK_Projekt2.Algorithms
{
    public static class DiscreteTriangleArea
    {
        public static double GetArea(Point<int> a, Point<int> b, Point<int> c)
        {
            double p = 0.0;

            p = a.X*(b.Y-c.Y) + b.X*(c.Y-a.Y) + c.X*(a.Y-b.Y);
            p = p / 2.0;

            if (p < 0)
                return -p;

            return p;
        }

        public static double GetArea(Point<int>[] pts)
        {
            return GetArea(pts[0], pts[1], pts[2]);
        }

        public static double GetArea(Point<int> target, Point<int>[] pts)
        {
            return GetArea(target, pts[0], pts[1]);
        }
    }
}
