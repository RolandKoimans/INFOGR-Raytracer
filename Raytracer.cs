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
        Camera camera = new Camera(); 
        Scene scene = new Scene();
        public Vector2 circleEq;


        public Raytracer()
        {
            debug = new Surface(512, 512);
            screen = new Surface(512, 512);

        }

        public int Render(int width, int height)
        {
            int u = width / 1000;
            int v = height / 1000;
            
                    rayDir = new Vector3(width, height, 0) - camera.cameraPos;
            //Console.WriteLine("direction before norm " + rayDir.X.ToString() + " y " + rayDir.Y.ToString() + " z " + rayDir.Z.ToString());
                    // z = 1 for now, just like the camera. 
                    float normalizer = (float)(1 / Math.Sqrt(rayDir.X * rayDir.X + rayDir.Y * rayDir.Y + rayDir.Z * rayDir.Z));
                    rayDir = new Vector3(rayDir.X * normalizer + rayDir.Y * normalizer + rayDir.Z * normalizer);

                    Ray ray = new Ray(camera.cameraPos, rayDir);
                    // all rays start at the cameraposition. 
                    // the direction (rayDir) depends on the values of i and j. i is the x value in the plane, j the y value. 
                    // the direction is then normalized with 'normalizer' (1/magnitude) and a new ray is created with camerPos and rayDir. 
                    
                    scene.IntersectAll(ray);
                    return (int)ray.t;
                    //Console.WriteLine("location: " + location + " Ray t: " + ray.t);
                    

                    //if (i % 10 == 0 && j == 0)
                    //{
                    //    debug.Line((int)camera.cameraPos.X, 0, i, j, 0xffffff);
                    //}
                    
                    // should be a different screen (same one as the ones containing the scene right now)
                    // coordinates of line also not correct yet. 
                
        }

        public void DrawPrimsDebug()
        {
            foreach(Sphere sphere in scene.primitives)
            {
                for (int theta = 0; theta < 360; theta++)
                {
                    theta = (int)(theta * Math.PI)/180;                   
                    Vector2 circleOr = new Vector2(sphere.spherePos.X + 512, sphere.spherePos.Y);
                    circleEq = circleOr + sphere.rad * new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta));
                }//draw circle or line at y=0

                GL.Color3(1.0f, 1.0f, 0f);
                GL.Begin(PrimitiveType.LineLoop);
                GL.Vertex2((double)circleEq.X, (double)circleEq.Y);
            }
        }
    }
}
