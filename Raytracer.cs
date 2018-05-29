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
        public List<Ray> raylist = new List<Ray>();
        public List<Ray> shadowlist = new List<Ray>();
        public List<Ray> secondarylist = new List<Ray>();

        public float epsilon, shadowdist;

        public Raytracer()
        {
            
        }

        public Vector3 Render(float u, float v)
        {
            Ray ray = camera.getRay(u, v);
            if (u % (40f/512f) == 0 && ray.Direction.Y == 0)
            {
                raylist.Add(ray);
            }
            int cap = 0;
            return Trace(ray, cap);
        }

        public Vector3 Trace(Ray ray, int cap)
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
                Vector3 currentcolor = closestIntersect.currentobject.material.color;
                
                bool occluded = true;

                foreach (Light light in scene.lightList)
                {
                    
                    if (IsVisible(closestIntersect, light))
                    {
                        occluded = false;
                        //If floorplane, then apply checkered texture
                        if (closestIntersect.currentobject == scene.primitives[3])
                        {
                            Vector3 point = closestIntersect.ray.Origin + closestIntersect.distance * closestIntersect.ray.Direction;
                            if ((int)point.X % 2 == 1 ^ (int)point.Z % 2 == 1 ^ (int)point.X * -1 % 2 == 1 ^ (int)point.Z * -1 % 2 == 1)
                            {
                                currentcolor = new Vector3(0.1f, 0.1f, 0.1f);
                            }
                            else
                            {
                                currentcolor = new Vector3(1f, 1f, 1f);
                            }
                        }
                        //Checks for reflection, adds a cap for max recursion
                        if (cap < 2)
                        {
                            cap++;
                            currentcolor = AdjustReflection(currentcolor, cap, closestIntersect);
                        }

                        Vector3 intersP = new Vector3(closestIntersect.ray.Origin + closestIntersect.distance * closestIntersect.ray.Direction);
                        shadowdist = (float)Math.Sqrt((light.lightPos.X - intersP.X) * (light.lightPos.X - intersP.X) + (light.lightPos.Y - intersP.Y) * (light.lightPos.Y - intersP.Y) + (light.lightPos.Z - intersP.Z) * (light.lightPos.Z - intersP.Z));

                        currentcolor.X = Math.Min(currentcolor.X * light.DistAtt(shadowdist).X, 1f);
                        currentcolor.Y = Math.Min(currentcolor.Y * light.DistAtt(shadowdist).Y, 1f);
                        currentcolor.Z = Math.Min(currentcolor.Z * light.DistAtt(shadowdist).Z, 1f);
                    }

                    else if (occluded && !IsVisible(closestIntersect, light))
                    {
                        currentcolor = currentcolor * 0;
                    }                  
                              
                }                
                return currentcolor;
            }

            // Return black when there is no intersection
            return Vector3.Zero;
        }

        public Vector3 AdjustReflection(Vector3 currentcolor, int currentdepth, Intersection intersect)
        {
            //Gets new intersection using secondary ray, applies 50% of the new color
            if (intersect.currentobject.material.IsReflective == true)
            {
                Ray secondaryRay = getSecondaryRay(intersect);
                secondaryRay.Direction.Z *= -1;
                secondaryRay.Direction.Y *= -1;
                secondaryRay.Direction.X *= -1;
                Vector3 newcolor = Trace(secondaryRay, currentdepth);

                currentcolor = (currentcolor + newcolor) / 2;

            }
            return currentcolor;
        }

        public Ray getSecondaryRay(Intersection intersection)
        {
            Ray secRay;
            Vector3 secOr = new Vector3(intersection.ray.Origin + intersection.distance * intersection.ray.Direction);
            Vector3 secDir = new Vector3(2 * intersection.normal * Vector3.Dot(intersection.normal, intersection.ray.Direction) - intersection.ray.Direction);
            secRay = new Ray(secOr, secDir);
            if (raylist.Contains(intersection.ray))
            {
                secondarylist.Add(secRay);
            }

            return secRay;
        }

        public bool IsVisible(Intersection intersection, Light light)
        {
            //Creates a shadowray to see if there is something between the object and a lightsource.
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

                
                if (raylist.Contains(intersection.ray))
                {
                    shadowlist.Add(shadowRay);
                }
            }          
            return true;
        }

    }
}
