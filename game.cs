using System;
using System.IO;

namespace Template {

class Game
{

    Camera camera = new Camera();
    // member variables
    public Surface screen;
	// initialize
	public void Init()
	{
            
    }
	// tick: renders one frame
	public void Tick()
	{
            
            camera.GeneratePrimaryRays(screen.width, screen.height);
	}
}

} // namespace Template