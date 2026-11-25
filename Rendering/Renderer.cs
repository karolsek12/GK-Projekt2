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

        private List<BezierSurface> _bezierSurfaces;
        private List<Mesh> _meshes;
        private TurboBitmapHandler _tbh;
        private Matrix3<double> _rotation;
        private LightInfo _li;
        private double _t;
        private Stopwatch _lightWatch;
        private bool _moveLight;

        public Renderer(PictureBox box,List<BezierSurface> surfaces)
        {
            _box = box;
            _bitmap = new Bitmap[2];
            int w, h;
            w = (int)(box.Width / Constants.StretchRatio);
            h = (int)(box.Height / Constants.StretchRatio);

            _bitmap[0] = new Bitmap(w, h);
            _bitmap[1] = new Bitmap(w,h);
            _rotation = MatrixCreation.GetRot(0,0,0);

            using (Graphics g = Graphics.FromImage(_bitmap[0]))
            {
                g.Clear(Color.White);
            }

            using (Graphics g = Graphics.FromImage(_bitmap[1]))
            {
                g.Clear(Color.White);
            }

            _bezierSurfaces = surfaces;
            _meshes = new List<Mesh>();

            foreach(BezierSurface bs in _bezierSurfaces)
            {
                Mesh mesh = new Mesh(bs.GetTriangles(Constants.InitTriangles), bs.ControlPoints,
                new ColorInfo(0.5, 0.5, 1, Constants.InitMesh)
                );

                _meshes.Add(mesh);
            }

            _tbh = new TurboBitmapHandler(_bitmap[0].Width, _bitmap[0].Height);

            _li = new LightInfo(Constants.InitLightColor, Constants.TestLightControlPoints.ToArray());
            _t = 0;
            _lightWatch = Stopwatch.StartNew();
            _moveLight = true;
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
            if (_moveLight)
            {
                double dt = _lightWatch.Elapsed.TotalSeconds;
                _lightWatch.Restart();

                if (dt > 0.1) dt = 0.1;

                _t = (_t + dt) % Constants.CycleTime;
                _li.SetPos(_t / Constants.CycleTime);
            }
            

            _tbh.Render(GetUnusedBitmap(), _meshes ,_li);
            Flip();
            _box.Image = GetCurrentBitmap();
            _box.Invalidate();
        }

        public void SetRotation(double alpha,double beta, double gamma)
        {
            Matrix3<double> change = MatrixCreation.GetRot(alpha, beta, gamma);

            _rotation = change*_rotation;

            foreach(Mesh mesh in _meshes)
            {
                mesh.RotateVertices(_rotation);
            }

        }

        public void SetTriangles(bool set)
        {
            _tbh.SetTriangles(set);
        }

        public void SetMesh(bool set)
        {
            _tbh.SetMesh(set);
        }

        public void SetPoly(bool set)
        {
            _tbh.SetPoly(set);
        }

        public void SetBezier(bool set)
        {
            _tbh.SetBezier(set);
        }

        public void Setkd(double set)
        {
            foreach(Mesh mesh in _meshes)
            {
                mesh.CI.Kd = set;
            }

        }

        public void Setks(double set)
        {
            foreach(Mesh mesh in _meshes)
            {
                mesh.CI.Ks = set;
            }
        }

        public void Setm(int set)
        {
            foreach(Mesh mesh in _meshes)
            {
                mesh.CI.M = set;
            }
        }

        public void SetTriangles(int set)
        {
            for (int i = 0; i < _meshes.Count; i++) {

                _meshes[i].Triangles = _bezierSurfaces[i].GetTriangles(set);
                _meshes[i].RotateVertices(_rotation);
            }
        }

        public void SetLight(bool set)
        {
            if (set)
            {
                _lightWatch.Restart();
                _moveLight = true;
            }
            else
            {
                _lightWatch.Stop();
                _moveLight = false;
            }
        }

        public void SetMeshColor(Point<double> color,int id)
        {
            _meshes[id].CI.SetPlainColor(color); 
        }

        public void SetMeshImage(Bitmap bm,int id)
        {
            _meshes[id].CI.SetImageColor(bm);
        }

        public void RemoveNormal(int id)
        {
            _meshes[id].RemoveNormal();
        }

        public bool CheckHasNormal(int id)
        {
            return _meshes[id].NormalInfo != null;
        }
        
        public void SetNormal(Bitmap bm,int id)
        {
            _meshes[id].SetNormal(bm);
        }

        public void RemoveBump(int id)
        {
            _meshes[id].RemoveBump();
        }

        public bool CheckHasBump(int id)
        {
            return _meshes[id].BumpInfo != null;
        }

        public void SetBump(Bitmap bm, int id)
        {
            _meshes[id].SetBump(bm);
        }

        public void SetBezierz(double set)
        {
            _li.SetZ(set);
        }

        public double GetControlX(int id)
        {
            return _li.ControlPoints[id].X;
        }

        public double GetControlY(int id)
        {
            return _li.ControlPoints[id].Y;
        }

        public void SetControlX(int id,double set)
        {
            if (id == 0)
            {
                SetControlX(Constants.ControlPointsCount, set);
            }
            _li.ControlPoints[id].X = set;
        }

        public void SetControlY(int id,double set)
        {
            if(id == 0)
            {
                SetControlY(Constants.ControlPointsCount, set);
            }
            _li.ControlPoints[id].Y = set;
        }

        public void SetLightColor(Point<double> color)
        {
            _li.SetColor(color);
        }

        public void SetLightAmount(int amount)
        {
            _li.SetAmount(amount);
        }

        public void SetDirected(bool val)
        {
            _li.SetDirected(val);
        }

        public void SetReflectors(bool val)
        {
            _li.SetReflectors(val);
        }

        public void SetReflectorM(int val)
        {
            _li.SetM(val);
        }
    }


}
