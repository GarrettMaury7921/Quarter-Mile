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
using System.Threading;

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
        private Texture2D player;
        private Texture2D brick_wall;
        private Texture2D gol;

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
        public static bool statusMessage;
        private bool letter;
        private bool win;

        // Timer
        private Timer timer;
        private double offset;


        public ActualGameState(Game1 game, GraphicsDevice graphicsDevice, int preferredBackBufferWidth, 
            int preferredBackBufferHeight, ContentManager content, string state_name, Inventory inventory,
            NRH_Freshman freshman, Apex_Upperclassman upperclassman) 
            : base(game, graphicsDevice, preferredBackBufferWidth, preferredBackBufferHeight, content, state_name)
        {

            // LOAD ASSETS
            gameBackground = _content.Load<Texture2D>("Game_Assets/trail_background");
            nrhbackground = _content.Load<Texture2D>("Game_Assets/nrh");
            the_dalles = _content.Load<Song>("Songs/the_dalles");
            player = _content.Load<Texture2D>("Game_Assets/player");
            brick_wall = _content.Load<Texture2D>("Game_Assets/brick_game_background");
            gol = _content.Load<Texture2D>("Game_Assets/golisano");

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
            blue2down = true;
            blue3down = false;
            blue4down = false;
            greendown = false;
            reddown = true;
            whitedown = false;
            blue5down = false;
            menu = false;
            mediaChecker = true;
            statusMessage = false;
            letter = false;
            win = false;
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

            // Timer
            timer = new Timer(TimerCallback, null, 0, 5000);

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
                dialogueBox.DrawDialogueWithIcon(spriteBatch, "     2. Lower the pace",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.3f)), blue_button);
                dialogueBox.DrawDialogueWithIcon(spriteBatch, "     3. Up the pace",
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

                spriteBatch.Draw(brick_wall, new Rectangle(0, 0, _preferredBackBufferWidth, _preferredBackBufferHeight),
                new Rectangle(0, 0, 1080, 2560), Color.White);

                spriteBatch.Draw(gol, new Rectangle((int)offset, 0, _preferredBackBufferWidth, _preferredBackBufferHeight),
                new Rectangle(0, 0, 1080, 2560), Color.White);

                spriteBatch.Draw(player, new Rectangle(
                    (int)(centerX + (centerX * 0.5)), // X position of the destination rectangle
                    (int)(centerY - (centerY * 0.55f)), // Y position of the destination rectangle
                    (int)(_preferredBackBufferWidth * 0.2f), // Width of the destination rectangle
                    (int)(_preferredBackBufferHeight * 0.2f)), // Height of the destination rectangle
                    Color.White);

                dialogueBox.DrawDialogueBlack(spriteBatch, ""
                    + _inventory.month
                    + " "
                    + _inventory.day
                    + ", "
                    + _inventory.year,
                    new Vector2(centerX - (centerX / 2f), centerY + (centerY * 0f)));
                dialogueBox.DrawDialogueBlack(spriteBatch, "Weather: " + _inventory.weather,
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.1f)));
                dialogueBox.DrawDialogueBlack(spriteBatch, "Health: " + _inventory.ReportHealth(),
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.2f)));
                dialogueBox.DrawDialogueBlack(spriteBatch, "Pace: " + _inventory.pace,
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.3f)));
                dialogueBox.DrawDialogueBlack(spriteBatch, "Rations: " + _inventory.rations,
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.4f)));

                dialogueBox.DrawDialogueWithIcon(spriteBatch, "   Size up the situation",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.9f)), blue_button);
            } // in game

            if (statusMessage)
            {
                spriteBatch.Draw(gameBackground, new Rectangle(0, 0, _preferredBackBufferWidth, _preferredBackBufferHeight),
                new Rectangle(0, 0, 1080, 2560), Color.White);

                spriteBatch.Draw(brick_wall, new Rectangle(0, 0, _preferredBackBufferWidth, _preferredBackBufferHeight),
                new Rectangle(0, 0, 1080, 2560), Color.White);

                spriteBatch.Draw(gol, new Rectangle((int)offset, 0, _preferredBackBufferWidth, _preferredBackBufferHeight),
                new Rectangle(0, 0, 1080, 2560), Color.White);

                spriteBatch.Draw(player, new Rectangle(
                    (int)(centerX + (centerX * 0.5)), // X position of the destination rectangle
                    (int)(centerY - (centerY * 0.55f)), // Y position of the destination rectangle
                    (int)(_preferredBackBufferWidth * 0.2f), // Width of the destination rectangle
                    (int)(_preferredBackBufferHeight * 0.2f)), // Height of the destination rectangle
                    Color.White);

                dialogueBox.DrawDialogueBlack(spriteBatch, _inventory.status,
            new Vector2(centerX - (centerX / 1.1f), centerY - (centerY * 0.2f)));
                
                dialogueBox.DrawDialogueBlack(spriteBatch, ""
                    + _inventory.month
                    + " "
                    + _inventory.day
                    + ", "
                    + _inventory.year,
                    new Vector2(centerX - (centerX / 2f), centerY + (centerY * 0f)));
                dialogueBox.DrawDialogueBlack(spriteBatch, "Weather: " + _inventory.weather,
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.1f)));
                dialogueBox.DrawDialogueBlack(spriteBatch, "Health: " + _inventory.ReportHealth(),
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.2f)));
                dialogueBox.DrawDialogueBlack(spriteBatch, "Pace: " + _inventory.pace,
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.3f)));
                dialogueBox.DrawDialogueBlack(spriteBatch, "Rations: " + _inventory.rations,
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.4f)));

                dialogueBox.DrawDialogue(spriteBatch, "    Press RED to continue",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.9f)));
            }
            if (win)
            {
                spriteBatch.Draw(player, new Rectangle(
                    (int)(centerX), // X position of the destination rectangle
                    (int)(centerY), // Y position of the destination rectangle
                    (int)(_preferredBackBufferWidth * 0.5f), // Width of the destination rectangle
                    (int)(_preferredBackBufferHeight * 0.5f)), // Height of the destination rectangle
                    Color.White);

                dialogueBox.DrawDialogue
                    (spriteBatch, "YOU FREAKIN WIN!",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.4f)));
            }

        } // draw

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
            if (menu && !blue5down)
            {
                blue5down = true;
                _inventory.ChangePace(1);
            }
            if (menu && !greendown)
            {
                greendown = true;
                _inventory.ChangePace(-1);
            }
            if (menu && !whitedown)
            {
                whitedown = true;
                _inventory.ChangeRations(1);
            }
            if (menu && !blue1down)
            {
                blue1down = true;
                _inventory.ChangeRations(-1);
            }
            if (menu && !blue2down)
            {
                blue2down = true;
                _inventory.Rest();
            }
            if (inGame)
            {
                if (_inventory.status != null)
                {
                    // Check for status message
                    foreach (char c in _inventory.status)
                    {
                        if (char.IsLetter(c))
                        {
                            letter = true;
                            break;
                        }
                    }
                }

                if (letter)
                {
                    statusMessage = true;
                    inGame = false;
                }

                offset += 0.02;
                // Debug.WriteLine(offset);

                if (!blue5down)
                {
                    greendown = true;
                    blue5down = true;
                    inGame = false;
                    menu = true;
                }
            } // inGame

            if (statusMessage)
            {
                if (!reddown)
                {
                    reddown = true;
                    letter = false;
                    _inventory.clearStatusMessage();
                    statusMessage = false;
                    inGame = true;
                }
            }


            if (menu || inGame || statusMessage)
            {
                _inventory.UpdateMonthAndDay(ref _inventory.month, ref _inventory.day, _inventory.year);
                _inventory.checkStats();
            }

            // Go through days
            if (offset % 10 == 0 && inGame)
            {
                _inventory.day++;
            }

            // winning
            if (offset > 270)
            {
                // YOU WIN
                win = true;
                menu = false;
                inGame = false;
                statusMessage = false;
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

        // Timer, called every x value
        private void TimerCallback(object state)
        {
            if (inGame)
            {
                _inventory.NextEvent();
            }
        } // timer call back

    }
}
