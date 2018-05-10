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
    class Raytracer
    {
        public Surface debug;
        
        public Raytracer()
        {
            debug = new Surface(512, 512);
            
        }
    }
}
