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
    class Raytracer
    {
        public Camera camera = new Camera();
        public Scene scene = new Scene();

        public Vector2 circleEq;


        public Raytracer()
        {

        }

        public Vector3 Render(float u, float v)
        {
            Ray ray = camera.getRay(u, v);
            return Trace(ray);
        }

        public Vector3 Trace(Ray ray)
        {
            float maxdistance = float.PositiveInfinity;
            Intersection closestIntersect = null;

            //Check every primitive for the closest intersection
            foreach (Primitive prim in scene.primitives)
            {
                Intersection intersect = prim.Intersect(ray);

                if (intersect != null)
                {
                    if (intersect.distance < maxdistance)
                    {
                        maxdistance = intersect.distance;
                        closestIntersect = intersect;
                    }

                }
            }

            // If intersect, then return distance as color
            if (closestIntersect != null)
            {
                return closestIntersect.currentobject.material.color;
            }

            // Return black when there is no intersection
            return Vector3.Zero;
        }


        public bool IsVisible(Intersection intersection, Light light)
        {
            Vector3 intersP = new Vector3(intersection.ray.Origin + intersection.distance * intersection.ray.Direction);
            Vector3 shadowDir = new Vector3( Vector3.Normalize(light.lightPos - intersP));

            float t = 10;


            Ray shadowRay = new Ray(intersP, shadowDir);


            if (/*placeholder*/t + 1 > 20)
                return true;
            else
                return false;
        }


        public void DrawPrimsDebug()
        {
            foreach (Sphere sphere in scene.sphereList)
            {
                GL.Begin(PrimitiveType.TriangleFan);
                GL.Color3(50f, 50f, 50f);
                for (int theta = 0; theta < 360; theta++)
                {
                    //theta = (int)(theta * Math.PI)/180;                   
                    Vector2 circleOr = new Vector2(sphere.spherePos.X + 512, sphere.spherePos.Y);
                    circleEq = circleOr + sphere.rad * new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta));
                    GL.Vertex2(Math.Cos(theta) * 10, Math.Sin(theta) * 10);
                }//draw circle or line at y=0
                GL.End();
                //GL.Color3(1.0f, 1.0f, 0f);
                //GL.Begin(PrimitiveType.LineLoop);
                //GL.Vertex2((double)circleEq.X, (double)circleEq.Y);
            }
        }
    }
}
