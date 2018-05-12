﻿using System;
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
        Vector3 P;
        public float t;

        public Ray(Vector3 origin, Vector3 direction)
        {
            t = 1;
            Origin = origin;
            Direction = direction;
            P = Origin + t * Direction;
            
        }

    }
}
