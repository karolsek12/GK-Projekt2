using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_Projekt2.Components;

namespace GK_Projekt2.Algorithms
{
    public static class BezierCalculation
    {
        public static Point<double> GetPos(Point<double>[] control,double t)
        {
            int n = control.Length - 1;
            return Casteljau(control,t,n);
        }


        private static Point<double> Casteljau(Point<double>[] control,double t,int upper, int lower = 0)
        {
            if(upper == 0)
            {
                return control[lower];
            }

            Point<double> first = Casteljau(control, t, upper - 1, lower);
            first.Mult(1 - t);

            Point<double> second = Casteljau(control, t, upper - 1, lower + 1);
            second.Mult(t);

            first.Add(second);

            return first;

        }

        public static List<Point<double>> GetPoints(Point<double>[] control)
        {
            List<Point<double>> points = new List<Point<double>>();

            double step = Constants.BezierStep;

            int steps = (int)Math.Ceiling(1.0 / step);

            for (int i = 0; i <= steps; i++)
            {
                double t = i * step;
                if (t > 1.0)
                    t = 1.0;

                points.Add(GetPos(control, t));

                if (t >= 1.0)
                    break;
            }

            return points;
        }
    }
}
