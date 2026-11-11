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

        public Mesh(List<Triangle> triangles)
        {
            _triangles = triangles;
        }

        public List<Triangle> Triangles
        {
            get
            {
                return _triangles;
            }
        }
    }
}
