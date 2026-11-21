using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Projekt2.Components
{
    public class LightInfo
    {
        private Point<double> _il;
        private Point<double> _pos;
        private Point<double>[] _controlPoints;

        public LightInfo(Point<double> il, Point<double>[] controlPoints) 
        {
            _il = il;
            _controlPoints = controlPoints;
            _pos = new Point<double>();
        }


        public Point<double> Pos
        {
            get
            {
                return _pos;
            }
        }

        public Point<double> Il
        {
            get
            {
                return _il;
            }
        }

        public void SetPos(double t)
        {
            _pos = Algorithms.BezierCalculation.GetPos(_controlPoints, t);
        }

    }
}
