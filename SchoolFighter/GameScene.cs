using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SchoolFighter
{
    internal class GameScene : Scene
    {
        Character _player { get; set; }
        Character _enemy { get; set; }
        HealthBar _playerHealthBar { get; set; }
        HealthBar _enemyHealthBar { get; set; }
        
        public GameScene() { }

        public override void LoadContent()
        {
            _player = new Character(Globals._playerTexture, Vector2.Zero, Color.White, 300.0f, Vector2.Zero, 100, 10, 1);
            _enemy = new Character(Globals._playerTexture, new Vector2(800, 0), Color.White, 300.0f, Vector2.Zero, 100, 10, 2);
            _playerHealthBar = new HealthBar(_player.Health, Vector2.Zero, new Vector2(Globals.winWidth * 2 / 5, Globals.winHeight / 12), Directions.Left);
            _enemyHealthBar = new HealthBar(_enemy.Health, new Vector2(Globals.winWidth * 3/5, 0), new Vector2(Globals.winWidth * 2 / 5, Globals.winHeight / 12), Directions.Right);
        }

        public override void Update() 
        {
            _player.Update();
            _enemy.Update(false);
            _playerHealthBar.Update(_player.Health);
            _enemyHealthBar.Update(_enemy.Health);
            HitboxManager.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _player.Draw(spriteBatch);
            _enemy.Draw(spriteBatch);
            _playerHealthBar.Draw(spriteBatch);
            _enemyHealthBar.Draw(spriteBatch);
            HitboxManager.Draw(spriteBatch);
        }
    }
}
