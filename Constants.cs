using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_Projekt2.Components;

namespace GK_Projekt2
{
    public static class Constants
    {
        public static List<Point<double>> TestControlPoints = [
            new Point<double>(-1,-1,0),
            new Point<double>(-1,-1/3,0),
            new Point<double>(-1,1/3,0),
            new Point<double>(-1,1,0),

            new Point<double>(-1/3,-1,0),
            new Point<double>(-1/3,-1/3,0.5),
            new Point<double>(-1/3,1/3,0.5),
            new Point<double>(-1/3,1,0),

            new Point<double>(1/3,-1,0),
            new Point<double>(1/3,-1/3,0.5),
            new Point<double>(1/3,1/3,0.5),
            new Point<double>(1/3,1,0),

            new Point<double>(1,-1,0),
            new Point<double>(1,-1/3,0),
            new Point<double>(1,1/3,0),
            new Point<double>(1,1,0)


            ];

        public static double MaxDistance = 1.5;
    }
}
