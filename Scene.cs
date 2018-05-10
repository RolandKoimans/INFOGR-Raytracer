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
    class Scene : Raytracer
    {
        List<Primitive> primitives;
        List<Light> lightsources;


        // public Vector3 Intersect()
        // {
        // for each ( primitive in primitives)
        // primitive.intersectMethodFromPrimitiveClass();
        // return closest intersection;  <-- probably a Vector3 value. 
        // }
    }
}
