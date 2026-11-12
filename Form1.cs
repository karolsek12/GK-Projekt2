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
            graphicsBox.Paint += GraphicsBox_Paint;
            button1.Click += Button1_Click;
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            if (_renderer != null)
                _renderer.Render();
        }

        private void GraphicsBox_Paint(object? sender, PaintEventArgs e)
        {
            if (_renderer == null)
            {


                _renderer = new Renderer(graphicsBox);
            }

        }

        private void graphicsBox_Click(object sender, EventArgs e)
        {

        }
    }
}
