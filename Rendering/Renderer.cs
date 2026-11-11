using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Projekt2.Rendering
{
    public class Renderer
    {

        private PictureBox _box;

        private Bitmap[] _bitmap;
        private int _flip = 0;


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

        }

        private Bitmap GetUnusedBitmap()
        {
            Bitmap bm = _bitmap[1 - _flip];

            return bm;
        }

        private Bitmap GetCurrentBitmapClone()
        {
            Bitmap bm = _bitmap[_flip];

            _flip = 1-_flip;
            return (Bitmap)bm.Clone();
        }

        public void Render()
        {
            if(_box.Image != null)
            {
                _box.Image.Dispose();
            }
            _box.Image = GetCurrentBitmapClone();
            _box.Refresh();
              
        }
    }


}
