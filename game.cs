using System;
using System.IO;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Template
{

    class Game
    {

        Raytracer tracer = new Raytracer();
        Application app = new Application();
      
        // member variables
        public Surface screen;
        // initialize
        public void Init()
        {
            Console.WriteLine("To move the camera, use the following controls:\n");
            Console.WriteLine();
            Console.WriteLine("Left: A\n");
            Console.WriteLine("Right: D\n");
            Console.WriteLine("Up: W\n");
            Console.WriteLine("Down: S\n");
            Console.WriteLine("Forward: Q\n");
            Console.WriteLine("Backward: E\n");
            Console.WriteLine();
            Console.WriteLine("Rotate view to left: Left arrow key\n");
            Console.WriteLine("Rotate view to right: Right arrow key\n");
            Console.WriteLine("Rotate view upwards: Up arrow key\n");
            Console.WriteLine("Rotate view downwards: Down arrow key\n");
        }

        public void Tick()
        {

            for (int i = 0; i < 512; i++)
            {
                for (int j = 0; j < 512; j++)
                {
                    int location = j + i * 1024;
                    float u = j / 512f;
                    float v = i / 512f;

                    Vector3 floatcolor = tracer.Render(u, v);

                    int intcolor = getIntColor(floatcolor);

                    screen.pixels[location] = intcolor;


                }
            }

            //Debug Screen
            for (int k = 512; k < 1024; k++)
            {
                for (int l = 0; l < 512; l++)
                {
                    int location = k + l * 1024;
                    screen.pixels[location] = 0;
                }
            }

            //Draws every sphere, including its own offset and a bonus offset, so that the spheres don't cling to the edges.
            //Color offset is a cheap solution to give the spheres a different color each time.

            foreach (Sphere sphere in tracer.scene.sphereList)
            {
                int intcolor = getIntColor(sphere.material.color);
                for (int theta = 0; theta < 360; theta++)
                {
                    double xcord = sphere.rad * 5 * Math.Cos(theta);
                    double ycord = sphere.rad * 5 * Math.Sin(theta);
                    int offsetX = 5 * (int)sphere.spherePos.X;
                    int offsetZ = 5 * (int)sphere.spherePos.Z * -1;
                    screen.Plot((int)xcord + offsetX + 750, (int)ycord + offsetZ + 400, intcolor);
                }
            }

            //Draws the camera in the debug view
            screen.Plot((int)tracer.camera.cameraPos.X + 750, (int)tracer.camera.cameraPos.Z * -1 + 400, 0xff0000);

            foreach (Light light in tracer.scene.lightList)
            {
                screen.Plot((int)light.lightPos.X + 750, (int)light.lightPos.Z * -1 + 400, 0xcc66ff);
            }
            

            //Draws the primary rays in the debug view
            for (float j = 0; j < 1f; j += 0.1f)
            {
                Ray primaryray = tracer.camera.getRay(j, 0.5f);
                float t = 50;

                foreach (Primitive prim in tracer.scene.sphereList)
                {
                    Intersection intersect = prim.Intersect(primaryray);
                    if (intersect != null)
                    {
                        if (intersect.distance < t)
                        {
                            t = intersect.distance;
                        }
                    }
                }

                float originx = primaryray.Origin.X;
                float originz = primaryray.Origin.Z;

                float targetx = (primaryray.Origin.X + t * primaryray.Direction.X) * 5;
                float targetz = (primaryray.Origin.Z + t * primaryray.Direction.Z) * 5;

                screen.Line((int)originx + 750, (int)originz * -1 + 400, (int)targetx + 750, (int)targetz * -1 + 400, 0xffff00);
            }

            //Draws the secondary rays in the debug view
            
            //Draws a seperation line.
            screen.Line(512, 0, 512, 512, 0xff0000);

            app.MoveCam(tracer.camera);
        }

        public int getIntColor(Vector3 floatcolor)
        {
            //Converts a color stored as floating point vector to integer value

            float clampx = Math.Min(floatcolor.X, 1);
            float clampy = Math.Min(floatcolor.Y, 1);
            float clampz = Math.Min(floatcolor.Z, 1);

            int redcomponent = (int)(255 * floatcolor.X);
            int greencomponent = (int)(255 * floatcolor.Y);
            int bluecomponent = (int)(255 * floatcolor.Z);

            int intcolor = (redcomponent << 16) + (greencomponent << 8) + bluecomponent;

            return intcolor;
        }


    }

} // namespace Template