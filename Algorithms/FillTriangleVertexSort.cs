using System;
using System.Collections.Generic;
using GK_Projekt2.Components;

namespace GK_Projekt2.Algorithms
{

    public static class FillTriangleVertexSort
    {
        public readonly struct ScanlineSpan
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

        private sealed class Edge
        {
            public int LastY;      
            public double X;       
            public double Step;    
        }

        public struct Enumerator
        {
            private readonly int _width;
            private readonly int _yEnd;
            private readonly List<Edge>?[] _buckets;
            private readonly List<Edge> _active;
            private readonly List<ScanlineSpan> _pending;

            private int _y;
            private int _pendingIndex;

            public ScanlineSpan Current { get; private set; }

            public Enumerator(IReadOnlyList<Point<int>> vertices, int width, int height)
            {
                _width = width;
                _active = new List<Edge>();
                _pending = new List<ScanlineSpan>();
                _buckets = new List<Edge>?[Math.Max(0, height)];
                _pendingIndex = 0;
                Current = default;

                if (vertices == null || vertices.Count < 3 || width <= 0 || height <= 0)
                {
                    _y = 0;
                    _yEnd = -1;
                    return;
                }

                int minY = int.MaxValue;
                int maxY = int.MinValue;

                for (int i = 0; i < vertices.Count; i++)
                {
                    minY = Math.Min(minY, vertices[i].Y);
                    maxY = Math.Max(maxY, vertices[i].Y);
                }

                _y = Math.Max(0, minY) - 1;
                _yEnd = Math.Min(height - 1, maxY);

                for (int i = 0; i < vertices.Count; i++)
                {
                    AddEdge(vertices[i], vertices[(i + 1) % vertices.Count]);
                }
            }

            public Enumerator(Point<int> a, Point<int> b, Point<int> c, int width, int height)
            {
                _width = width;
                _active = new List<Edge>();
                _pending = new List<ScanlineSpan>();
                _buckets = new List<Edge>?[Math.Max(0, height)];
                _pendingIndex = 0;
                Current = default;

                if (width <= 0 || height <= 0)
                {
                    _y = 0;
                    _yEnd = -1;
                    return;
                }

                int minY = Math.Min(a.Y, Math.Min(b.Y, c.Y));
                int maxY = Math.Max(a.Y, Math.Max(b.Y, c.Y));

                _y = Math.Max(0, minY) - 1;
                _yEnd = Math.Min(height - 1, maxY);

                AddEdge(a, b);
                AddEdge(b, c);
                AddEdge(c, a);
            }

            private void AddEdge(Point<int> from, Point<int> to)
            {
                if (from.Y == to.Y)
                    return; 

                if (from.Y > to.Y)
                    (from, to) = (to, from);

                int firstY = Math.Max(0, from.Y);
                int lastY = Math.Min(_buckets.Length - 1, to.Y - 1);

                if (firstY > lastY)
                    return;

                double step = (double)(to.X - from.X) / (to.Y - from.Y);
                double x = from.X + step * (firstY - from.Y);

                var edge = new Edge
                {
                    LastY = lastY,
                    X = x,
                    Step = step
                };

                (_buckets[firstY] ??= new List<Edge>()).Add(edge);
            }

            public bool MoveNext()
            {
                while (true)
                {
                    if (_pendingIndex < _pending.Count)
                    {
                        Current = _pending[_pendingIndex++];
                        return true;
                    }

                    _y++;
                    if (_y > _yEnd)
                        return false;

                    _pending.Clear();

                    List<Edge>? bucket = _buckets[_y];
                    if (bucket != null)
                    {
                        _active.AddRange(bucket);
                        _buckets[_y] = null;
                    }

                    for (int i = _active.Count - 1; i >= 0; i--)
                    {
                        if (_active[i].LastY < _y)
                            _active.RemoveAt(i);
                    }

                    if (_active.Count >= 2)
                    {
                        _active.Sort(static (e1, e2) => e1.X.CompareTo(e2.X));

                        for (int i = 0; i + 1 < _active.Count; i += 2)
                        {
                            int x1 = (int)Math.Floor(_active[i].X);
                            int x2 = (int)Math.Floor(_active[i + 1].X);

                            if (x1 < 0) x1 = 0;
                            if (x2 >= _width) x2 = _width - 1;
                            if (x1 > x2) continue;

                            _pending.Add(new ScanlineSpan(_y, x1, x2));
                        }
                    }

                    foreach (Edge edge in _active)
                        edge.X += edge.Step;

                    _pendingIndex = 0;
                }
            }

            public Enumerator GetEnumerator() => this;
        }

        public static Enumerator GetSpans(DiscreteTriangle dt, int width, int height)
            => new Enumerator(dt.A, dt.B, dt.C, width, height);
    }
}
