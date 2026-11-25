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
        private Point<double>[] _pos;
        private Point<double>[] _controlPoints;
        private int _amount;
        private bool _directed;
        private bool _reflectors;
        private int _m;
        public LightInfo(Point<double> il, Point<double>[] controlPoints) 
        {
            _il = il;
            _controlPoints = controlPoints;
            _amount = 1;
            _pos = new Point<double>[_amount];
            _directed = false;
            _m = 1;
            
        }


        public Point<double>[] Pos
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

        public Point<double>[] ControlPoints
        {
            get
            {
                return _controlPoints;
            }
        }

        public bool IsDirected()
        {
            return _directed;
        }

        public bool IsReflectors()
        {
            return _reflectors;
        }

        public void SetPos(double t)
        {
            for (int i = 0; i < _amount; i++)
            {
                _pos[i] = Algorithms.BezierCalculation.GetPos(_controlPoints, t);
                t += 1.0 / _amount;

                if(t > 1.0)
                {
                    t = t - 1.0;
                }
            }

            
        }

        public void SetZ(double z)
        {
            for (int i = 0; i < _controlPoints.Length; i++)
            {
                _controlPoints[i].Z = z;
            }
        }

        public void SetColor(Point<double> color)
        {
            _il = color;
        }

        public int GetAmount()
        {
            return _amount;
        }

        public void SetAmount(int amount)
        {
            _amount = amount;
            _pos = new Point<double>[amount];
        }

        public void SetDirected(bool val)
        {
            _directed = val;
        }

        public void SetReflectors(bool val)
        {
            _reflectors = val;
        }

        public void SetM(int val)
        {
            _m = val;
        }

        public int GetM()
        {
            return _m;
        }
    }
}
