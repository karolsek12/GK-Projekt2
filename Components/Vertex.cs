using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Projekt2.Components
{
    public class Vertex
    {
        private Point<double> _beforeP;
        private Vector<double> _beforeTangentu;
        private Vector<double> _beforeTangentv;
        private Vector<double> _beforeNormal;

        private Point<double> _afterP;
        private Vector<double> _afterTangentu;
        private Vector<double> _afterTangentv;
        private Vector<double> _afterNormal;

        private double _u;
        private double _v;

        public Vertex(double u, double v, Point<double> P, Vector<double> Tangentu, Vector<double> Tangentv, Vector<double> Normal)
        {
            _u = u;
            _v = v;
            _beforeP = P;
            _beforeTangentu = Tangentu;
            _beforeTangentv = Tangentv;
            _beforeNormal = Normal;
            _afterP = new Point<double>(P);
            _afterTangentu = new Vector<double>(Tangentu);
            _afterTangentv = new Vector<double>(Tangentv);
            _afterNormal = new Vector<double>(Normal);
        }


        public Point<double> AfterP
        {
            get
            {
                return _afterP;
            }
        }

        public Vector<double> AfterTangentu
        {
            get
            {
                return _afterTangentu;
            }
        }

        public Vector<double> AfterTangetnv
        {
            get
            {
                return _afterTangentv;
            }
        }

        public Vector<double> AfterNormal
        {
            get
            {
                return _afterNormal;
            }
        }

        public Point<double> UV
        {
            get
            {
                return new Point<double>(_u, _v, 0);
            }
        }

        public void Rotate(Matrix3<double> rot)
        {
            Vector<double> temp = new Vector<double>(_beforeP);

            temp = rot * temp;

            _afterP = new Point<double>(temp);

            temp = new Vector<double>(_beforeTangentu);

            _afterTangentu = new Vector<double>(temp);

            temp = new Vector<double>(_beforeTangentv);

            _afterTangentv = new Vector<double>(temp);

            temp = new Vector<double>(_beforeNormal);

            _afterNormal = new Vector<double>(temp);
        }
    }
}
