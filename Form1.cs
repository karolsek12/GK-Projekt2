using GK_Projekt2.Algorithms;
using GK_Projekt2.Rendering;



namespace GK_Projekt2
{
    using WTimer = System.Windows.Forms.Timer;
    public partial class Form1 : Form
    {
        private Renderer _renderer;
        private bool _held = false;
        private Point? _lastHit;
        private WTimer _timer;

        public Form1()
        {
            InitializeComponent();
            _lastHit = null;
            _renderer = new Renderer(graphicsBox);

            graphicsBox.MouseDown += GraphicsBox_MouseDown;
            graphicsBox.MouseUp += GraphicsBox_MouseUp;
            graphicsBox.MouseMove += GraphicsBox_MouseMove;

            _timer = new WTimer
            {
                Interval = Constants.Cooldown
            };

            _timer.Tick += ClockTick;
            _timer.Enabled = true;
        }

        private void ClockTick(object? sender, EventArgs e)
        {
            _renderer.Render();
        }

        private void GraphicsBox_MouseMove(object? sender, MouseEventArgs e)
        {
            if (!_held || _lastHit == null)
                return;
            Point cur = e.Location;
            double[] angleChange = new double[3];

            if(MouseToRotation.GetRotation(_lastHit.Value, cur,out angleChange))
            {
                _renderer!.SetRotation(angleChange[0], angleChange[1], angleChange[2]);
                _lastHit = cur;
            }

            
        }

        private void GraphicsBox_MouseUp(object? sender, MouseEventArgs e)
        {
            if (_held)
            {
                _lastHit = null;
                _held = false;
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


    }
}
