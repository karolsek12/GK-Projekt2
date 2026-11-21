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

            

            if(normal * V < 0)
            {
                normal.Mult(-1.0); // druga strona
            }

            normal.Normalise();
            l.Normalise();

            Vector<double> r = new Vector<double>(normal);
            r.Mult(2.0*(normal * l));
            r.AddMultiplied(l, -1);
            r.Normalise();
            
            double cos1 = l * normal;

            double cos2 = Math.Pow(r*V, ci.M);

            cos1 *= ci.Kd;

            cos2 *= ci.Ks;

            Point<double> meshColor = ci.I0.GetColor(u, v);

            color.X = cos1 * li.Il.X * meshColor.X + cos2 * li.Il.X * meshColor.X;
            color.Y = cos1 * li.Il.Y * meshColor.Y + cos2 * li.Il.Y * meshColor.Y;
            color.Z = cos1 * li.Il.Z * meshColor.Z + cos2 * li.Il.Z * meshColor.Z;

            return color;
        }

    }
}
