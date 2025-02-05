

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

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

        public static void ChangeScene(string sceneName, string additionalData="")
        {
            if(Scenes.ContainsKey(sceneName))
            {
                PreviousScene = CurrentScene;
                CurrentScene = Scenes[sceneName];
                LoadContent();
                Debug.WriteLine($"Changed to Scene {sceneName}");
            }
            else
            {
                Debug.WriteLine($"Error: Scene {sceneName} not found");
            }
            if(sceneName == "Victory")
            {
                Scenes[sceneName].AddData(additionalData);
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
