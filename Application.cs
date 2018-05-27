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
        KeyboardState state;

        public Application()
        {
            state = Keyboard.GetState();
        }

        public void MoveCam(Camera camera)
        {
            state = Keyboard.GetState();
            if (state.IsKeyDown(Key.Left))
            {
                camera.cameraPos.X--;
            }

            else if (state.IsKeyDown(Key.Right))
            {
                camera.cameraPos.X++;
            }

            else if (state.IsKeyDown(Key.Up))
            {
                camera.cameraPos.Y--;
            }

            else if (state.IsKeyDown(Key.Down))
            {
                camera.cameraPos.Y++;
            }

            else if (state.IsKeyDown(Key.A))
            {
                camera.viewDirection.X -= 0.1f;
            }

            else if (state.IsKeyDown(Key.D))
            {
                camera.viewDirection.X += 0.1f;
            }

            else if (state.IsKeyDown(Key.W))
            {
                camera.viewDirection.Y -= 0.1f;
            }

            else if (state.IsKeyDown(Key.S))
            {
                camera.viewDirection.Y += 0.1f;
            }
        }
    }
}
