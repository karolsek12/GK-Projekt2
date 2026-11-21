using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_Projekt2.Components;

namespace GK_Projekt2.Algorithms
{
    public static class FillTriangleVertexSort
    {
        public struct ScanlineSpan
        {
            public readonly int Y;
            public readonly int X1;
            public readonly int X2;

            public ScanlineSpan(int y, int x1, int x2)
            {
                Y = y;
                X1 = x1;
                X2 = x2;
            }
        }

        public struct Enumerator
        {
            private readonly Point<int> _p0, _p1, _p2;
            private readonly int _width, _height;
            private readonly int _ymin, _ymax, _ymid;
            private int _y;

            public Enumerator(DiscreteTriangle dt, int width, int height)
            {
                Point<int> p0 = dt.A;
                Point<int> p1 = dt.B;
                Point<int> p2 = dt.C;

                if (p0.Y > p1.Y) (p0, p1) = (p1, p0);
                if (p1.Y > p2.Y) (p1, p2) = (p2, p1);
                if (p0.Y > p1.Y) (p0, p1) = (p1, p0);

                _p0 = p0;
                _p1 = p1;
                _p2 = p2;
                _width = width;
                _height = height;

                _ymid = p1.Y;

                _ymin = Math.Max(0, p0.Y);
                _ymax = Math.Min(height - 1, p2.Y);

                _y = _ymin - 1;
                Current = default;
            }

            public ScanlineSpan Current { get; set; }

            public bool MoveNext()
            {
                while (++_y <= _ymax)
                {
                    int x1, x2;

                    if (_y <= _ymid)
                    {
                        x1 = FastInterpolate(_p1, _p0, _y);
                        x2 = FastInterpolate(_p2, _p0, _y);
                    }
                    else
                    {
                        x1 = FastInterpolate(_p1, _p2, _y);
                        x2 = FastInterpolate(_p2, _p0, _y);
                    }

                    if (x1 > x2) (x1, x2) = (x2, x1);

                    x1 = Math.Max(0, x1);
                    x2 = Math.Min(_width - 1, x2);

                    if (x1 > x2) continue; 

                    Current = new ScanlineSpan(_y, x1, x2);
                    return true;
                }

                return false;
            }

            public Enumerator GetEnumerator() => this;
        }

        public static Enumerator GetSpans(DiscreteTriangle dt, int width, int height)
            => new Enumerator(dt, width, height);

        private static int FastInterpolate(Point<int> p1, Point<int> p2, int y)
        {
            if (p1.Y == p2.Y) return p1.X;

            double alpha = (double)(y - p2.Y) / (p1.Y - p2.Y);
            return (int)(alpha * p1.X + (1.0 - alpha) * p2.X);
        }
    }
}