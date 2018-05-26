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
    class Intersection
    {
        public float distance;
        public Ray ray;
        public Vector3 normal;
        public Primitive currentobject;

        public Intersection(float distance, Ray ray, Vector3 normal, Primitive currentobject)
        {
            this.distance = distance;
            this.ray = ray;
            this.normal = normal;
            this.currentobject = currentobject;
        }
    }
}
