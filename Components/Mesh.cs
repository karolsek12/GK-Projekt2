using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Projekt2.Components
{
    public class Mesh
    {
        private List<Triangle> _triangles;
        private ColorInfo _ci;
        private List<Point<double>> _controlPoints;
        private List<Point<double>> _controlPointsAfter;
        private NormalInfo? _normalInfo;
        private BumpInfo? _bumpInfo;

        public Mesh(List<Triangle> triangles, List<Point<double>> controlPoints, ColorInfo ci)
        {
            _triangles = triangles;
            _ci = ci;
            _controlPoints = controlPoints;
            _controlPointsAfter = new List<Point<double>>(controlPoints);
            _normalInfo = null;
            _bumpInfo = null;
        }

        public List<Triangle> Triangles
        {
            get
            {
                return _triangles;
            }
            set
            {
                _triangles = value;
            }
        }

        public List<Point<double>> ControlPointsAfter
        {
            get
            {
                return _controlPointsAfter;
            }
        }

        public void RotateVertices(Matrix3<double> rot)
        {
            foreach (Triangle t in _triangles)
            {
                t.RotateVertices(rot);
            }

            _controlPointsAfter.Clear();
            foreach(Point<double> pt in _controlPoints)
            {
                _controlPointsAfter.Add(new Point<double>(rot*new Vector<double>(pt)));
            }
        }

        public ColorInfo CI
        {
            get { return _ci; }
        }

        public NormalInfo? NormalInfo
        {
            get
            {
                return _normalInfo;
            }
        }

        public void RemoveNormal()
        {
            if(_normalInfo != null)
            {
                _normalInfo.Dispose();
                _normalInfo = null;
            }
            
        }

        public void SetNormal(Bitmap bitmap)
        {
            if(_normalInfo != null)
            {
                RemoveNormal();
            }

            _normalInfo = new NormalInfo(bitmap);
        }

        public BumpInfo? BumpInfo
        {
            get
            {
                return _bumpInfo;
            }
        }

        public void RemoveBump()
        {
            if (_bumpInfo != null)
            {
                _bumpInfo.Dispose();
                _bumpInfo = null;
            }
        }
        public void SetBump(Bitmap bitmap)
        {
            if (_bumpInfo != null)
            {
                RemoveBump();
            }

            _bumpInfo = new BumpInfo(bitmap, Constants.KBumpMap);
        }
    }
}
