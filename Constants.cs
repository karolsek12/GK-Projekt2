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
            new Point<double>(-1,-1.0/3,0),
            new Point<double>(-1,1.0/3,0),
            new Point<double>(-1,1,0),

            new Point<double>(-1.0/3,-1,0),
            new Point<double>(-1.0/3,-1.0/3,0.5),
            new Point<double>(-1.0/3,1.0/3,0.5),
            new Point<double>(-1.0/3,1,0),

            new Point<double>(1.0/3,-1,0),
            new Point<double>(1.0/3,-1.0/3,0.5),
            new Point<double>(1.0/3,1.0/3,0.5),
            new Point<double>(1.0/3,1,0),

            new Point<double>(1,-1,0),
            new Point<double>(1,-1.0/3,0),
            new Point<double>(1,1.0/3,0),
            new Point<double>(1,1,0)


            ];

        public static int MaxControlDimension = 4;

        public static List<Point<double>> TestLightControlPoints = [

            new Point<double>(-0.5,0,1),
            new Point<double>(0,-0.5,1),
            new Point<double>(0.5,0,1),
            new Point<double>(0,0.5,1),
            new Point<double>(-0.5,0,1),

            ];


        public static double MaxDistance = 1.5;

        public static double SmallestMouseChange = 10.0;

        public static double MaxAngleChange = Math.PI / 1000;

        public static int Cooldown = 40;

        public static double CycleTime = 10.0;

        public static double StretchRatio = 1.5;
    }
}
