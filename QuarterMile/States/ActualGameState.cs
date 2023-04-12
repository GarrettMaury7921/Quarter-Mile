using Devcade;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using QuarterMile.Characters;

namespace QuarterMile.States
{
    internal class ActualGameState : State
    {
        // Attributes
        KeyboardState previousKeyboardState;
        Inventory _inventory;
        private int centerX;
        private int centerY;

        // Button variables
        private bool blue1down;
        private bool blue2down;
        private bool blue3down;
        private bool blue4down;
        private bool reddown;
        private bool blue5down;
        private bool greendown;
        private bool whitedown;


        public ActualGameState(Game1 game, GraphicsDevice graphicsDevice, int preferredBackBufferWidth, 
            int preferredBackBufferHeight, ContentManager content, string state_name, Inventory inventory) 
            : base(game, graphicsDevice, preferredBackBufferWidth, preferredBackBufferHeight, content, state_name)
        {
            blue1down = false;
            blue2down = false;
            blue3down = false;
            blue4down = false;
            greendown = false;
            reddown = true;
            whitedown = false;
            blue5down = false;
            _inventory = inventory;

            centerX = (_preferredBackBufferWidth) / 2;
            centerY = (_preferredBackBufferHeight) / 2;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D main_menu)
        {
        }

        public override void PostUpdate(GameTime gameTime)
        {
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();

            CheckButtons(currentKeyboardState);

            previousKeyboardState = currentKeyboardState;
        }

        // Other Methods
        private static void ChangeMenuBackground(Texture2D background)
        {
            Game1.main_menu = background;
        }
        private void CheckButtons(KeyboardState currentKeyboardState)
        {
            if (currentKeyboardState.IsKeyDown(Keys.Z) || Input.GetButtonDown(1, Input.ArcadeButtons.B1)
                || Input.GetButtonDown(2, Input.ArcadeButtons.B1))
            {
                blue1down = true;
            }
            else if (previousKeyboardState.IsKeyDown(Keys.Z) || Input.GetButtonUp(1, Input.ArcadeButtons.B1)
                || Input.GetButtonUp(2, Input.ArcadeButtons.B1))
            {
                blue1down = false;
            }

            if (currentKeyboardState.IsKeyDown(Keys.X) || Input.GetButtonDown(1, Input.ArcadeButtons.B2)
                || Input.GetButtonDown(2, Input.ArcadeButtons.B2))
            {
                blue2down = true;
            }
            else if (previousKeyboardState.IsKeyDown(Keys.X) || Input.GetButtonUp(1, Input.ArcadeButtons.B2)
                || Input.GetButtonUp(2, Input.ArcadeButtons.B2))
            {
                blue2down = false;
            }

            if (currentKeyboardState.IsKeyDown(Keys.C) || Input.GetButtonDown(1, Input.ArcadeButtons.B3)
                || Input.GetButtonDown(2, Input.ArcadeButtons.B3))
            {
                blue3down = true;
            }
            else if (previousKeyboardState.IsKeyDown(Keys.C) || Input.GetButtonUp(1, Input.ArcadeButtons.B3)
                || Input.GetButtonUp(2, Input.ArcadeButtons.B3))
            {
                blue3down = false;
            }

            if (currentKeyboardState.IsKeyDown(Keys.V) || Input.GetButtonDown(1, Input.ArcadeButtons.B4)
                || Input.GetButtonDown(2, Input.ArcadeButtons.B4))
            {
                blue4down = true;
            }
            else if (previousKeyboardState.IsKeyDown(Keys.V) || Input.GetButtonUp(1, Input.ArcadeButtons.B4)
                || Input.GetButtonUp(2, Input.ArcadeButtons.B4))
            {
                blue4down = false;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Q) || Input.GetButtonDown(1, Input.ArcadeButtons.A1)
                || Input.GetButtonDown(2, Input.ArcadeButtons.A1))
            {
                reddown = true;
            }
            else if (previousKeyboardState.IsKeyDown(Keys.Q) || Input.GetButtonUp(1, Input.ArcadeButtons.A1)
                || Input.GetButtonUp(2, Input.ArcadeButtons.A1))
            {
                reddown = false;
            }

            if (currentKeyboardState.IsKeyDown(Keys.W) || Input.GetButtonDown(1, Input.ArcadeButtons.A2)
                || Input.GetButtonDown(2, Input.ArcadeButtons.A2))
            {
                blue5down = true;
            }
            else if (previousKeyboardState.IsKeyDown(Keys.W) || Input.GetButtonUp(1, Input.ArcadeButtons.A2)
                || Input.GetButtonUp(2, Input.ArcadeButtons.A2))
            {
                blue5down = false;
            }

            if (currentKeyboardState.IsKeyDown(Keys.E) || Input.GetButtonDown(1, Input.ArcadeButtons.A3)
                || Input.GetButtonDown(2, Input.ArcadeButtons.A3))
            {
                greendown = true;
            }
            else if (previousKeyboardState.IsKeyDown(Keys.E) || Input.GetButtonUp(1, Input.ArcadeButtons.A3)
                || Input.GetButtonUp(2, Input.ArcadeButtons.A3))
            {
                greendown = false;
            }

            if (currentKeyboardState.IsKeyDown(Keys.R) || Input.GetButtonDown(1, Input.ArcadeButtons.A4)
                || Input.GetButtonDown(2, Input.ArcadeButtons.A4))
            {
                whitedown = true;
            }
            else if (previousKeyboardState.IsKeyDown(Keys.R) || Input.GetButtonUp(1, Input.ArcadeButtons.A4)
                || Input.GetButtonUp(2, Input.ArcadeButtons.A4))
            {
                whitedown = false;
            }
        } // CheckButtons Method


    }
}
