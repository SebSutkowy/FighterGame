using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System.Collections.Generic;

namespace SchoolFighter
{
    internal class GameScene : Scene
    {
        Character _player { get; set; }
        Character _enemy { get; set; }
        HealthBar _playerHealthBar { get; set; }
        HealthBar _enemyHealthBar { get; set; }
        public int Timer { get; set; }
        public string TimerText { get; set; }
        public SpriteFont TimerFont { get; set; }
        public Vector2 TimerFontOrigin;
        
        public GameScene() { }

        public override void LoadContent()
        {
            _player = new Character(Globals._playerTexture[0], Vector2.Zero, Color.White, 300.0f, Vector2.Zero, 100, 10, 1, Globals._playerTexture);
            _enemy = new Character(Globals._playerTexture[0], new Vector2(800, 0), Color.White, 300.0f, Vector2.Zero, 100, 10, 2, Globals._playerTexture);
            _enemy.SetBinds(
                new Dictionary<string, Microsoft.Xna.Framework.Input.Keys>()
                {
                    {"Move left", Microsoft.Xna.Framework.Input.Keys.J },
                    {"Move right", Microsoft.Xna.Framework.Input.Keys.L },
                    {"Jump", Microsoft.Xna.Framework.Input.Keys.I },
                    {"Crouch", Microsoft.Xna.Framework.Input.Keys.K },
                    {"Punch", Microsoft.Xna.Framework.Input.Keys.U }
                }
            );
            _playerHealthBar = new HealthBar(_player.Health, Vector2.Zero, new Vector2(Globals.winWidth * 2 / 5, Globals.winHeight / 12), Directions.Right);
            _enemyHealthBar = new HealthBar(_enemy.Health, new Vector2(Globals.winWidth * 3/5, 0), new Vector2(Globals.winWidth * 2 / 5, Globals.winHeight / 12), Directions.Left);
            Timer = 300 * 60;
            TimerFont = Globals.Content.Load<SpriteFont>("TimerFont");
        }

        public override void Update() 
        {
            Timer--;
            TimerText = $"{Timer / 60}";
            TimerFontOrigin = TimerFont.MeasureString(TimerText)/2;
            _player.Update();
            _enemy.Update();
            _playerHealthBar.Update(_player.Health);
            _enemyHealthBar.Update(_enemy.Health);
            int winner = CheckWin();
            Debug.WriteLine($"Winner: {winner}");
            if(winner != 0)
            {
                SceneManager.ChangeScene("Victory", $"{winner}");
            }
            HitboxManager.Update();
        }

        public int CheckWin()
        {
            Debug.WriteLine($"Player health: {_player.Health}, Enemy health: {_enemy.Health}");
            if (_player.Health <= 0)
                return 2;
            if (_enemy.Health <= 0)
                return 1;
            if (Timer <= 0)
                return -1;
            return 0;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, Globals.winWidth, Globals.winHeight), Color.White);
            _player.Draw(spriteBatch);
            _enemy.Draw(spriteBatch);
            _playerHealthBar.Draw(spriteBatch);
            _enemyHealthBar.Draw(spriteBatch);
            spriteBatch.DrawString(TimerFont, TimerText, new Vector2(Globals.winWidth / 2, 50), Color.White, 0, TimerFontOrigin, 1.0f, SpriteEffects.None, 0.5f);
            HitboxManager.Draw(spriteBatch);
        }

        public override void AddData(string additionalData="")
        {
            return;
        }
    }
}
