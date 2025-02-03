using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace SchoolFighter
{
    internal class GameScene : Scene
    {
        Character _player { get; set; }
        Character _enemy { get; set; }
        public GameScene() { }

        public override void LoadContent()
        {
            _player = new Character(Globals._playerTexture, Vector2.Zero, Color.White, 300.0f, Vector2.Zero, 100, 10, 1);
            _enemy = new Character(Globals._playerTexture, new Vector2(800, 0), Color.White, 300.0f, Vector2.Zero, 100, 10, 2);
        }

        public override void Update() 
        {
            _player.Update();
            _enemy.Update(false);
            HitboxManager.Update();
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _player.Draw(spriteBatch);
            _enemy.Draw(spriteBatch);
            HitboxManager.Draw(spriteBatch);
        }
    }
}
