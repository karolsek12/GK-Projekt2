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
        private Vector<double> _beforeTangent;
        private Vector<double> _beforeNormal;

        private Point<double> _afterP;
        private Vector<double> _afterTangent;
        private Vector<double> _afterNormal;

        private double _u;
        private double _v;

        public Vertex(double u, double v, Point<double> P, Vector<double> Tangent, Vector<double> Normal)
        {
            _u = u;
            _v = v;
            _beforeP = P;
            _beforeTangent = Tangent;
            _beforeNormal = Normal;
            _afterP = new Point<double>(P);
            _afterTangent = new Vector<double>(Tangent);
            _afterNormal = new Vector<double>(Normal);
        }

    }
}
