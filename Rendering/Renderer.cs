using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Projekt2.Rendering
{
    public class Renderer
    {

        private Graphics _graphics;
        private PictureBox _box;

        private Bitmap _current;
        private Bitmap _unused;


        public Renderer(Graphics graphics, PictureBox box)
        {
            _graphics = graphics;
            _box = box;
            _current = new Bitmap(box.Width, box.Height);
            _unused = new Bitmap(box.Width, box.Height);


            Render();
        }


        public void SwapBuffers()
        {
            (_current, _unused) = (_unused, _current);
        }

        public void Render()
        {
             SwapBuffers();
            _box.Image = _current;
            _box.Refresh();
        }
    }


}
