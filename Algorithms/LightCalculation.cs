using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_Projekt2.Components;

namespace GK_Projekt2.Algorithms
{
    public static class LightCalculation
    {
        public static Point<double> GetColor(Point<double> pos, double u, double v,Vector<double> normal, ColorInfo ci,LightInfo li)
        {

            Point<double> color = new Point<double>();

            Vector<double> l = new Vector<double>(pos, li.Pos);

            Vector<double> V = new Vector<double>(0, 0, 1);

            Vector<double> r = new Vector<double>(normal);

            normal.Normalise();
            l.Normalise();

            r.Mult(2.0*(normal * l));
            r.AddMultiplied(l, -1);
            r.Normalise();
            
            double cos1 = Math.Cos(l * normal);

            double cos2 = Math.Pow(Math.Cos(r*V), ci.M);

            cos1 *= ci.Kd;

            cos2 *= ci.Ks;

            Point<double> meshColor = ci.I0.GetColor(u, v);

            color[0] = cos1 * li.Il[0] * meshColor[0] + cos2 * li.Il[0] * meshColor[0];
            color[1] = cos1 * li.Il[1] * meshColor[1] + cos2 * li.Il[1] * meshColor[1];
            color[2] = cos1 * li.Il[2] * meshColor[2] + cos2 * li.Il[2] * meshColor[2];

            return color;
        }

    }
}
