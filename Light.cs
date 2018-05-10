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
    class Light
    {
        Vector3 lightPos, intensity;

        public Light()
        {
            Light mainLight = new Light();
            mainLight.lightPos = new Vector3(20, 50, -10); //should become screen.x/2 and screen.y/2 (or higher)
            mainLight.intensity = new Vector3(0.5f, 0.5f, 0); // should be yellow-ish
        }
    }
}
