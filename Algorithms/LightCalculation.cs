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
        public static Point<double> GetColor(Point<double> pos, double u, double v, Vector<double> normal,
            ColorInfo ci, LightInfo li,
            BumpInfo? bumpInfo = null, Vector<double> tangentu = default, Vector<double> tangentv = default)
        {
            Point<double> result = new Point<double>();

            Vector<double> n = new Vector<double>(normal);

            if (bumpInfo != null)
            {
                n = bumpInfo.GetNormal(u, v, tangentu, tangentv, n);
            }

            for (int i = 0; i < li.GetAmount(); i++)
            {
                Point<double> color = new Point<double>();
                Vector<double> l = new Vector<double>(pos, li.Pos[i]);

                if (li.IsDirected())
                {
                    l = new Vector<double>(0, 0, 1);
                }

                Vector<double> V = new Vector<double>(0, 0, 1);

                if (n * V < 0)
                {
                    n.Mult(-1.0); // druga strona
                }

                n.Normalise();
                l.Normalise();

                Vector<double> r = new Vector<double>(n);
                r.Mult(2.0 * (n * l));
                r.AddMultiplied(l, -1);
                r.Normalise();

                double cos1 = l * n;

                double cos2 = Math.Pow(r * V, ci.M);

                cos1 *= ci.Kd;

                cos2 *= ci.Ks;

                Point<double> meshColor = ci.I0.GetColor(u, v);

                color.X = cos1 * li.Il.X * meshColor.X + cos2 * li.Il.X * meshColor.X;
                color.Y = cos1 * li.Il.Y * meshColor.Y + cos2 * li.Il.Y * meshColor.Y;
                color.Z = cos1 * li.Il.Z * meshColor.Z + cos2 * li.Il.Z * meshColor.Z;

                if (li.IsReflectors())
                {
                    Vector<double> toOrigin = new Vector<double>(li.Pos[i], new Point<double>(0, 0, 0));

                    toOrigin.Normalise();

                    double cos = l * n;

                    cos = Math.Pow(cos, li.GetM());

                    color.Mult(cos);
                }

                result.Add(color);
            }

            if (result.X > 1.0)
            {
                result.X = 1.0;
            }

            if (result.Y > 1.0)
            {
                result.Y = 1.0;
            }

            if (result.Z > 1.0)
            {
                result.Z = 1.0;
            }

            return result;
        }
    }
}
