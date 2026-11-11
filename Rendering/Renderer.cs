using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Renderer(PictureBox box)
        {
            _box = box;
            _bitmap = new Bitmap[2];
            _bitmap[0] = new Bitmap(box.Width, box.Height);
            _bitmap[1] = new Bitmap(box.Width, box.Height);

            for (int Xcount = 0; Xcount < _bitmap[0].Width/2; Xcount++)
            {
                for (int Ycount = 0; Ycount < _bitmap[0].Height/3; Ycount++)
                {
                    _bitmap[0].SetPixel(Xcount, Ycount, Color.Black);
                }
            }

            for (int Xcount = 0; Xcount < _bitmap[1].Width / 2; Xcount++)
            {
                for (int Ycount = 0; Ycount < _bitmap[1].Height / 3; Ycount++)
                {
                    _bitmap[1].SetPixel(Xcount, Ycount, Color.Pink);
                }
            }

            _bezierSurface = new BezierSurface(Constants.TestControlPoints);

            _mesh = new Mesh(_bezierSurface.GetTriangles(2));
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
    }


}
