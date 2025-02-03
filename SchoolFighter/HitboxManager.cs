using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SchoolFighter
{
    static class HitboxManager
    {
        public static List<AttackHitbox> Hitboxes = new List<AttackHitbox>();

        public static void Update()
        {
            AttackHitbox currentHitbox;
            for(int i = Hitboxes.Count - 1; i >= 0; i--)
            {
                currentHitbox = Hitboxes[i];
                if (currentHitbox != null)
                {
                    currentHitbox.Update();
                    if(currentHitbox.Lifespan <= 0)
                    {
                        Hitboxes.Remove(currentHitbox);
                    }
                }
            }
        }

        public static Tuple<int, Directions> CheckCollisions(Sprite player, int team)
        {
            AttackHitbox currentHitbox;
            for(int i = Hitboxes.Count - 1; i >= 0; i--)
            {
                currentHitbox = Hitboxes[i];
                if (currentHitbox.CheckCollision(player) && currentHitbox.Team != team)
                {
                    Hitboxes.Remove(currentHitbox);
                    return new Tuple<int, Directions>(currentHitbox.Damage, currentHitbox.Direction);
                }
            }
            return new Tuple<int, Directions>(0, Directions.None);
        }

        public static void AddHitbox(AttackHitbox hitbox)
        {
            if(hitbox != null)
            {
                Hitboxes.Add(hitbox);
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach(AttackHitbox hitbox in Hitboxes)
            {
                Debug.WriteLine($"{hitbox.RelativePosition}; {hitbox.Hitbox.X}, {hitbox.Hitbox.Y}");
                hitbox.Draw(spriteBatch);
            }
        }
    }
}
