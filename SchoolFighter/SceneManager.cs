

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SchoolFighter
{
    public static class SceneManager
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

        public static void Update(GameTime gameTime)
        {
            if(CurrentScene != null)
            {
                CurrentScene.Update(gameTime);
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
