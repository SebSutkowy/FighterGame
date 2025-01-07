

using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SchoolFighter
{
    internal static class SceneManager
    {
        public static Scene CurrentScene { get; set; }
        public static Scene PreviousScene { get; set; }
        public static Dictionary<string, Scene> Scenes { get; set; }

        public static void LoadContent()
        {
            if(CurrentScene != null)
            {
                CurrentScene.LoadContent();
            }
        }

        public static void Update()
        {
            if(CurrentScene != null)
            {
                CurrentScene.Update();
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            if (CurrentScene != null)
            {
                CurrentScene.Draw(spriteBatch);
            }
        }

        public static void RevertScene()
        {
            Scene temp = CurrentScene;
            CurrentScene = PreviousScene;
            PreviousScene = temp;
        }
    }
}
