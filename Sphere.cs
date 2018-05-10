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
        int radius;
        double x, y, z;
        int theta, phi;

        public Sphere()
        {
            theta = 0;
            phi = 0;
            spherePos = new Vector3(12, 1, 4); // temporary values
        }

        public void DrawSphere()
        {
            while (theta < 2*Math.PI && phi < 2*Math.PI)               
            {
                theta++; phi++;
                x = spherePos.X + radius * (Math.Sin(theta) * Math.Cos(phi));
                y = spherePos.Y + radius * (Math.Sin(theta) * Math.Sin(phi));
                z = spherePos.Z + radius * (Math.Cos(theta));
            }
        }
    }
}
