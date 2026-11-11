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

        public List<Triangle> GetTriangles(int division)
        {
            double u = 0;
            double v = 0;
            double inc = 1.0 / division;
            double[,] Bx = new double[4, division+1];
            double[,] Bxless = new double[4,division+1];
            Point<double>[,] px = new Point<double>[division+1, division+1];
            Vector<double>[,] vu = new Vector<double> [division+1, division+1];
            Vector<double>[,] vv = new Vector<double>[division+1,division+1];
            Vertex[,] vert = new Vertex[division + 1, division + 1];

            List<Triangle> triangles = new List<Triangle>();

            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j <= division; j++)
                {
                    Bx[i, j] = Algorithms.Bernstein.BernsteinCalc(u, i);
                    Bxless[i, j] = Algorithms.Bernstein.BernsteingCalcLess(u, i);

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
                            px[i, j].AddMultiplied(_controlPoints[wi * 4 + wj], Bx[wi, i] * Bx[wj, j]);
                        }
                        for (int wj = 0; wj < 3; wj++)
                        {
                            vv[i, j].AddMultiplied(new Vector<double>(
                                _controlPoints[wi * 4 + wj + 1], _controlPoints[wi * 4 + wj]),
                                Bx[wi, i] * Bxless[wj, j]
                                );

                            vv[i, j].Mult(3.0);

                            vu[i,j].AddMultiplied(new Vector<double>(
                                _controlPoints[(wj+1) * 4 + wi], _controlPoints[wj * 4 + wi]),
                                Bxless[wj, i] * Bx[wi, j]
                                );

                            vu[i, j].Mult(3.0);
                        }

                    }

                    vert[i, j] = new Vertex(
                        u,v,
                        px[i,j],
                        vu[i,j], vv[i,j],
                        Vector<double>.GetCrossProduct(vu[i, j], vv[i, j])
                        );
                    v += inc;
                }
                v = 0;
                u += inc;
            }

            for(int i = 0; i < division; i++)
            {
                for(int j = 0; j < division; j++)
                {
                    Triangle upper, lower;

                    upper = new Triangle(vert[i, j], vert[i + 1, j], vert[i + 1, j + 1]);
                    lower = new Triangle(vert[i, j], vert[i, j + 1], vert[i + 1, j + 1]);


                    triangles.Add(upper);
                    triangles.Add(lower);

                }
            }

            return triangles;
        }

    }
}
