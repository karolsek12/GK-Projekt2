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

        public Mesh(List<Triangle> triangles, ColorInfo ci)
        {
            _triangles = triangles;
            _ci = ci;
        }

        public List<Triangle> Triangles
        {
            get
            {
                return _triangles;
            }
        }

        public void RotateVertices(Matrix3<double> rot)
        {
            foreach (Triangle t in _triangles)
            {
                t.RotateVertices(rot);
            }
        }

        public ColorInfo CI
        {
            get { return _ci; }
        }
    }
}
