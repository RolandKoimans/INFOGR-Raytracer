using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Template
{
    class Application
    {
        //This class is used for keyboard input. It changes the camera position.
        KeyboardState state;

        public Application()
        {
            state = Keyboard.GetState();
        }

        public void MoveCam(Camera camera)
        {
            state = Keyboard.GetState();
            if (state.IsKeyDown(Key.A))
            {
                camera.cameraPos.X--;
            }

            else if (state.IsKeyDown(Key.D))
            {
                camera.cameraPos.X++;
            }

            else if (state.IsKeyDown(Key.W))
            {
                camera.cameraPos.Y--;
            }

            else if (state.IsKeyDown(Key.S))
            {
                camera.cameraPos.Y++;
            }

            else if (state.IsKeyDown(Key.Q))
            {
                camera.cameraPos.Z++;
            }

            else if (state.IsKeyDown(Key.E))
            {
                camera.cameraPos.Z--;
            }

            else if (state.IsKeyDown(Key.Left))
            {
                camera.viewDirection.X -= 0.1f;
            }

            else if (state.IsKeyDown(Key.Right))
            {
                camera.viewDirection.X += 0.1f;
            }

            else if (state.IsKeyDown(Key.Up))
            {
                camera.viewDirection.Y -= 0.1f;
            }

            else if (state.IsKeyDown(Key.Down))
            {
                camera.viewDirection.Y += 0.1f;
            }
        }
    }
}
