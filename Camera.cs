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
    class Camera : Raytracer
    {
        Vector3 cameraPos = new Vector3(0, 0, 0);
        Vector3 viewDirection = new Vector3(0, 0, 1);

        float FOV = 1;
        Vector3 p1, p2, p3, rayDir;
        Vector3 screenCenter = new Vector3(0, 0, 0);
        

        public Camera()
        {
            screenCenter = cameraPos + FOV * viewDirection;
            p1 = screenCenter + new Vector3(-1, -1, 0);
            p2 = screenCenter + new Vector3(1, -1, 0);
            p3 = screenCenter + new Vector3(-1, 1, 0);
 
        }

        public void GeneratePrimaryRays()
        {
            Game game = new Game();

            for (int i = 0; i < game.screen.width; ++i)
                for (int j = 0; j < game.screen.height; ++j)
                {                    
                    rayDir = new Vector3(i, j, 1) - cameraPos;
                    // z = 1 for now, just like the camera. 
                    float normalizer = (float)(1 / Math.Sqrt(rayDir.X * rayDir.X + rayDir.Y * rayDir.Y + rayDir.Z * rayDir.Z));
                    rayDir = new Vector3(rayDir.X * normalizer + rayDir.Y * normalizer + rayDir.Z * normalizer);

                    Ray ray = new Ray(cameraPos, rayDir);
                    // all rays start at the cameraposition. 
                    // the direction (rayDir) depends on the values of i and j. i is the x value in the plane, j the y value. 
                    // the direction is then normalized with 'normalizer' (1/magnitude) and a new ray is created with camerPos and rayDir. 

                    if (i%10 == 0 && j == 0)
                    {
                        debug.Line((int)cameraPos.X, 0, i, j, 0xffffff);
                    }
                    // this is supposed to be in the Raytracer class. Here for the time being. 
                    // should also be a different screen (same one as the ones containing the scene right now)
                    // coordinates of line also not correct yet. 
                }
        }        
    }
}
