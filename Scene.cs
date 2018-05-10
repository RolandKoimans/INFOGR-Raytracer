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
            Sphere sphere1 = new Sphere();
            sphere1.DrawSphere(3, 2, 4, 17);

            Sphere sphere2 = new Sphere();
            sphere2.DrawSphere(10, 10, 2, 5);

            Sphere sphere3 = new Sphere();
            sphere3.DrawSphere(5, 2, 20, 17);

            Plane left = new Plane();
            left.normal = new Vector3(1, 0, 0);

            Plane top = new Plane();
            top.normal = new Vector3(0, 1, 0);

            Plane back = new Plane();
            back.normal = new Vector3(0, 0, -1);

            Plane right = new Plane();
            right.normal = new Vector3(-1, 0, 0);

            Plane bottom = new Plane();
            bottom.normal = new Vector3(0, -1, 0); // should become the checkered board. 

        }

        // public Vector3 Intersect()
        // {
        // for each ( primitive in primitives)
        // primitive.intersectMethodFromPrimitiveClass();
        // return closest intersection;  <-- probably a Vector3 value. 
        // }
    }
}
