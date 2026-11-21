using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_Projekt2.Algorithms;

namespace GK_Projekt2.Components
{
    public class Triangle
    {
        private Vertex A;
        private Vertex B;
        private Vertex C;

        private double _alpha;
        private double _beta;
        private double _gamma;

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



        public void Interpolate(Point<int> target, DiscreteTriangle dt)
        {
            double full = DiscreteTriangleArea.GetArea(dt.Points);

            double alpha = DiscreteTriangleArea.GetArea(target, dt.Points[1..3]);
            alpha /= full;

            double beta = DiscreteTriangleArea.GetArea(target, dt.Points[0], dt.Points[2]);

            beta /= full;

            double gamma = DiscreteTriangleArea.GetArea(target, dt.Points[0..2]);

            gamma /= full;

            _alpha = alpha;
            _beta = beta;
            _gamma = gamma;

        }

        public Point<double> InterpolatePos()
        {

            Point<double> pos = new Point<double>();

            pos.AddMultiplied(A.AfterP, _alpha);
            pos.AddMultiplied(B.AfterP, _beta);
            pos.AddMultiplied(C.AfterP, _gamma);

            return pos;
        }

        public Point<double> InterpolateUV()
        {
            Point<double> uv = new Point<double>();

            uv.AddMultiplied(A.UV, _alpha);
            uv.AddMultiplied(B.UV, _beta);
            uv.AddMultiplied(C.UV, _gamma);

            return uv;
        }

        public Vector<double> InterpolateNormal()
        {


            Vector<double> normal = new Vector<double>();

            normal.AddMultiplied(A.AfterNormal, _alpha);
            normal.AddMultiplied(B.AfterNormal, _beta);
            normal.AddMultiplied(C.AfterNormal, _gamma);

            return normal;
        }

        public void RotateVertices(Matrix3<double> rot)
        {
            A.Rotate(rot);
            B.Rotate(rot);
            C.Rotate(rot);
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
