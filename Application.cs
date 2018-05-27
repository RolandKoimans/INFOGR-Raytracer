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
            if (state.IsKeyDown(Key.Left))
            {
                camera.cameraPos.X++;
            }

            else if (state.IsKeyDown(Key.Right))
            {
                camera.cameraPos.X--;
            }

            else if (state.IsKeyDown(Key.Up))
            {
                camera.cameraPos.Y++;
            }

            else if (state.IsKeyDown(Key.Down))
            {
                camera.cameraPos.Y--;
            }
        }
    }
}
