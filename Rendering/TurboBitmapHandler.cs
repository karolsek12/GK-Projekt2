using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_Projekt2.Components;

namespace GK_Projekt2.Rendering
{
    public class TurboBitmapHandler
    {
        private int _width;
        private int _height;
        private Mesh _mesh;

        private bool[,] _colors;
        private double[,] _zBuffer;

        public TurboBitmapHandler(int width, int height,Mesh mesh) {
        
            _width = width;
            _height = height;
            _colors = new bool[width,height];
            _zBuffer = new double[width,height];
            _mesh = mesh;
            
        }

        public void Render(Bitmap bm)
        {
            for (int x = 0; x < _width; x++)
            {
                for(int y = 0; y < _height; y++)
                {
                    _colors[x, y] = false;
                    _zBuffer[x, y] = double.MinValue;
                }
            }

            List<Triangle> triangles = _mesh.Triangles;

        }

        public Point<int> ToDiscrete(Point<double> d)
        {
            Point<int> p = new Point<int>();

            int x = (int)(_width * 0.5*(1.0 + d.X/Constants.MaxDistance));
            int y = (int)(_height * 0.5*(1.0 + d.Y / Constants.MaxDistance));

            return new Point<int>(x, y, 0);
        }
    }
}
