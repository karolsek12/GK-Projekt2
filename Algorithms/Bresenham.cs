using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_Projekt2.Components;

namespace GK_Projekt2.Algorithms
{
    public static class Bresenham
    {
        public static List<Point<int>> GetPoints(Point<int> a, Point<int> b)
        {
            List<Point<int>> points = new List<Point<int>>();

            int x = a.X;
            int y = a.Y;

            long dx = Math.Abs((long)b.X - x);
            long dy = Math.Abs((long)b.Y - y);

            int stepX = x < b.X ? 1 : -1;
            int stepY = y < b.Y ? 1 : -1;

            long err = dx - dy;

            while (true)
            {
                points.Add(new Point<int>(x, y, 0));

                if (x == b.X && y == b.Y)
                    break;

                long doubledErr = 2 * err;

                if (doubledErr > -dy)
                {
                    err -= dy;
                    x += stepX;
                }

                if (doubledErr < dx)
                {
                    err += dx;
                    y += stepY;
                }
            }

            return points;
        }

        public static double InterpolateLineZ(int x,int y,Point<double> p1, Point<double> p2, Point<int> d1, Point<int> d2)
        {
            double lower = d1.Y*d2.X - d1.X*d2.Y;

            if(lower < 10e-9)
            {
                return p1.Z;
            }

            double higher = y * d2.X - x * d2.Y;

            double alpha = higher / lower;

            return alpha * p1.Z + (1 - alpha) * p2.Z;
        }
    }
}
