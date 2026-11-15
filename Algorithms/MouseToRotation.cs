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
        public static double Sensivity = Constants.MouseSensivity;

        public static double SmallestChange = Constants.SmallestMouseChange;

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

            

            return false;

        }

        public static Point<double> ToMyPoint(Point p)
        {
            return new Point<double>(p.X, p.Y, p.Y);
        }
    }
}
