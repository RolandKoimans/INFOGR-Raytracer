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
    class Scene 
    {
        public List<Primitive> primitives = new List<Primitive>();
        public List<Primitive> sphereList = new List<Primitive>();
        public List<Light> lightList = new List<Light>();


        public Scene()
        {
            Vector3 mainLPos = new Vector3(-1, -10, -3);
            Vector3 mainLInt = new Vector3(5f, 5f, 5f);
            Light mainLight = new Light(mainLPos, mainLInt);
            lightList.Add(mainLight);

       
            Sphere sphere1 = new Sphere(4, -5, 0, 20)
            {
                material = new Material(new Vector3(1, 0, 0))

            };
            primitives.Add(sphere1);
            sphereList.Add(sphere1);

            Sphere sphere2 = new Sphere(5, 0, 0, 30)
            {
                material = new Material(new Vector3(1, 0, 1))
            };
            primitives.Add(sphere2);
            sphereList.Add(sphere2);

            Sphere sphere3 = new Sphere(6, 5, 0, 35)
            {
                material = new Material(new Vector3(0, 0, 1))
            };
            primitives.Add(sphere3);
            sphereList.Add(sphere3);


            Plane plane1 = new Plane(new Vector3(0, 1, 0), new Vector3(0,5,0))
            {
                material = new Material(new Vector3(0.5f,0.9f,0.2f))
            };
            primitives.Add(plane1);

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
