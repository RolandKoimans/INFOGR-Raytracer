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
            for (int theta = 0; theta < 360; theta++  )
            {
            
                double xcord = 100 * Math.Cos(theta) + 100;
                double ycord = 100 * Math.Sin(theta) + 100;
                //Console.WriteLine("x " + xcord + " y " + ycord);
                //int location = 100 + 100 * 1024;
                screen.Plot((int)xcord, (int)ycord, 0xff0000);
                //screen.pixels[location] = 256 * 256 + 1000;

            }
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