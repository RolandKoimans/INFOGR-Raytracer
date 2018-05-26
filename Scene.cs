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
    class Scene //: Raytracer
    {
        public List<Primitive> primitives = new List<Primitive>();
        public List<Primitive> sphereList = new List<Primitive>();


        public Scene()
        {


       
            Sphere sphere1 = new Sphere(4, -5, 0, 20)
            {
                material = new Material(new Vector3(1, 0, 0))

            };
            primitives.Add(sphere1);
            sphereList.Add(sphere1);

            Sphere sphere2 = new Sphere(5, 0, 0, 30)
            {
                material = new Material(new Vector3(0, 1, 0))
            };
            primitives.Add(sphere2);
            sphereList.Add(sphere2);

            Sphere sphere3 = new Sphere(6, 5, 0, 35)
            {
                material = new Material(new Vector3(0, 0, 1))
            };
            primitives.Add(sphere3);
            sphereList.Add(sphere3);


            Plane bottom = new Plane(new Vector3(0, -1, 0), 10);
            //bottom.distance = 5;
            primitives.Add(bottom);

        }

        public Vector3 IntersectAll(Ray ray)
        {
            Vector3 cloInt;
            float shortesT = 1000;
            float currenT;
            foreach (Primitive primitive in primitives)
            {
                Intersection intersect = primitive.Intersect(ray);
                currenT = intersect.distance;
                if (currenT < shortesT)
                {
                    shortesT = currenT;
                }
            }
            cloInt = ray.Origin + shortesT * ray.Direction;

            return cloInt;
        }
    }
}
