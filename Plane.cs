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
        public Vector3 normal, offsetpoint;
        //public float distance;

        public Plane(Vector3 norm, Vector3 point)
        {
            normal = norm;
            offsetpoint = point;
            
        }

        public override Intersection Intersect(Ray ray)
        {

            float d = Vector3.Dot(normal, offsetpoint) * -1;

            // t formula from slides
            float t = -((Vector3.Dot(ray.Origin, normal) + d) / Vector3.Dot(ray.Direction, normal));

            //checks if parallel or t behind camera
            if (t < 0 || float.IsInfinity(t)) return null;

            return new Intersection(t, ray, normal, this);


        }
    }
}
