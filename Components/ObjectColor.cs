using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Projekt2.Components
{
    public interface IObjectColor:  IDisposable
    {
        public Point<double> GetColor(double u, double v);
    }

    public class PlainColor : IObjectColor
    {
        private Point<double> _color;

        public PlainColor(Point<double> color)
        {
            _color = color;
        }

        public void Dispose()
        {
            return;
        }

        public Point<double> GetColor(double u, double v)
        {
            return _color;
        }

    }

    public class ImageColor : IObjectColor, IDisposable
    {
        private Bitmap _image;
        private Color[,] _map;
        private int _width;
        private int _height;

        public ImageColor(Bitmap image)
        {
            _image = image;
            _width = image.Width;
            _height = image.Height;
            _map = new Color[_width, _height];

            ReadImage();
        }

        public void Dispose()
        {
            _image.Dispose();
        }

        public void ReadImage()
        {
            for(int x= 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _map[x,y] = _image.GetPixel(x, y); ;
                }
            }
        }

        public Point<double> GetColor(double u, double v)
        {
            int x = Math.Clamp((int)(u * _width),0,_width-1);
            int y = Math.Clamp((int)(v * _height),0,_height-1);

            Color c = _map[x, y];

            return new Point<double>(Math.Clamp(c.R / 255.0,0.0,1.0),
                Math.Clamp(c.G / 255.0,0.0,1.0),
                Math.Clamp(c.B / 255.0,0.0,1.0));
        }

    }


}
