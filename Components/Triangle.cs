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
        private Vertex _A;
        private Vertex _B;
        private Vertex _C;

        private double _alpha;
        private double _beta;
        private double _gamma;
        private double _coeff;

        public Triangle(Vertex a, Vertex b, Vertex c)
        {
            _A = a;
            _B = b;
            _C = c;
        }

        public Point<double>[] Points
        {
            get
            {
                return [_A.AfterP, _B.AfterP, _C.AfterP];
            }
        }

        public Point<double> A
        {
            get
            {
                return _A.AfterP;
            }
        }

        public Point<double> B
        {
            get
            {
                return _B.AfterP;
            }
        }

        public Point<double> C
        {
            get
            {
                return _C.AfterP;
            }
        }

        public void PreCalcFull(DiscreteTriangle dt)
        {
            _coeff = 1.0/DiscreteTriangleArea.GetArea(dt.A,dt.B,dt.C);
        }

        public void Interpolate(int x, int y, DiscreteTriangle dt)
        {

            double alpha = DiscreteTriangleArea.GetArea(x,y, dt.B,dt.C);
            alpha *= _coeff;

            double beta = DiscreteTriangleArea.GetArea(x,y, dt.A, dt.C);

            beta *= _coeff;

            double gamma = 1.0 - alpha - beta;

            _alpha = alpha;
            _beta = beta;
            _gamma = gamma;

        }

        public double InterpolateZ()
        {
            return _A.AfterP.Z * _alpha + _B.AfterP.Z * _beta + _C.AfterP.Z * _gamma;
        }

        public Point<double> InterpolatePos()
        {

            Point<double> pos = new Point<double>();

            pos.AddMultiplied(_A.AfterP, _alpha);
            pos.AddMultiplied(_B.AfterP, _beta);
            pos.AddMultiplied(_C.AfterP, _gamma);

            return pos;
        }

        public double InterpolateU()
        {
            double u = _A.U*_alpha + _B.U*_beta + _C.U*_gamma;

            return u;
        }

        public double InterpolateV()
        {
            double v = _A.V * _alpha + _B.V * _beta + _C.V * _gamma;

            return v;
        }

        public Vector<double> InterpolateNormal()
        {


            Vector<double> normal = new Vector<double>();

            normal.AddMultiplied(_A.AfterNormal, _alpha);
            normal.AddMultiplied(_B.AfterNormal, _beta);
            normal.AddMultiplied(_C.AfterNormal, _gamma);

            return normal;
        }

        public Vector<double> InterpolateTangentu()
        {
            Vector<double> tangent = new Vector<double>();

            tangent.AddMultiplied(_A.AfterTangentu, _alpha);
            tangent.AddMultiplied(_B.AfterTangentu, _beta);
            tangent.AddMultiplied(_C.AfterTangentu, _gamma);

            return tangent;
        }

        public Vector<double> InterpolateTangentv()
        {
            Vector<double> tangent = new Vector<double>();

            tangent.AddMultiplied(_A.AfterTangetnv, _alpha);
            tangent.AddMultiplied(_B.AfterTangetnv, _beta);
            tangent.AddMultiplied(_C.AfterTangetnv, _gamma);

            return tangent;
        }
        public void RotateVertices(Matrix3<double> rot)
        {
            _A.Rotate(rot);
            _B.Rotate(rot);
            _C.Rotate(rot);
        }
    }

    public struct DiscreteTriangle
    {
        private Point<int> _A;
        private Point<int> _B;
        private Point<int> _C;

        public DiscreteTriangle(Point<int>[] points)
        {
            if (points.Length != 3)
                throw new Exception("something horrible happened!!!");

            _A = points[0];
            _B = points[1];
            _C = points[2];

        }

        public DiscreteTriangle(Point<int> A, Point<int> B, Point<int> C)
        {
            _A = A;
            _B = B;
            _C = C;
        }

        public Point<int>[] Points
        {
            get
            {
                return [_A, _B, _C];
            }
        }

        public Point<int> A
        {
            get
            {
                return _A;
            }
        }

        public Point<int> B
        {
            get
            {
                return _B;
            }
        }

        public Point<int> C
        {
            get
            {
                return _C;
            }
        }

    }
}
