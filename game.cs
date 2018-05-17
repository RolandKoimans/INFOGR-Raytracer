using System;
using System.IO;

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
            
    }
	
	public void Tick()
	{
            //Original Screen
            for (int i = 0; i < 512; i++)
            {
                for (int j = 0; j < 512; j++)
                {
                    int location = j + i * 1024;
                    screen.pixels[location] = tracer.Render(i,j);


                }
            }

            //Debug Screen
            for (int k = 512; k < 1024; k++)
            {
                for (int l = 0; l < 512; l++)
                {
                    int location = k + l * 1024;
                    screen.pixels[location] = 256*255;
                }
            }

            //Seperation line
            screen.Line(512, 0, 512, 512, 0xff0000);

        }
    }

} // namespace Template