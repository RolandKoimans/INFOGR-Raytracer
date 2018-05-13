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
    class Sphere : Primitive
    {
        Vector3 spherePos;
        double x, y, z;        
        int theta, phi;
        int rad;
        float posX, posY, posZ;

        public Sphere(int radius, float posx, float posy, float posz)
        {
            theta = 0;
            phi = 0;
            rad = radius;
            posX = posx;
            posY = posy;
            posZ = posz;
           
        }

        //public void DrawSphere(int radius, float posx, float posy, float posz)
        //{
        //    spherePos = new Vector3(posx, posy, posz);
        //    // gives the center of the sphere.         

        //    while (theta < 2*Math.PI && phi < 2*Math.PI)               
        //    {
        //        theta++; phi++;
        //        x = spherePos.X + radius * (Math.Sin(theta) * Math.Cos(phi));
        //        y = spherePos.Y + radius * (Math.Sin(theta) * Math.Sin(phi));
        //        z = spherePos.Z + radius * (Math.Cos(theta));

        //        // parametric equation for a sphere, taking the sphere's radius and coordinates of the center as parameters. 
        //        // the loop calculates the coordinates for all points on the sphere, while increasing angles theta and phi. 
        //    }
        //}

        public override void Intersect(Ray ray)
        {
            Vector3 c = this.spherePos - ray.Origin;
            float t = Dot(c, ray.Direction);
            Vector3 q = c - t * ray.Direction;
            float psqrt = Dot(q, q);
            //if (psqrt > (radius * radius) ) return;
            //t -= Math.Sqrt((radius * radius) – psqrt);
            if ((t < ray.t) && (t > 0)) ray.t = t;
            // or: ray.t = min( ray.t, max( 0, t ) );
        }
    }
}
