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
        public Surface debug, screen;
        public Vector3 rayDir;
        Camera camera = new Camera(); //HERE
        Scene scene = new Scene();
        
        public Raytracer()
        {
            debug = new Surface(512, 512);
            screen = new Surface(512, 512);
            
        }

        public void Render(int width, int height)
        {
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                {
                    rayDir = new Vector3(i, j, 1) - camera.cameraPos;
                    // z = 1 for now, just like the camera. 
                    float normalizer = (float)(1 / Math.Sqrt(rayDir.X * rayDir.X + rayDir.Y * rayDir.Y + rayDir.Z * rayDir.Z));
                    rayDir = new Vector3(rayDir.X * normalizer + rayDir.Y * normalizer + rayDir.Z * normalizer);

                    Ray ray = new Ray(camera.cameraPos, rayDir);
                    // all rays start at the cameraposition. 
                    // the direction (rayDir) depends on the values of i and j. i is the x value in the plane, j the y value. 
                    // the direction is then normalized with 'normalizer' (1/magnitude) and a new ray is created with camerPos and rayDir. 
                    int location = i + j * screen.width;
                    scene.IntersectAll(ray);
                    screen.pixels[location] = (int)ray.t;

                    //if (i % 10 == 0 && j == 0)
                    //{
                    //    debug.Line((int)camera.cameraPos.X, 0, i, j, 0xffffff);
                    //}
                    
                    // should be a different screen (same one as the ones containing the scene right now)
                    // coordinates of line also not correct yet. 
                }
        }

        public void DrawPrimsDebug()
        {
            foreach(Primitive primitive in scene.primitives)
            {
                //draw circle or line at y=0
            }
        }
    }
}
