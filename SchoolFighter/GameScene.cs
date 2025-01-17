using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SchoolFighter
{
    public class GameScene : Scene
    {
        Character _player { get; set; }
        public Character _enemy { get; set; }
        List<AttacHitbox> _attackHitboxes = new List<AttacHitbox>();
        public GameScene() { }
        MovementAI botMove;

        public override void LoadContent()
        {
            _player = new Character(Globals._playerTexture, new Vector2(0, 0), Color.White, 5.0f, "right");
            _enemy = new Character(Globals._playerTexture, new Vector2(400, 0), Color.White, 100f, "left");
            botMove = new MovementAI();
        }

        public override void Update(GameTime gameTime) 
        {

            _player.Update(true);
            _enemy.Update(false);
            AttacHitbox currentHitbox = _player.Attack();
            if(currentHitbox != null)
            {
                _attackHitboxes.Add(currentHitbox);
            }
            for(int i = _attackHitboxes.Count - 1; i >= 0; i--)
            {
                currentHitbox = _attackHitboxes[i];
                currentHitbox.Update();
                if(currentHitbox.Lifespan <= 0)
                {
                    _attackHitboxes.Remove(currentHitbox);
                }
            }


            botMove.Direction(_player, _enemy, 3f);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _player.Draw(spriteBatch);
            _enemy.Draw(spriteBatch);
            foreach(var hitbox in _attackHitboxes)
            {
                hitbox.Draw(spriteBatch);
            }
        }
    }
}
