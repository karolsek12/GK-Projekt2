using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GK_Projekt2.Components
{
    public struct Rectangle<T> where T : INumber<T>
    {
        private Point<T>[] _points;
        

        public Rectangle(List<Point<T>> points)
        {
            T left, right, bot, top;

            left = points.Min(v => v.X)!;
            right = points.Max(v => v.X)!;
            top = points.Max(v => v.Y)!;
            bot = points.Min(v => v.Y)!;



            _points = [
                new Point<T>(left,top,default!),
                new Point<T>(right,top,default!),
                new Point<T>(right,bot,default!),
                new Point<T>(left,bot,default!)
                ];
        }

    }
}
