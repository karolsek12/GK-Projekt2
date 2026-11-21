using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GK_Projekt2.Components
{
    public struct Point<T> where T : INumber<T>
    {
        private T _x;
        private T _y;
        private T _z;

        public Point()
        {
            _x = default!;
            _y = default!;
            _z = default!;
        }
        public Point(T x, T y, T z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public Point(Point<T> p)
        {
            _x = p._x;
            _y = p._y;
            _z = p._z;

        }

        public Point(Vector<T> v)
        {
            _x = v.X;
            _y = v.Y;
            _z = v.Z;
        }

        public T X { get { return _x; } set { _x = value; } }
        public T Y { get { return _y; } set { _y = value; } }
        public T Z { get { return _z; } set { _z = value; } }


        public void Add(Point<T> p)
        {
            _x += p.X;
            _y += p.Y;
            _z += p.Z;
        }

        public void Mult(T a)
        {
            _x *= a;
            _y*= a;
            _z *= a;
        }

        public void AddMultiplied(Point<T> p, T a)
        {
            _x += p.X * a;
            _y += p.Y * a;
            _z += p.Z * a;
        }

        public T this[int id]
        {
            get
            {
                switch (id)
                {
                    case 0: return _x;
                    case 1: return _y;
                    case 2: return _z;
                }
                throw new ArgumentOutOfRangeException();
            }
            set
            {
                switch (id)
                {
                    case 0: _x = value; break;
                    case 1: _y = value; break;
                    case 2: _z = value; break;
                }
                return;
            }
        }
    }
}
