using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Drawing;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace SchoolFighter
{
     class Tile
    {
        private int size;
        private Vector2 position;
        private Texture2D pixel;
        private Rectangle rectangle;

        public Tile(int size, Vector2 position, Texture2D pixel)
        {

            this.size = size;
            this.position = position;
            this.pixel = pixel;
            pixel = Globals.Content.Load<Texture2D>("Tile");
            this.Hitbox = new Rectangle((int)position.X, (int)position.Y, size / 2, size / 2);
        }

        public Rectangle Hitbox { get; internal set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw        (pixel, position,rectangle , Color.White, 0, Vector2.Zero, size / 2, SpriteEffects.None, 0);
        }
    }
}
