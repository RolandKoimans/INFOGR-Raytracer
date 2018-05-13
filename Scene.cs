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
    class Scene : Raytracer
    {
        List<Primitive> primitives;
        List<Light> lightsources;

        public Scene()
        {
            List<Primitive> primitives = new List<Primitive>();

            // should be 10x10x10 cube. 
            Sphere sphere1 = new Sphere(3, 2, 0, 7);
            //sphere1.DrawSphere(3, 2, 0, 7);
            primitives.Add(sphere1);

            Sphere sphere2 = new Sphere(2, 7, 0, 5);
            //sphere2.DrawSphere(2, 7, 0, 5);
            primitives.Add(sphere2);

            Sphere sphere3 = new Sphere(1, 2, 0, 2);
            //sphere3.DrawSphere(1, 2, 0, 2); // y=0, because center should be at y=0. 
            primitives.Add(sphere3);

            //Plane left = new Plane();
            //left.normal = new Vector3(1, 0, 0);
            //primitives.Add(left);

            //Plane top = new Plane();
            //top.normal = new Vector3(0, 1, 0);
            //primitives.Add(top);

            //Plane back = new Plane();
            //back.normal = new Vector3(0, 0, -1);
            //primitives.Add(back);

            //Plane right = new Plane();
            //right.normal = new Vector3(-1, 0, 0);
            //primitives.Add(right);

            Plane bottom = new Plane(new Vector3(0, -1, 0), new Vector3(0, -1, 0), 10);
            //bottom.distance = 5;
            primitives.Add(bottom);

        }

        // public Vector3 Intersect()
        // {
        // for each ( primitive in primitives)
        // primitive.intersectMethodFromPrimitiveClass();
        // return closest intersection;  <-- probably a Vector3 value. 
        // }
    }
}
