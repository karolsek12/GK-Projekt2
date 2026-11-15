using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_Projekt2.Algorithms;
using GK_Projekt2.Components;

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

        public Renderer(PictureBox box)
        {
            _box = box;
            _bitmap = new Bitmap[2];
            _bitmap[0] = new Bitmap(box.Width, box.Height);
            _bitmap[1] = new Bitmap(box.Width, box.Height);
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

            _mesh = new Mesh(_bezierSurface.GetTriangles(4));
            _tbh = new TurboBitmapHandler(box.Width, box.Height, _mesh);

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
            _tbh.Render(GetUnusedBitmap());
            Flip();
            _box.Image = GetCurrentBitmap();
            _box.Refresh();
              
        }

        public void SetRotation(double alpha,double beta, double gamma)
        {
            Matrix3<double> change = MatrixCreation.GetRot(alpha, beta, gamma);

            _rotation = change*_rotation;
            _mesh.RotateVertices(_rotation);
        }
    }


}
