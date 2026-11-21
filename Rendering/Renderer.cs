using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GK_Projekt2.Algorithms;
using GK_Projekt2.Components;
using System.Timers;
using System.Diagnostics;

namespace GK_Projekt2.Rendering
{
    public class Renderer
    {

        private PictureBox _box;

        private Bitmap[] _bitmap;
        private int _flip = 0;

        private BezierSurface _bezierSurface;
        private Mesh _mesh;
        private TurboBitmapHandler _tbh;
        private Matrix3<double> _rotation;
        private LightInfo _li;
        private double _t;

        public Renderer(PictureBox box)
        {
            _box = box;
            _bitmap = new Bitmap[2];
            _bitmap[0] = new Bitmap((int)(box.Width/1.5), (int)(box.Height/1.5));
            _bitmap[1] = new Bitmap((int)(box.Width / 1.5), (int)(box.Height / 1.5));
            _rotation = MatrixCreation.GetRot(0,0,0);

            using (Graphics g = Graphics.FromImage(_bitmap[0]))
            {
                g.Clear(Color.White);
            }

            using (Graphics g = Graphics.FromImage(_bitmap[1]))
            {
                g.Clear(Color.White);
            }

            _bezierSurface = new BezierSurface(Constants.TestControlPoints);

            _mesh = new Mesh(_bezierSurface.GetTriangles(20),
                new ColorInfo(0.5, 0.5, 1, new Point<double>(1.0, 1.0, 1.0))
                );
            _tbh = new TurboBitmapHandler(_bitmap[0].Width, _bitmap[0].Height);

            _li = new LightInfo(new Point<double>(1.0, 1.0, 1.0), Constants.TestLightControlPoints.ToArray());
            _t = 0;


        }

        private Bitmap GetUnusedBitmap()
        {
            Bitmap bm = _bitmap[1 - _flip];

            return bm;
        }

        private Bitmap GetCurrentBitmap()
        {
            Bitmap bm = _bitmap[_flip];

            return bm;
        }

        private void Flip()
        {
            _flip = 1 - _flip;
        }

        public void Render()
        {
            _t += Constants.OneTick;

            while (_t >= Constants.CycleTime)
            {
                _t -= Constants.CycleTime;
            }

            _li.SetPos(_t / Constants.CycleTime);


            _tbh.Render(GetUnusedBitmap(),_mesh,_li);
            Flip();
            _box.Image = GetCurrentBitmap();
            _box.Refresh();
        }

        public void SetRotation(double alpha,double beta, double gamma)
        {
            Stopwatch s = new Stopwatch();
            Matrix3<double> change = MatrixCreation.GetRot(alpha, beta, gamma);

            _rotation = change*_rotation;
            _mesh.RotateVertices(_rotation);
        }

    }


}
