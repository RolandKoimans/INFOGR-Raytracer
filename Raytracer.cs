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
        public float epsilon, shadowdist;

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

            // If intersect, check color
            if (closestIntersect != null)
            {
                foreach (Light light in scene.lightList)
                {

                    Vector3 currentcolor = closestIntersect.currentobject.material.color;

                    if (!IsVisible(closestIntersect, light))
                    {
                        currentcolor = currentcolor * 0;
                    }

                    else
                    {
                        if (closestIntersect.currentobject == scene.primitives[3])
                        {
                            Vector3 point = closestIntersect.ray.Origin + closestIntersect.distance * closestIntersect.ray.Direction;
                            if ((int)point.X % 2 == 1 ^ (int)point.Z % 2 == 1  ^ (int)point.X*-1 % 2 == 1 ^ (int)point.Z*-1 % 2 == 1)
                            {
                                currentcolor = new Vector3(0.1f, 0.1f, 0.1f);
                            }
                            else
                            {
                                currentcolor = new Vector3(1f, 1f, 1f);
                            }
                        }

                        currentcolor.X = Math.Min(currentcolor.X * light.DistAtt(shadowdist).X, 1f);
                        currentcolor.Y = Math.Min(currentcolor.Y * light.DistAtt(shadowdist).Y, 1f);
                        currentcolor.Z = Math.Min(currentcolor.Z * light.DistAtt(shadowdist).Z, 1f);
                    }
                    return currentcolor;
                }
            }

            // Return black when there is no intersection
            return Vector3.Zero;
        }

        public Ray GetSecondaryRay(Intersection intersection)
        {
            Ray secRay;
            Vector3 secOr = new Vector3(intersection.ray.Origin + intersection.distance * intersection.ray.Direction);
            Vector3 secDir = new Vector3(2 * intersection.normal * (intersection.normal * intersection.ray.Direction) - intersection.ray.Direction);

            return secRay = new Ray(secOr, secDir);
        }

        public bool IsVisible(Intersection intersection, Light light)
        {
            Vector3 intersP = new Vector3(intersection.ray.Origin + intersection.distance * intersection.ray.Direction);
            Vector3 shadowDir = new Vector3(Vector3.Normalize(light.lightPos - intersP));



            epsilon = 0.001f;

            Vector3 offsetIntersP = intersP + epsilon * shadowDir;

            Ray shadowRay = new Ray(offsetIntersP, shadowDir);


            foreach (Primitive prim in scene.primitives)
            {
                Intersection intersect = prim.Intersect(shadowRay);

                if (intersect != null)
                {
                    return false;
                }
            }
            shadowdist = (float)Math.Sqrt((light.lightPos.X - intersP.X) * (light.lightPos.X - intersP.X) + (light.lightPos.Y - intersP.Y) * (light.lightPos.Y - intersP.Y) + (light.lightPos.Z - intersP.Z) * (light.lightPos.Z - intersP.Z));
            return true;
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
