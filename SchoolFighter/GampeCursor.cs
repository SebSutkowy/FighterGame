using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class GamepadCursor
{
    private Vector2 position;
    private float speed;
    private Texture2D cursorTexture;
    private Vector2 origin;
    private GraphicsDevice graphicsDevice;

    public GamepadCursor(GraphicsDevice graphicsDevice, Texture2D cursorTexture, Vector2 startPosition, float speed = 300f)
    {
        this.graphicsDevice = graphicsDevice;
        this.cursorTexture = cursorTexture;
        this.position = startPosition;
        this.speed = speed;
        this.origin = new Vector2(cursorTexture.Width / 2, cursorTexture.Height / 2);
    }

    public void Update(GameTime gameTime)
    {
        GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);

        if (gamePadState.IsConnected)
        {
            Vector2 input = gamePadState.ThumbSticks.Left;
            input.Y *= -1; // Invert Y because MonoGame's Y-axis is flipped

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += input * speed * deltaTime;

            // Clamp within screen bounds
            position.X = MathHelper.Clamp(position.X, 0, graphicsDevice.Viewport.Width);
            position.Y = MathHelper.Clamp(position.Y, 0, graphicsDevice.Viewport.Height);

            // Simulate a mouse click
            if (gamePadState.Buttons.A == ButtonState.Pressed)
            {
                SimulateMouseClick();
            }
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(cursorTexture, position, null, Color.White, 0f, origin, 1f, SpriteEffects.None, 0f);
    }

    private void SimulateMouseClick()
    {
        Mouse.SetPosition((int)position.X, (int)position.Y);
    }
}
