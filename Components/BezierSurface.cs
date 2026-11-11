using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Projekt2.Components
{
    public class BezierSurface
    {
        private List<Point<double>> _controlPoints;


        public BezierSurface(List<Point<double>> points)
        {

            _controlPoints = points;



        }

        public List<Triangle<double>> GetTriangles(int division)
        {
            double u = 0;
            double inc = 1.0 / division;
            double[,] Bx = new double[4, division+1];
            Point<double>[,] px = new Point<double>[division+1, division+1];
            Vertex[,] v = new Vertex[division + 1, division + 1];

            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j <= division; j++)
                {
                    Bx[i, j] = Algorithms.Bernstein.BernsteinCalc(u, i);

                    u += inc;
                }
                u = 0;
            }


            for (int i = 0; i <= division; i++)
            {
                for(int j = 0; j <= division; j++)
                {
                    for(int wi = 0; wi < 4; wi++)
                    {
                        for(int wj = 0; wj < 4; wj++)
                        {
                            px[i, j].AddMultiplied(_controlPoints[i * 4 + j], Bx[wi, i] * Bx[wj, j]);
                        }
                    }

                }
            }

        }

    }
}
