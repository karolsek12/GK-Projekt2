using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_Projekt2.Algorithms;

namespace GK_Projekt2.Components
{
    public struct Triangle
    {
        private Vertex A;
        private Vertex B;
        private Vertex C;

        public Triangle(Vertex a, Vertex b, Vertex c)
        {
            A = a;
            B = b;
            C = c;
        }

        public Point<double>[] Points
        {
            get
            {
                return [A.AfterP, B.AfterP, C.AfterP];
            }
        }

        public double InterpolateZ(Point<int> target,  DiscreteTriangle dt)
        {
            double full = DiscreteTriangleArea.GetArea(dt.Points);

            double alpha = DiscreteTriangleArea.GetArea(target, dt.Points[1..3]);
            alpha /= full;

            double beta = DiscreteTriangleArea.GetArea(target, dt.Points[0], dt.Points[2]);

            beta /= full;

            double gamma = DiscreteTriangleArea.GetArea(target, dt.Points[0..2]);

            gamma /= full;

            double z = A.AfterP.Z * alpha + B.AfterP.Z * beta + C.AfterP.Z * gamma;

            return z;
        }


    }

    public struct DiscreteTriangle
    {
        private Point<int> A;
        private Point<int> B;
        private Point<int> C;

        public DiscreteTriangle(Point<int>[] points)
        {
            if (points.Length != 3)
                throw new Exception("something horrible happened!!!");

            A = points[0];
            B = points[1];
            C = points[2];

        }

        public Point<int>[] Points
        {
            get
            {
                return [A, B, C];
            }
        }

    }
}
