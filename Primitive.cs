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
    class Primitive
    {
        Vector3 color;

        public Primitive()
        { }

        public virtual void Intersect(Ray ray)
        {

        }

        public float Dot(Vector3 a, Vector3 b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }
        // calculates dot product of two vectors. 
    }
}
