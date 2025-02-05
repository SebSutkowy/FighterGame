using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SchoolFighter
{
    internal class VictoryScene : Scene
    {
        private string Winner = "";
        private SpriteFont font1;
        public VictoryScene() 
        { }

        public override void LoadContent()
        {
            font1 = Globals.Content.Load<SpriteFont>("WinnerText");
        }

        public override void Update()
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font1, Winner, new Vector2(Globals.winWidth/2, Globals.winHeight/2), Color.White, 0,  font1.MeasureString(Winner)/2, 1.0f, SpriteEffects.None, 0.5f);
        }

        public override void AddData(string additionalData="")
        {
            if (additionalData != "-1")
                Winner = $"The winning team is TEAM {additionalData}";
            else
                Winner = $"TIE";
        }
    }
}
