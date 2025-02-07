using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace SchoolFighter
{
    public class AnimationManager
    {
        private readonly Dictionary<string, Animation> _animations = new();
        private Animation _currentAnimation;
        private int _currentRow;

        public void AddAnimation(string name, Animation animation, int row)
        {
            _animations[name] = animation;
            if (_currentAnimation == null)
            {
                _currentAnimation = animation; // Set default animation
                _currentRow = row;
            }
        }

        public void Update(string animationName, int row)
        {
            if (_animations.ContainsKey(animationName))
            {
                if (_currentAnimation != _animations[animationName])
                {
                    _currentAnimation = _animations[animationName];
                    _currentAnimation.Reset();
                }
                _currentRow = row;
            }

            _currentAnimation?.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, float scale)
        {
            _currentAnimation?.Draw(spriteBatch, position, _currentRow, scale);
        }
    }
}
