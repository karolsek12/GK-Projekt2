using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_Projekt2.Components;

namespace GK_Projekt2.Algorithms
{
    public static class MouseToRotation
    {

        public static double SmallestChange = Constants.SmallestMouseChange;

        public static double MaxAngle = Constants.MaxAngleChange;
        public static bool GetRotation(Point from, Point to, out double[] angles)
        {
            Point<double> p1 = ToMyPoint(from);
            Point<double> p2 = ToMyPoint(to);

            Vector<double> v = new Vector<double>(p2, p1);

            double len = v.Length();

            angles = [];

            if (len < SmallestChange)
            {
                return false;
            }

            RotateBy90(ref v);

            double alpha = MaxAngle * v.X;
            double beta = MaxAngle * v.Y;
            double gamma = MaxAngle * v.Z;

            angles = [alpha, beta, gamma];

            return true;

        }

        public static Point<double> ToMyPoint(Point p)
        {
            return new Point<double>(-p.X, p.Y, 0);
        }

        public static void RotateBy90(ref Vector<double> v)
        {
            double tempx = v[0];
            v[0] = v[1];
            v[1] = tempx;
        }
    }
}
