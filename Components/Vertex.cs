using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Projekt2.Components
{
    public struct Vertex
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

    }
}
