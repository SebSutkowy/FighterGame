using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;     
using System.Collections.Generic;

namespace SchoolFighter
{
    internal class GameScene : Scene
    {
        Character _player { get; set; }
        List<AttacHitbox> _attackHitboxes = new List<AttacHitbox>();
        public GameScene() { }

        public override void LoadContent()
        {
            _player = new Character(Globals._playerTexture, new Vector2(0, 0), Color.White, 5.0f);
        }

        public override void Update() 
        {
            _player.Move();
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
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _player.Draw(spriteBatch);
            foreach(var hitbox in _attackHitboxes)
            {
                hitbox.Draw(spriteBatch);
            }
        }
    }
}
