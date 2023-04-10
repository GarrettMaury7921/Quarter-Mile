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
        private NameEntryMenu nameEntryMenu;
        private NameEntryMenu nameEntryMenu2;
        private NameEntryMenu nameEntryMenu3;
        private NameEntryMenu nameEntryMenu4;
        private NameEntryMenu nameEntryMenu5;
        private NameEntryMenu nameEntryMenu6;
        private NameEntryMenu nameEntryMenu7;
        private MenuState menuState;
        private KeyboardState previousKeyboardState;
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
        private DialogueBox dialogueBox;
        private int centerX;
        private int centerY;
        private bool start;
        private int charIndex;
        private int charIndex2;
        private int charIndex3;
        private int charIndex4;
        private int charIndex5;
        private int charIndex6;
        private int charIndex7;

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
        private int nameLetter;
        private bool Learn;
        private bool Learn2;
        private bool trail;
        private bool names;
        private bool otherNames;

        // Names
        private string player1Name;
        private string player2Name;
        private string player3Name;
        private string player4Name;

        // Timer
        private float nameInputTimer = 0f;
        private const float NAME_INPUT_DELAY = 0.1f; // 0.5 seconds delay before allowing input again
        private bool nameInputHappened = false;


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
            skateboard = _content.Load<Texture2D>("Game_Assets/skateboard");
            sign = _content.Load<Texture2D>("Game_Assets/sign");
            ox = _content.Load<Texture2D>("Game_Assets/ox");
            ethan = _content.Load<Texture2D>("Game_Assets/ethan");
            bear = _content.Load<Texture2D>("Game_Assets/bear");

            ChangeMenuBackground(dialogueBackground);

            // Make Dialog Box
            dialogueBox = new DialogueBox(_content);
            nameEntryMenu = new NameEntryMenu(_content);
            nameEntryMenu2 = new NameEntryMenu(_content);
            nameEntryMenu3 = new NameEntryMenu(_content);
            nameEntryMenu4 = new NameEntryMenu(_content);
            nameEntryMenu5 = new NameEntryMenu(_content);
            nameEntryMenu6 = new NameEntryMenu(_content);
            nameEntryMenu7 = new NameEntryMenu(_content);

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
            Learn2 = false;
            trail = false;
            nameLetter = 0;
            otherNames = false;
        } // PreGame State Constructor

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D background)
        {
            // Draw the main menu background
            if (!names && !otherNames)
            {
                spriteBatch.Draw(background, new Rectangle(0, 0, _preferredBackBufferWidth, _preferredBackBufferHeight),
                new Rectangle(0, 0, 1080, 2560), Color.White);
            }

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
                dialogueBox.DrawDialogue(spriteBatch, "    Press RED to continue",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.9f)));
            }
            else if (Learn2)
            {
                dialogueBox.DrawDialogue(spriteBatch, "The 400 metres, a sprint on a \n 437.445319 Yards oval",
                    new Vector2(centerX - (centerX / 1.2f), centerY - (centerY / 3f)));
                dialogueBox.DrawDialogue(spriteBatch, "Quarter Mile Bridge, the \n local name for the " +
                    "\n Maribyrnong River Viaduct in \n Australia",
                    new Vector2(centerX - (centerX / 1.2f), centerY - (centerY / 5f)));
                dialogueBox.DrawDialogue(spriteBatch, "Quarter Mile Walkway, a \n .41 mile long pedestrian \n walkway " +
                    "through Rochester \n Institute of Technology's \n main campus",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.1f)));
                dialogueBox.DrawDialogue(spriteBatch, "Quarter mile horse \n races on open roads in the US \n Colonial Era " +
                    "which \n gave the American Quarter \n Horse its name",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.45f)));
                dialogueBox.DrawDialogue(spriteBatch, "    Press RED to continue",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.9f)));
            }
            else if (trail)
            {
                dialogueBox.DrawDialogue(spriteBatch, "Many kinds of RIT students \nmade the trip to Academic Side.",
                    new Vector2(centerX - (centerX / 1.2f), centerY - (centerY / 3f)));
                dialogueBox.DrawDialogue(spriteBatch, "You may:",
                    new Vector2(centerX - (centerX / 1.2f), centerY - (centerY / 6f)));
                dialogueBox.DrawDialogueWithIcon(spriteBatch, "     Be a Freshman from NRH",
                    new Vector2(centerX - (centerX / 1.2f), centerY - (centerY / 12f)), red_button);
                dialogueBox.DrawDialogueWithIcon(spriteBatch, "     Be an Upperclassman from \nApex",
                    new Vector2(centerX - (centerX / 1.2f), centerY), blue_button);
            }
            else if (names)
            {
                // Draw pictures
                DrawNameScreen(spriteBatch);

                dialogueBox.DrawDialogue(spriteBatch, "What is the name of the \npedestrian leader?",
                    new Vector2(centerX - (centerX / 1.2f), centerY));
                dialogueBox.DrawDialogueWithIcon(spriteBatch, "     Select",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY / 7f)), red_button);

                // Draw the underline and the character
                nameEntryMenu.DrawUnderline(spriteBatch, 
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY / 2.5f)));
                nameEntryMenu.DrawLetter(spriteBatch, charIndex,
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY / 2.65f)));

                nameEntryMenu2.DrawUnderline(spriteBatch,
                    new Vector2(centerX - (centerX / 1.5f), centerY + (centerY / 2.5f)));
                nameEntryMenu2.DrawLetter(spriteBatch, charIndex2,
                    new Vector2(centerX - (centerX / 1.5f), centerY + (centerY / 2.65f)));

                nameEntryMenu3.DrawUnderline(spriteBatch,
                    new Vector2(centerX - (centerX / 2f), centerY + (centerY / 2.5f)));
                nameEntryMenu3.DrawLetter(spriteBatch, charIndex3,
                    new Vector2(centerX - (centerX / 2f), centerY + (centerY / 2.65f)));

                nameEntryMenu4.DrawUnderline(spriteBatch,
                    new Vector2(centerX - (centerX / 3f), centerY + (centerY / 2.5f)));
                nameEntryMenu4.DrawLetter(spriteBatch, charIndex4,
                    new Vector2(centerX - (centerX / 3), centerY + (centerY / 2.65f)));

                nameEntryMenu5.DrawUnderline(spriteBatch,
                    new Vector2(centerX - (centerX / 6f), centerY + (centerY / 2.5f)));
                nameEntryMenu5.DrawLetter(spriteBatch, charIndex5,
                    new Vector2(centerX - (centerX / 6f), centerY + (centerY / 2.65f)));

                nameEntryMenu6.DrawUnderline(spriteBatch,
                    new Vector2(centerX, centerY + (centerY / 2.5f)));
                nameEntryMenu6.DrawLetter(spriteBatch, charIndex6,
                    new Vector2(centerX, centerY + (centerY / 2.65f)));

                nameEntryMenu7.DrawUnderline(spriteBatch,
                    new Vector2(centerX + (centerX / 6f), centerY + (centerY / 2.5f)));
                nameEntryMenu7.DrawLetter(spriteBatch, charIndex7,
                    new Vector2(centerX + (centerX / 6f), centerY + (centerY / 2.65f)));

            }
            else if (otherNames)
            {
                DrawNameScreen(spriteBatch);

                dialogueBox.DrawDialogue(spriteBatch, "What are the names of \nthe other members of \nyour party?",
                    new Vector2(centerX - (centerX / 1.2f), centerY));
                dialogueBox.DrawDialogueWithIcon(spriteBatch, "     Select",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY / 4.5f)), red_button);
                dialogueBox.DrawDialogue(spriteBatch, "1.  " + player1Name,
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY / 2f)));
            }
        } // Draw Method

        public override void Update(GameTime gameTime)
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();

            CheckButtons(currentKeyboardState);

            // Game start check
            if (!reddown && start)
            {
                reddown = true;
                start = false;
                trail = true;
            }
            // Learning Section Check
            if (!blue5down && start)
            {
                blue5down = true;
                start = false; // starting screen
                Learn = true; // Learn about the trail screen
            }
            // Back to menu check
            if (!greendown && start)
            {
                greendown = true;
                // Make next game state
                menuState = new(_game, _graphicsDevice, _preferredBackBufferWidth, _preferredBackBufferHeight, _content, "MenuState");
                Game1.ChangeState(menuState);
            }
            // Learning 2
            if (!reddown && Learn)
            {
                reddown = true;
                Learn = false;
                Learn2 = true;
            }
            if (!reddown && Learn2)
            {
                reddown = true;
                Learn2 = false;
                start = true; // return to game menu
            }
            // ***** Character Selection ******
            if (!reddown && trail)
            {
                reddown = true;
                trail = false;
                names = true; // name selection
                Debug.WriteLine("fresh");
            }
            if (!blue5down && trail)
            {
                blue5down = true;
                trail = false;
                names = true; // name selection
                Debug.WriteLine("upper");
            }
            // Name Input Selection
            if (names)
            {
                switch (nameLetter)
                {
                    case 0:
                        // Check Arrow Key Input
                        NameSelection(currentKeyboardState, gameTime, charIndex);
                        break;
                    case 1:
                        NameSelection(currentKeyboardState, gameTime, charIndex2);
                        break;
                    case 2:
                        NameSelection(currentKeyboardState, gameTime, charIndex3);
                        break;
                    case 3:
                        NameSelection(currentKeyboardState, gameTime, charIndex4);
                        break;
                    case 4:
                        NameSelection(currentKeyboardState, gameTime, charIndex5);
                        break;
                    case 5:
                        NameSelection(currentKeyboardState, gameTime, charIndex6);
                        break;
                    case 6:
                        NameSelection(currentKeyboardState, gameTime, charIndex7);
                        break;
                } // switch statement

            } // names if statement


            previousKeyboardState = currentKeyboardState;

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

        private void NameSelection(KeyboardState currentKeyboardState, GameTime gameTime, int charindex)
        {
            if ((currentKeyboardState.IsKeyDown(Keys.Up) || Input.GetButton(1, Input.ArcadeButtons.StickUp))
                && !nameInputHappened)
            {
                if (charindex - 1 < 0)
                {
                    // Do nothing, at min index
                }
                else
                {
                    charindex -= 1;
                    nameInputHappened = true; // Input has happened, set flag to true
                    nameInputTimer = NAME_INPUT_DELAY; // Start timer
                }
            }
            if ((currentKeyboardState.IsKeyDown(Keys.Down) || Input.GetButton(1, Input.ArcadeButtons.StickDown))
                && !nameInputHappened)
            {
                if (charindex + 1 == nameEntryMenu.chars.Length)
                {
                    // Do nothing, at max index
                }
                else
                {
                    charindex += 1;
                    nameInputHappened = true; // Input has happened, set flag to true
                    nameInputTimer = NAME_INPUT_DELAY; // Start timer
                }
            }

            if ((currentKeyboardState.IsKeyDown(Keys.Enter) || Input.GetButton(1, Input.ArcadeButtons.A1))
                && !nameInputHappened)
            {
                // Check and see if that was the last letter
                if (nameLetter >= 6)
                {
                    names = false;

                    player1Name = nameEntryMenu.GetLetter() + nameEntryMenu2.GetLetter() + nameEntryMenu3.GetLetter() + 
                        nameEntryMenu4.GetLetter() + nameEntryMenu5.GetLetter() + nameEntryMenu6.GetLetter() + 
                        nameEntryMenu7.GetLetter();

                    otherNames = true;

                    // Reset variables
                    nameLetter = 0;
                    charindex = 0;
                    charIndex = 0;
                    charIndex2 = 0;
                    charIndex3 = 0;
                    charIndex4 = 0;
                    charIndex5 = 0;
                    charIndex6 = 0;
                    charIndex7 = 0;

                }

                if (names)
                {
                    // Go to the next character
                    nameLetter++;
                    nameInputHappened = true; // Input has happened, set flag to true
                    nameInputTimer = NAME_INPUT_DELAY; // Start timer
                }
            }

            // Check if the timer has expired and reset the flag if it has
            if (nameInputHappened)
            {
                nameInputTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (nameInputTimer <= 0)
                {
                    nameInputHappened = false;
                }
            }

            // Set Char index
            switch(nameLetter)
            {
                case 0:
                    charIndex = charindex;
                    break;
                case 1:
                    charIndex2 = charindex;
                    break;
                case 2:
                    charIndex3 = charindex;
                    break;
                case 3:
                    charIndex4 = charindex;
                    break;
                case 4:
                    charIndex5 = charindex;
                    break;
                case 5:
                    charIndex6 = charindex;
                    break;
                case 6:
                    charIndex7 = charindex;
                    break;
            }

        } // name selection method

        public void DrawNameScreen(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(skateboard, new Rectangle(
                    (int)(centerX - (centerX / 1.2f)), // X position of the destination rectangle
                    (int)(centerY - (centerY / 2f)), // Y position of the destination rectangle
                    (int)(_preferredBackBufferWidth * 0.18f), // Width of the destination rectangle
                    (int)(_preferredBackBufferHeight * 0.1f)), // Height of the destination rectangle
                    Color.White);
            spriteBatch.Draw(sign, new Rectangle(
                (int)(centerX + (centerX * 0.5f)), // X position of the destination rectangle
                (int)(centerY - (centerY / 2f)), // Y position of the destination rectangle
                (int)(_preferredBackBufferWidth * 0.23f), // Width of the destination rectangle
                (int)(_preferredBackBufferHeight * 0.4f)), // Height of the destination rectangle
                Color.White);
            spriteBatch.Draw(ox, new Rectangle(
                    (int)(centerX - (centerX / 16f)), // X position of the destination rectangle
                    (int)(centerY - (centerY / 2f)), // Y position of the destination rectangle
                    (int)(_preferredBackBufferWidth * 0.3f), // Width of the destination rectangle
                    (int)(_preferredBackBufferHeight * 0.22f)), // Height of the destination rectangle
                    Color.White);
            spriteBatch.Draw(bear, new Rectangle(
                    (int)(centerX - (centerX / 2f)), // X position of the destination rectangle
                    (int)(centerY - (centerY / 1f)), // Y position of the destination rectangle
                    (int)(_preferredBackBufferWidth * 0.5f), // Width of the destination rectangle
                    (int)(_preferredBackBufferHeight * 0.3f)), // Height of the destination rectangle
                    Color.White);
        }

    } // public class

} // name space
