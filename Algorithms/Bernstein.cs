using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Projekt2.Algorithms
{
    public static class Bernstein
    {

        private static double Binomial(int i)
        {
            if (i == 0|| i == 3)
                return 1.0;

            return 3.0;
        }

        public static double BernsteinCalc(double x,int i)
        {
            double coeff = Binomial(i);
            double xi, mxi;

            xi = 1.0;
            mxi = 1.0;

            for (int j = 0; j < i; j++)
            {
                xi *= x;
            }
            for(int j = 0;j < 3 - i; j++)
            {
                mxi *= (1 - x);
            }

            return coeff * xi * mxi;
        }
    }
}
