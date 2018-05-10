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
    class Plane : Primitive
    {
        public Vector3 normal;
        float distance; // or vector3?
    
        public Plane()
        {            
            //5 planes needed

            Plane left = new Plane();
            left.normal = new Vector3(1, 0, 0);

            Plane top = new Plane();
            top.normal = new Vector3(0, 1, 0);

            Plane back = new Plane();
            back.normal = new Vector3(0, 0, -1);

            Plane right = new Plane();
            right.normal = new Vector3(-1, 0, 0);

            Plane bottom = new Plane();
            bottom.normal = new Vector3(0, -1, 0); // should become the checkered board. 
        }
    }
}
