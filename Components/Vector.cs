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

        public Vector(Point<T> from, Point<T> to)
        {
            _x = to.X - from.X;
            _y = to.Y - from.Y;
            _z = to.Z - from.Z;
        }

        public Vector(Point<T> p)
        {
            _x = p.X;
            _y = p.Y;
            _z = p.Z;
        }

        public T X { get { return _x; } set { _x = value; } }
        public T Y { get { return _y; } set { _y = value; } }
        public T Z { get { return _z; } set { _z = value; } }


        public void Add(Vector<T> p)
        {
            _x += p.X;
            _y += p.Y;
            _z += p.Z;
        }

        public void Mult(T a)
        {
            _x *= a;
            _y *= a;
            _z *= a;
        }

        public void AddMultiplied(Vector<T> p, T a)
        {
            _x += p.X * a;
            _y += p.Y * a;
            _z += p.Z * a;
        }

        public static Vector<T> GetCrossProduct(Vector<T> a, Vector<T> b)
        {

            T x = a.Y * b.Z - a.Z * b.Y;
            T y = a.Z * b.X - a.X * b.Z;
            T z = a.X * b.Y - a.Y * b.X;

            return new Vector<T>(x, y, z);
        }

        public T this[int id]
        {
            get
            {
                switch(id){
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
                    case 0: _x = value;break;
                    case 1: _y = value;break;
                    case 2: _z = value;break;
                }
                return;
            }
        }

        public void MultByMatrix(Matrix3<T> m)
        {
            Vector<T> result = m * this;

            _x = result.X;
            _y = result.Y;
            _z = result.Z;
        }

        public static Vector<T>  operator *(Matrix3<T> m, Vector<T> v){

            Vector<T> result = new Vector<T>();

            for(int i = 0; i < 3; i++)
            {
                result[i] = m[i, 0] * v[0] + m[i, 1] * v[1] + m[i, 2] * v[2];
            }

            return result;
        }

        public static T operator*(Vector<T> v1, Vector<T> v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }



    }

    public static class VectorExtensions
    {
        public static double Length(this Vector<double> v)
        {
            return Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
        }

        public static void Normalise(this ref Vector<double> v)
        {
            double len = v.Length();

            v.Mult(1 / len);

        }
            
    }
}
