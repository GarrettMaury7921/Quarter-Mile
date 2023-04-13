using Devcade;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using QuarterMile.Characters;
using QuarterMile.Controls;
using System;
using System.Diagnostics;

namespace QuarterMile.States
{
    internal class ActualGameState : State
    {
        // Attributes
        private DialogueBox dialogueBox;
        private KeyboardState previousKeyboardState;
        private Inventory _inventory;
        private int centerX;
        private int centerY;
        private Texture2D gameBackground;
        private Texture2D nrhbackground;
        private NRH_Freshman _freshman;
        private Apex_Upperclassman _upperclassman;
        private Song the_dalles;
        private Texture2D red_button;
        private Texture2D blue_button;
        private Texture2D dark_blue_button;
        private Texture2D green_button;
        private Texture2D white_button;
        private Texture2D yellow_button;
        private Texture2D dialogueBackground;
        private Texture2D skateboard;
        private Texture2D sign;
        private Texture2D ox;
        private Texture2D ethan;
        private Texture2D bear;

        // Button variables
        private bool blue1down;
        private bool blue2down;
        private bool blue3down;
        private bool blue4down;
        private bool reddown;
        private bool blue5down;
        private bool greendown;
        private bool whitedown;

        // Game variables
        private bool inGame;
        private bool nrh;
        private int playerClass;
        private bool menu;
        private bool mediaChecker;


        public ActualGameState(Game1 game, GraphicsDevice graphicsDevice, int preferredBackBufferWidth, 
            int preferredBackBufferHeight, ContentManager content, string state_name, Inventory inventory,
            NRH_Freshman freshman, Apex_Upperclassman upperclassman) 
            : base(game, graphicsDevice, preferredBackBufferWidth, preferredBackBufferHeight, content, state_name)
        {

            // LOAD ASSETS
            gameBackground = _content.Load<Texture2D>("Game_Assets/trail_Background");
            nrhbackground = _content.Load<Texture2D>("Game_Assets/nrh");
            the_dalles = _content.Load<Song>("Songs/the_dalles");
            // Load Assets
            red_button = _content.Load<Texture2D>("Game_Assets/red");
            blue_button = _content.Load<Texture2D>("Game_Assets/blue");
            dark_blue_button = _content.Load<Texture2D>("Game_Assets/dark_blue");
            green_button = _content.Load<Texture2D>("Game_Assets/green");
            white_button = _content.Load<Texture2D>("Game_Assets/white");
            yellow_button = _content.Load<Texture2D>("Game_Assets/yellow");
            dialogueBackground = _content.Load<Texture2D>("Menu_Assets/Dialogue_Background");
            ethan = _content.Load<Texture2D>("Game_Assets/ethan");

            // Attributes
            blue1down = false;
            blue2down = false;
            blue3down = false;
            blue4down = false;
            greendown = false;
            reddown = true;
            whitedown = false;
            blue5down = false;
            menu = false;
            mediaChecker = true;
            _inventory = inventory;
            _freshman = freshman;
            _upperclassman = upperclassman;

            centerX = (_preferredBackBufferWidth) / 2;
            centerY = (_preferredBackBufferHeight) / 2;

            dialogueBox = new DialogueBox(_content);
            nrh = true;

            // Check what class
            if (freshman != null)
            {
                playerClass = 1;
                //Debug.WriteLine("fresh not null");
            }
            if (upperclassman != null)
            {
                playerClass = 2;
                //Debug.WriteLine("upper not null");
            }
        } // Actual Game State Constructor

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D main_menu)
        {
            if (nrh)
            {
                spriteBatch.Draw(nrhbackground, new Rectangle(0, 0, _preferredBackBufferWidth, _preferredBackBufferHeight),
                new Rectangle(0, 0, 1080, 2560), Color.White);

                dialogueBox.DrawDialogueBlack(spriteBatch, "  Nathaniel Rochester Hall\n     "
                    + _inventory.month
                    + " "
                    + _inventory.day
                    + ", "
                    + _inventory.year,
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.7f)));

                dialogueBox.DrawDialogueBlack(spriteBatch, "    Press RED to continue",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.9f)));
            }
            if (menu)
            {
                dialogueBox.DrawDialogue(spriteBatch, " Quarter Mile\n"
                    + _inventory.month
                    + " "
                    + _inventory.day
                    + ", "
                    + _inventory.year,
                    new Vector2(centerX - (centerX / 2.5f), centerY - (centerY / 1.5f)));
                dialogueBox.DrawDialogue(spriteBatch, "Weather: " + _inventory.weather,
                    new Vector2(centerX - (centerX / 1.2f), centerY - (centerY / 3f)));
                dialogueBox.DrawDialogue(spriteBatch, "Health: " + _inventory.ReportHealth(),
                    new Vector2(centerX - (centerX / 1.2f), centerY - (centerY / 4f)));
                dialogueBox.DrawDialogue(spriteBatch, "Pace: " + _inventory.pace,
                    new Vector2(centerX - (centerX / 1.2f), centerY - (centerY / 6f)));
                dialogueBox.DrawDialogue(spriteBatch, "Rations: " + _inventory.rations,
                    new Vector2(centerX - (centerX / 1.2f), centerY - (centerY / 12f)));

                dialogueBox.DrawDialogue(spriteBatch, "You may:\n",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.1f)));
                dialogueBox.DrawDialogueWithIcon(spriteBatch, "     1. Continue on trail",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.2f)), red_button);
                dialogueBox.DrawDialogueWithIcon(spriteBatch, "     2. Up the pace",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.3f)), blue_button);
                dialogueBox.DrawDialogueWithIcon(spriteBatch, "     3. Lower the pace",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.4f)), green_button);
                dialogueBox.DrawDialogueWithIcon(spriteBatch, "     4. Up the rations",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.5f)), white_button);
                dialogueBox.DrawDialogueWithIcon(spriteBatch, "     5. Lower the rations (B1)",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.6f)), dark_blue_button);
                dialogueBox.DrawDialogueWithIcon(spriteBatch, "     6. Stop to rest (B2)",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.7f)), dark_blue_button);
                dialogueBox.DrawDialogue(spriteBatch, "What is your choice?",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.9f)));

            }
            if (inGame)
            {
                spriteBatch.Draw(gameBackground, new Rectangle(0, 0, _preferredBackBufferWidth, _preferredBackBufferHeight),
                new Rectangle(0, 0, 1080, 2560), Color.White);

                dialogueBox.DrawDialogueWithIcon(spriteBatch, "   Size up the situation",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.9f)), blue_button);
            }

        }

        public override void PostUpdate(GameTime gameTime)
        {
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();

            CheckButtons(currentKeyboardState);

            if (nrh && mediaChecker)
            {
                MediaPlayer.Play(the_dalles);
                mediaChecker = false;
            }
            if (nrh && !reddown)
            {
                MediaPlayer.Stop();
                nrh = false;
                reddown = true;
                menu = true;
            }
            if (menu && !reddown)
            {
                blue5down = true;
                reddown = true;
                menu = false;
                inGame = true;
            }
            if (inGame)
            {
                if (!blue5down)
                {
                    greendown = true;
                    inGame = false;
                    menu = true;
                }
            }

            previousKeyboardState = currentKeyboardState;
        }

        // Other Methods
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
