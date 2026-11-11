using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GK_Projekt2.Components
{
    public struct Vector<T> where T : INumber<T>
    {

        private T _x;
        private T _y;
        private T _z;
        public Vector(T x, T y, T z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public Vector(Vector<T> v)
        {
            _x = v._x;
            _y = v._y;
            _z = v._z;
        }
    }
}
