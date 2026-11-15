using GK_Projekt2.Rendering;


namespace GK_Projekt2
{
    public partial class Form1 : Form
    {
        private Renderer? _renderer;
        private bool _held = false;
        private Point? _lastHit;


        public Form1()
        {
            InitializeComponent();
            _lastHit = null;
            _renderer = null;
            graphicsBox.Paint += GraphicsBox_Paint;
            button1.Click += Button1_Click;
            graphicsBox.MouseDown += GraphicsBox_MouseDown;
            graphicsBox.MouseUp += GraphicsBox_MouseUp;
            graphicsBox.MouseMove += GraphicsBox_MouseMove;
        }

        private void GraphicsBox_MouseMove(object? sender, MouseEventArgs e)
        {
            if (!_held)
                return;
            Point cur = e.Location;
            double[] angleChange = new double[3];



        }

        private void GraphicsBox_MouseUp(object? sender, MouseEventArgs e)
        {
            if (_held)
            {
                _lastHit = null;
            }
        }

        private void GraphicsBox_MouseDown(object? sender, MouseEventArgs e)
        {
            if (!_held)
            {
                _lastHit = e.Location;
                _held = true;
            }
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

    }
}
