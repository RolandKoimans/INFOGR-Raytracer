using System;
using System.IO;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Template {

class Game
{

        Raytracer tracer = new Raytracer();
        Camera camera = new Camera();
        Scene scene = new Scene();
    // member variables
    public Surface screen;
	// initialize
	public void Init()
	{
            //tracer.Render(512,512);
            for (int i = 0; i < 512; i++)
            {
                for (int j = 0; j < 512; j++)
                {
                    int location = j + i * 1024;
                    screen.pixels[location] = tracer.Render(i, j);


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
        }
	
	public void Tick()
	{


            //Seperation line
            //screen.Line(512, 0, 512, 512, 0xff0000);
            //tracer.DrawPrimsDebug();







        }
    }

} // namespace Template