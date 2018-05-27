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
        //Camera camera = new Camera();
        Scene scene = new Scene();
        // member variables
        public Surface screen;
        // initialize
        public void Init()
        {

        }

        public void Tick()
        {
            //tracer.Render(512,512);
            for (int i = 0; i < 512; i++)
            {
                for (int j = 0; j < 512; j++)
                {
                    int location = j + i * 1024;
                    float u = j / 512f;
                    float v = i / 512f;

                    Vector3 floatcolor = tracer.Render(u, v);

                    float clampx = Math.Min(floatcolor.X, 1);
                    float clampy = Math.Min(floatcolor.Y, 1);
                    float clampz = Math.Min(floatcolor.Z, 1);

                    int redcomponent = (int)(255 * floatcolor.X);
                    int greencomponent = (int)(255 * floatcolor.Y);
                    int bluecomponent = (int)(255 * floatcolor.Z);

                    int intcolor = (redcomponent << 16) + (greencomponent << 8) + bluecomponent;

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
            int coloroffset = 0x00ff00;
            foreach (Sphere sphere in scene.sphereList)
            {
                coloroffset *= 256 + 100;
                for (int theta = 0; theta < 360; theta++)
                {
                    double xcord = sphere.rad * 10 * Math.Cos(theta);
                    double ycord = sphere.rad * 10 * Math.Sin(theta);
                    int offsetX = (int)sphere.spherePos.X;
                    int offsetY = (int)sphere.spherePos.Y;
                    screen.Plot((int)xcord + offsetX + 750, (int)ycord + offsetY + 256, coloroffset);
                }
            }

            //Draws a seperation line.
            screen.Line(512, 0, 512, 512, 0xff0000);

            app.MoveCam(tracer.camera);
        }
    }

} // namespace Template