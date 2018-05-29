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
            Vector3 mainLPos = new Vector3(0, -10, -1);
            Vector3 mainLInt = new Vector3(2, 2, 1.5f);
            Light mainLight = new Light(mainLPos, mainLInt);
            lightList.Add(mainLight);

            Vector3 light2Pos = new Vector3(0, -10, 20);
            Vector3 light2Int = new Vector3(2, 2, 2);
            Light light2 = new Light(light2Pos, light2Int);
            lightList.Add(light2);
            

            Sphere sphere1 = new Sphere(2, -8, 0, 15)
            {
                material = new Material(new Vector3(1, 0, 0))
                
            };
            sphere1.material.IsReflective = true;
            primitives.Add(sphere1);
            sphereList.Add(sphere1);

            Sphere sphere2 = new Sphere(5, 0, -2, 30)
            {
                material = new Material(new Vector3(1, 0, 1))
            };
            sphere2.material.IsReflective = true;
            primitives.Add(sphere2);
            sphereList.Add(sphere2);

            Sphere sphere3 = new Sphere(4, 6, 0, 20)
            {
                material = new Material(new Vector3(0, 0, 1))
            };
            primitives.Add(sphere3);
            sphereList.Add(sphere3);

            Plane plane1 = new Plane(new Vector3(0, 1, 0), new Vector3(0, 5, 0));
            for (int a = -10; a < 10; a++)
                for (int b = 0; b < 20; b++)
                {
                    int Checkboard = ((2 * a) + b) & 1;
                    plane1.material = new Material(new Vector3(1f, 1f, 1f) * Checkboard);
                }           
           
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
