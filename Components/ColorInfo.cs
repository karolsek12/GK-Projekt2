using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Projekt2.Components
{
    public class ColorInfo
    {
        private double _kd;
        private double _ks;
        private IObjectColor _i0;
        private int _m;

        public ColorInfo(double kd,double ks, int m, Point<double> color) {
        
            _kd = kd;
            _ks = ks;
            _m = m;
            _i0 = new PlainColor(color);
        
        }

        public ColorInfo(double kd, double ks, int m, Bitmap image)
        {
            _kd = kd;
            _ks = ks;
            _m = m;
            _i0 = new ImageColor(image);
        }

        public double Kd
        {
            set
            {
                _kd = value;
            }
            get
            {
                return _kd;
            }
        }

        public double Ks
        {
            set
            {
                _ks = value;
            }
            get
            {
                return _ks;
            }
        }

        public int M
        {
            set
            {
                _m = value;
            }
            get
            {
                return _m;
            }
        }

        public IObjectColor I0
        {
            get
            {
                return _i0;
            }
        }

        public void SetPlainColor(Point<double> color)
        {
            _i0.Dispose();

            _i0 = new PlainColor(color);
        }

        public void SetImageColor(Bitmap image)
        {
            _i0.Dispose();

            _i0 = new ImageColor(image);
        }

    }
}
