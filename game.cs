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
            tracer.Render(512,512);   
    }
	
	public void Tick()
	{
            

    }
}

} // namespace Template