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
    class Camera //: Raytracer
    {
        public Vector3 cameraPos = new Vector3(0, 0, 0); // HERE
        Vector3 viewDirection = new Vector3(0, 0, -1);

        float FOV = 1;
        public Vector3 p1, p2, p3; 
        public Vector3 screenCenter = new Vector3(0, 0, 0);
        

        public Camera() 
        {
            screenCenter = cameraPos + FOV * viewDirection;
            p1 = screenCenter + new Vector3(-1, -1, 0);
            p2 = screenCenter + new Vector3(1, -1, 0);
            p3 = screenCenter + new Vector3(-1, 1, 0);
 
        }

        
    }
}
