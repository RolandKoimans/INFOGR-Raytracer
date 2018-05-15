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
        public Vector3 normal, point, distance, P;
        public int size;     
    
        public Plane(Vector3 norm, Vector3 dist, int sz)
        {
            normal = norm;            
            distance = dist;
            size = sz;
            P = size * normal + distance;
        }
        
        public override void Intersect(Ray ray)
        {
            Vector3 E = ray.Origin;
            Vector3 D = ray.Direction;

            float ND = Dot(normal, D);

            if (ND == 0) return;

            float t = Dot(normal, (P - E)) / ND;

            if (t < 0) return;

            ray.t = t;



            ray.t = (Dot(normal, (point - ray.Origin)) / Dot(normal, ray.Direction));   // <--- website
            //ray.t = -(Dot(ray.Origin, normal) + distance) / Dot(normal, ray.Direction); // length ray   <---- slides
            point = ray.Origin + ray.t * ray.Direction;
            
            

            if (ray.t < 0 || Dot(normal, ray.Direction) == 0) return; // no intersection
            //ray.t >= 0 intersection point = origin + ray.t*distance
            
        }
    }
}
