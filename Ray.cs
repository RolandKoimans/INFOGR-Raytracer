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
    class Ray
    {
        // Ray class, containing the origin vector, the direction vector and distance t
        public Vector3 Origin;
        public Vector3 Direction;
        public float t;

        public Ray(Vector3 origin, Vector3 direction)
        {
            Origin = origin;
            Direction = direction;
            Vector3 P = Origin + t * Direction;
            
        }

    }
}
