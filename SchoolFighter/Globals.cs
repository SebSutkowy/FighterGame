using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace SchoolFighter
{
    internal static class Globals
    {
        public static Texture2D _playerTexture; // blank texture
        public static float deltaTime;
        public static int winWidth = 1920;
        public static int winHeight = 1080; // window dimensions
        public static float g = 60.0f; // gravity
        public static KeyboardState keys, prevKeys; // keys and previously pressed keys to check if a key was pressed but not held down
        public static GamePadState controller, prevController;
        public static ContentManager Content;

        public static bool IsKeyPressed(Keys key)
        {
            // will check if a key was pressed but not if it was held down
            if (keys.IsKeyDown(key) && !prevKeys.IsKeyDown(key))
                return true;
            return false;
        }

        public static void UpdateTime(GameTime gt)
        {
            deltaTime = (float)gt.ElapsedGameTime.TotalSeconds;
            // Debug.WriteLine($"{1.0f / gt.ElapsedGameTime.TotalSeconds}FPS");
        }
    }
}
