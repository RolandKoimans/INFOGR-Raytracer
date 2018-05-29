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
        public Vector3 lightPos, intensity;

        public Light(Vector3 pos, Vector3 inten)
        {
            lightPos = pos;
            intensity = inten;
        }

        public Vector3 DistAtt(float distance)
        { 
            Vector3 energy = intensity* 1000 *(1 / (4 * (float)Math.PI * (distance * distance)));
            return energy;
        }
    }
}
