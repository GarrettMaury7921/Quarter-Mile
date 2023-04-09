using Devcade;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using QuarterMile.Controls;
using System.Diagnostics;

namespace QuarterMile.States
{
    public class PreGameState : State
    {
        // Attributes
        private KeyboardState previousKeyboardState;
        private Texture2D red_button;
        private Texture2D blue_button;
        private Texture2D dark_blue_button;
        private Texture2D green_button;
        private Texture2D white_button;
        private Texture2D yellow_button;
        private Texture2D dialogueBackground;
        private DialogueBox dialogueBox;
        private int centerX;
        private int centerY;
        private bool start;

        // Button variables
        private bool blue1down;
        private bool blue2down;
        private bool blue3down;
        private bool blue4down;
        private bool reddown;
        private bool blue5down;
        private bool greendown;
        private bool whitedown;

        // Game bools
        private bool Learn;

        public PreGameState(Game1 game, GraphicsDevice graphicsDevice, int PreferredBackBufferWidth, int PreferredBackBufferHeight, 
            ContentManager content, string _state_name) :
            base(game, graphicsDevice, PreferredBackBufferWidth, PreferredBackBufferHeight, content, _state_name) {

            centerX = (_preferredBackBufferWidth) / 2;
            centerY = (_preferredBackBufferHeight) / 2;

            // LOAD ASSETS
            red_button = _content.Load<Texture2D>("Game_Assets/red");
            blue_button = _content.Load<Texture2D>("Game_Assets/blue");
            dark_blue_button = _content.Load<Texture2D>("Game_Assets/dark_blue");
            green_button = _content.Load<Texture2D>("Game_Assets/green");
            white_button = _content.Load<Texture2D>("Game_Assets/white");
            yellow_button = _content.Load<Texture2D>("Game_Assets/yellow");
            dialogueBackground = _content.Load<Texture2D>("Menu_Assets/Dialogue_Background");
            ChangeMenuBackground(dialogueBackground);

            // Make Dialog Box
            dialogueBox = new DialogueBox(_content);

            // Starting variable
            start = true;
            blue1down = true;
            blue2down = true;
            blue3down = true;
            blue4down = true;
            reddown = true;
            blue5down = true;
            greendown = true;
            whitedown = true;
            Learn = false;

        } // PreGame State Constructor

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D background)
        {
            // Draw the main menu background
            spriteBatch.Draw(background, new Rectangle(0, 0, _preferredBackBufferWidth, _preferredBackBufferHeight),
                new Rectangle(0, 0, 1080, 2560), Color.White);

            if (start)
            {
                // Make Dialog
                dialogueBox.DrawDialogue(spriteBatch, "You may:",
                    new Vector2(centerX - (centerX / 1.2f), centerY - (centerY / 3f)));
                dialogueBox.DrawDialogueWithIcon(spriteBatch, "     Travel the Trail",
                    new Vector2(centerX - (centerX / 1.2f), centerY - (centerY / 4f)), red_button);
                dialogueBox.DrawDialogueWithIcon(spriteBatch, "     Learn about the Trail",
                    new Vector2(centerX - (centerX / 1.2f), centerY - (centerY / 6f)), blue_button);
                dialogueBox.DrawDialogueWithIcon(spriteBatch, "     Go back to menu",
                    new Vector2(centerX - (centerX / 1.2f), centerY - (centerY / 12f)), green_button);
            } // if statement
            else if (Learn)
            {
                dialogueBox.DrawDialogue(spriteBatch, "Quarter-mile or 1/4 mile may \n refer to:",
                    new Vector2(centerX - (centerX / 1.2f), centerY - (centerY / 3f)));
                dialogueBox.DrawDialogue(spriteBatch, "A dragstrip competition or \n vehicle test in motorsport, \n where cars or motorcycles \n " +
                    "compete for the shortest time \n from a standing start to the \n end of a straight 1/4 mile \n (0.40 km) track",
                    new Vector2(centerX - (centerX / 1.2f), centerY - (centerY / 6f)));
                dialogueBox.DrawDialogue(spriteBatch, "The 440-yard dash, a sprint \n footrace in track and field \n competition on a " +
                    "440 \n yards (1,320 ft; 400 m; 0.25 \n mi) oval",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.4f)));
            }

        } // Draw Method

        public override void Update(GameTime gameTime)
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();

            CheckButtons(currentKeyboardState);

            previousKeyboardState = currentKeyboardState;

            if (!blue5down && start)
            {
                blue5down = true;
                start = false; // starting screen
                Learn = true; // Learn about the trail screen
            }
        } // Update Method

        public override void PostUpdate(GameTime gameTime)
        {
        }

        // OTHER METHODS
        private static void ChangeMenuBackground(Texture2D background)
        {
            Game1.main_menu = background;
        }

        private void CheckButtons(KeyboardState currentKeyboardState)
        {
            if (currentKeyboardState.IsKeyDown(Keys.Z) || Input.GetButton(1, Input.ArcadeButtons.B1))
            {
                blue1down = true;
            }
            else if (previousKeyboardState.IsKeyDown(Keys.Z) || Input.GetButtonUp(1, Input.ArcadeButtons.B1))
            {
                blue1down = false;
            }

            if (currentKeyboardState.IsKeyDown(Keys.X) || Input.GetButton(1, Input.ArcadeButtons.B2))
            {
                blue2down = true;
            }
            else if (previousKeyboardState.IsKeyDown(Keys.X) || Input.GetButtonUp(1, Input.ArcadeButtons.B2))
            {
                blue2down = false;
            }

            if (currentKeyboardState.IsKeyDown(Keys.C) || Input.GetButton(1, Input.ArcadeButtons.B3))
            {
                blue3down = true;
            }
            else if (previousKeyboardState.IsKeyDown(Keys.C) || Input.GetButtonUp(1, Input.ArcadeButtons.B3))
            {
                blue3down = false;
            }

            if (currentKeyboardState.IsKeyDown(Keys.V) || Input.GetButton(1, Input.ArcadeButtons.B4))
            {
                blue4down = true;
            }
            else if (previousKeyboardState.IsKeyDown(Keys.V) || Input.GetButtonUp(1, Input.ArcadeButtons.B4))
            {
                blue4down = false;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Q) || Input.GetButton(1, Input.ArcadeButtons.A1))
            {
                reddown = true;
            }
            else if (previousKeyboardState.IsKeyDown(Keys.Q) || Input.GetButtonUp(1, Input.ArcadeButtons.A1))
            {
                reddown = false;
            }

            if (currentKeyboardState.IsKeyDown(Keys.W) || Input.GetButton(1, Input.ArcadeButtons.A2))
            {
                blue5down = true;
            }
            else if (previousKeyboardState.IsKeyDown(Keys.W) || Input.GetButtonUp(1, Input.ArcadeButtons.A2))
            {
                blue5down = false;
            }

            if (currentKeyboardState.IsKeyDown(Keys.E) || Input.GetButton(1, Input.ArcadeButtons.A3))
            {
                greendown = true;
            }
            else if (previousKeyboardState.IsKeyDown(Keys.E) || Input.GetButtonUp(1, Input.ArcadeButtons.A3))
            {
                greendown = false;
            }

            if (currentKeyboardState.IsKeyDown(Keys.R) || Input.GetButton(1, Input.ArcadeButtons.A4))
            {
                whitedown = true;
            }
            else if (previousKeyboardState.IsKeyDown(Keys.R) || Input.GetButtonUp(1, Input.ArcadeButtons.A4))
            {
                whitedown = false;
            }
        } // CheckButtons Method

    }
}
