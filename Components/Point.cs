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

        public T X { get { return _x; }}
        public T Y { get { return _y; }}
        public T Z { get { return _z; }}


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

    }
}
