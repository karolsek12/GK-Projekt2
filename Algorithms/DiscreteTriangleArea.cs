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
        public static double GetArea(int ax, int ay, Point<int> b, Point<int> c)
        {
            double p = 0.0;

            p = ax*(b.Y-c.Y) + b.X*(c.Y-ay) + c.X*(ay-b.Y);
            p = p / 2.0;

            if (p < 0)
                return -p;

            return p;
        }

        public static double GetArea(Point<int> a, Point<int> b, Point<int> c)
        {
            return GetArea(a.X, a.Y, b, c);
        }

    }
}
