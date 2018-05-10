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

        public Sphere()
        {
            theta = 0;
            phi = 0;                   


        }

        public void DrawSphere(int radius, float posx, float posy, float posz)
        {
            spherePos = new Vector3(posx, posy, posz);
            // gives the center of the sphere.         

            while (theta < 2*Math.PI && phi < 2*Math.PI)               
            {
                theta++; phi++;
                x = spherePos.X + radius * (Math.Sin(theta) * Math.Cos(phi));
                y = spherePos.Y + radius * (Math.Sin(theta) * Math.Sin(phi));
                z = spherePos.Z + radius * (Math.Cos(theta));

                // parametric equation for a sphere, taking the sphere's radius and coordinates of the center as parameters. 
                // the loop calculates the coordinates for all points on the sphere, while increasing angles theta and phi. 
            }
        }
    }
}
