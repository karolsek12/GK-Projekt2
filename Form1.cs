using GK_Projekt2.Rendering;

namespace GK_Projekt2
{
    public partial class Form1 : Form
    {
        private Renderer? _renderer;


        public Form1()
        {
            InitializeComponent();
            _renderer = null;
            graphicsBox.Paint += GraphicsBox_Paint; ;
        }

        private void GraphicsBox_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.ScaleTransform(1, -1);

            g.TranslateTransform(graphicsBox.Width / 2, -graphicsBox.Height / 2);

            _renderer = new Renderer(g,graphicsBox);  
        }
    }
}
