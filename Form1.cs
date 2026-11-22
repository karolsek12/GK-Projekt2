using System.Security;
using System.Windows.Forms;
using GK_Projekt2.Algorithms;
using GK_Projekt2.Components;
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

            List<BezierSurface> surfaces = new List<BezierSurface>();

            surfaces.Add(new BezierSurface(Constants.TestControlPoints));

            _renderer = new Renderer(graphicsBox, surfaces);

            graphicsBox.MouseDown += GraphicsBox_MouseDown;
            graphicsBox.MouseUp += GraphicsBox_MouseUp;
            graphicsBox.MouseMove += GraphicsBox_MouseMove;

            _timer = new WTimer
            {
                Interval = Constants.Cooldown
            };

            _timer.Tick += ClockTick;
            _timer.Enabled = true;

            for (int i = 0; i < surfaces.Count; i++)
            {
                CurveID.Items.Add($"{i}");
            }

            CurveID.SelectedIndex = 0;
        }

        private Color PointToColor(Point<double> c)
        {
            int r = Math.Min((int)(c.X * 255), 255);
            int g = Math.Min((int)(c.Y * 255), 255);
            int b = Math.Min((int)(c.Z * 255), 255);

            return Color.FromArgb(r, g, b);
        }

        private Point<double> ColorToPoint(Color c)
        {
            double r = Math.Min(c.R / 255.0, 1.0);
            double g = Math.Min(c.G / 255.0, 1.0);
            double b = Math.Min(c.B / 255.0, 1.0);

            return new Point<double>(r, g, b);
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

            if (MouseToRotation.GetRotation(_lastHit.Value, cur, out angleChange))
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

        private void Fill_Triangles_CheckedChanged(object sender, EventArgs e)
        {
            _renderer.SetTriangles(Fill_Triangles.Checked);
        }

        private void Draw_Mesh_CheckedChanged(object sender, EventArgs e)
        {
            _renderer.SetMesh(Draw_Mesh.Checked);
        }

        private void Draw_Poly_CheckedChanged(object sender, EventArgs e)
        {
            _renderer.SetPoly(Draw_Poly.Checked);
        }

        private void Draw_Bezier_CheckedChanged(object sender, EventArgs e)
        {
            _renderer.SetBezier(Draw_Bezier.Checked);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ks_slider_Scroll(object sender, EventArgs e)
        {
            double val = (ks_slider.Value / 100.0);

            if (val > 100.0)
                val = 100.0;

            _renderer.Setks(val);
        }

        private void kd_slider_Scroll(object sender, EventArgs e)
        {
            double val = (kd_slider.Value / 100.0);

            if (val > 100.0)
                val = 100.0;

            _renderer.Setkd(val);
        }

        private void m_slider_Scroll(object sender, EventArgs e)
        {
            int val = m_slider.Value;

            _renderer.Setm(val);
        }

        private void n_slider_Scroll(object sender, EventArgs e)
        {
            int val = n_slider.Value;

            _renderer.SetTriangles(val);
        }

        private void Move_Light_CheckedChanged(object sender, EventArgs e)
        {
            _renderer.SetLight(Move_Light.Checked);
        }

        private void CurveID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = CurveID.SelectedIndex;
            Del_Normal.Enabled = _renderer.CheckHasNormal(id);
        }

        private void Color_Button_Click(object sender, EventArgs e)
        {
            int id = CurveID.SelectedIndex;
            Color_Dialog.AllowFullOpen = true;
            Color_Dialog.FullOpen = false;
            Color_Dialog.SolidColorOnly = false;

            if (Color_Dialog.ShowDialog() == DialogResult.OK)
            {
                Color selectedColor = Color_Dialog.Color;
                _renderer.SetMeshColor(ColorToPoint(selectedColor), id);
            }
        }

        private void Image_Button_Click(object sender, EventArgs e)
        {
            int id = CurveID.SelectedIndex;
            if (Open_Image.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Bitmap bitmap = new Bitmap(Open_Image.FileName);
                    _renderer.SetMeshImage(bitmap, id);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error.\n\nError message: {ex.Message}");
                }
            }
        }

        private void Set_Normal_Click(object sender, EventArgs e)
        {
            int id = CurveID.SelectedIndex;
            if (Open_Image.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Bitmap bitmap = new Bitmap(Open_Image.FileName);
                    _renderer.SetNormal(bitmap, id);
                    Del_Normal.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error.\n\nError message: {ex.Message}");
                }
            }
        }

        private void Del_Normal_Click(object sender, EventArgs e)
        {
            int id = CurveID.SelectedIndex;

            _renderer.RemoveNormal(id);

            Del_Normal.Enabled = false;
        }
    }
}
