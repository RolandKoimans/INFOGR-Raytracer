using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Template
{
    class Plane : Primitive
    {
        public Vector3 normal, P;
        //public float distance;
        public int size;     
    
        public Plane(Vector3 norm, int sz)
        {
            normal = norm;            
            //distance = dist;
            size = sz;
            P = size * normal;
        }

        public override void Intersect(Ray ray)
        {
            Vector3 E = ray.Origin;
            Vector3 D = ray.Direction;

            float ND = Dot(normal, D);

            if (ND == 0) return;

            float t = Dot(normal, (P - E)) / ND;

            if (t < 0 || ND == 0) return;

            ray.t = t;
        }
    }
}
