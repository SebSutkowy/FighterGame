using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolFighter
{
    public static class Inputs
    {
        public static Vector2 Direction { get; private set; }
        public static bool IsJumping { get; private set; }
        public static bool IsCrouching { get; private set; }
        public static bool IsLightPunch { get; private set; }
        public static bool IsMediumHeavyPunch { get; private set; }
        public static bool IsHeavyPunch { get; private set; }
        public static bool IsLightMediumKick { get; private set; }
        public static bool IsMediumKick { get; private set; }
        public static bool IsHeavyKick { get; private set; }

        private static KeyboardState currentKeyboardState;
        private static KeyboardState previousKeyboardState;

        public static void Update()
        {
            currentKeyboardState = Keyboard.GetState();

            // Reset inputs
            Direction = Vector2.Zero;
            IsJumping = false;
            IsCrouching = false;
            IsLightPunch = false;
            IsMediumHeavyPunch = false;
            IsHeavyPunch = false;
            IsLightMediumKick = false;
            IsMediumKick = false;
            IsHeavyKick = false;

            // Handle movement keys
            if (currentKeyboardState.IsKeyDown(Keys.A))
                Direction += new Vector2(-1, 0);

            if (currentKeyboardState.IsKeyDown(Keys.D))
                Direction += new Vector2(1, 0);

            // Handle jump (triggered on key press)
            if (IsKeyJustPressed(Keys.Space))
                IsJumping = true;

            // Handle crouch
            if (currentKeyboardState.IsKeyDown(Keys.S))
                IsCrouching = true;

            // Handle attack keys (triggered on key press)
            if (IsKeyJustPressed(Keys.J))
                IsLightPunch = true;

            if (IsKeyJustPressed(Keys.K))
                IsMediumHeavyPunch = true;

            if (IsKeyJustPressed(Keys.L))
                IsHeavyPunch = true;

            if (IsKeyJustPressed(Keys.U))
                IsLightMediumKick = true;

            if (IsKeyJustPressed(Keys.I))
                IsMediumKick = true;

            if (IsKeyJustPressed(Keys.O))
                IsHeavyKick = true;

            // Store the current state as previous for the next frame
            previousKeyboardState = currentKeyboardState;
        }

        private static bool IsKeyJustPressed(Keys key)
        {
            return currentKeyboardState.IsKeyDown(key) && !previousKeyboardState.IsKeyDown(key);
        }
    }
}