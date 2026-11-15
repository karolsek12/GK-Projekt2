using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GK_Projekt2.Components
{
    public struct Matrix3<T> where T : INumber<T>
    {
        private T[,] _values;

        public Matrix3()
        {
            _values = new T[3, 3];

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0;j< 3; j++)
                {
                    _values[i, j] = default!;
                }
            }

        }

        public T this[int id1, int id2]
        {
            get
            {
                return _values[id1, id2];
            }
            set
            {
                _values[id1,id2] = value;
            }

        }

        public static Matrix3<T> operator*(Matrix3<T> m1, Matrix3<T> m2)
        {
            Matrix3<T> result = new Matrix3<T>();

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    for(int k = 0; k < 3; k++)
                    {
                        result[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }

            return result;
        }

    }
}
