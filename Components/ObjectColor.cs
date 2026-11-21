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
        private int _width;
        private int _height;

        public ImageColor(Bitmap image)
        {
            _image = image;
            _width = image.Width;
            _height = image.Height;
        }

        public void Dispose()
        {
            _image.Dispose();
        }

        public Point<double> GetColor(double u, double v)
        {
            int x = (int)(u * _width);
            int y = (int)(v * _height);

            Color c = _image.GetPixel(x, y);

            return new Point<double>(c.R / 255.0, c.G / 255.0, c.B / 255.0);
        }

    }


}
