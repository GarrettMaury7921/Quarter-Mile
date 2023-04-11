using Devcade;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using QuarterMile.Characters;
using QuarterMile.Controls;

namespace QuarterMile.States
{
    public class QuarterMileState : State
    {
        // Attributes
        private int centerX;
        private int centerY;
        private int playerClass;
        private string name1;
        private string name2;
        private string name3;
        private string name4;
        private KeyboardState previousKeyboardState;
        private NRH_Freshman freshman;
        private Apex_Upperclassman upperclassman;

        // Game assets
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
        private bool date;
        private int semester;
        private bool info;

        public QuarterMileState(Game1 game, GraphicsDevice graphicsDevice, int preferredBackBufferWidth, int preferredBackBufferHeight, ContentManager content, string state_name) : base(game, graphicsDevice, preferredBackBufferWidth, preferredBackBufferHeight, content, state_name)
        {
            playerClass = 0;
            name1 = "";
            name2 = "";
            name3 = "";
            name4 = "";
            dialogueBox = new DialogueBox(_content);

            // Load Assets
            red_button = _content.Load<Texture2D>("Game_Assets/red");
            blue_button = _content.Load<Texture2D>("Game_Assets/blue");
            dark_blue_button = _content.Load<Texture2D>("Game_Assets/dark_blue");
            green_button = _content.Load<Texture2D>("Game_Assets/green");
            white_button = _content.Load<Texture2D>("Game_Assets/white");
            yellow_button = _content.Load<Texture2D>("Game_Assets/yellow");
            dialogueBackground = _content.Load<Texture2D>("Menu_Assets/Dialogue_Background");
            ethan = _content.Load<Texture2D>("Game_Assets/ethan");
        }

        // Input all the data from the pre game state
        public void InitializeData(int startingPlayerClass, string player1Name, string player2Name, string player3Name, string player4Name)
        {
            centerX = (_preferredBackBufferWidth) / 2;
            centerY = (_preferredBackBufferHeight) / 2;

            playerClass = startingPlayerClass;
            name1 = player1Name;
            name2 = player2Name;
            name3 = player3Name;
            name4 = player4Name;

            // Freshman from NRH
            if (playerClass == 1)
            {
                freshman = new NRH_Freshman();
            }
            // Upperclassman from Apex
            else if (playerClass == 2)
            {
                upperclassman = new Apex_Upperclassman();
            }

            date = true;

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D main_menu)
        {
            // Getting the semester
            if (date && playerClass == 1)
            {
                spriteBatch.Draw(dialogueBackground, new Rectangle(0, 0, _preferredBackBufferWidth, _preferredBackBufferHeight),
                new Rectangle(0, 0, 1080, 2560), Color.White);

                // Make Dialog
                dialogueBox.DrawDialogue(spriteBatch, "It is 2023. Your jumping off\nplace for the Quarter Mile is " +
                    "\nNRH. You must decide which \nsemester to leave NRH.",
                    new Vector2(centerX - (centerX / 1.2f), centerY - (centerY / 3f)));
                dialogueBox.DrawDialogueWithIcon(spriteBatch, "     Fall Semester",
                    new Vector2(centerX - (centerX / 1.2f), centerY - (centerY / 15f)), red_button);
                dialogueBox.DrawDialogueWithIcon(spriteBatch, "     Spring Semester",
                    new Vector2(centerX - (centerX / 1.2f), centerY), blue_button);
            }
            if (date && playerClass == 2)
            {
                spriteBatch.Draw(dialogueBackground, new Rectangle(0, 0, _preferredBackBufferWidth, _preferredBackBufferHeight),
                new Rectangle(0, 0, 1080, 2560), Color.White);

                // Make Dialog
                dialogueBox.DrawDialogue(spriteBatch, "It is 2023. Your jumping off\nplace for the Quarter Mile is " +
                    "\nApex Apartments. You must \ndecide which semester to leave \nApex.",
                    new Vector2(centerX - (centerX / 1.2f), centerY - (centerY / 3f)));
                dialogueBox.DrawDialogueWithIcon(spriteBatch, "     Fall Semester",
                    new Vector2(centerX - (centerX / 1.2f), centerY), red_button);
                dialogueBox.DrawDialogueWithIcon(spriteBatch, "     Spring Semester",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY / 10f)), blue_button);
            }
            // Money info showing
            if (info)
            {
                spriteBatch.Draw(dialogueBackground, new Rectangle(0, 0, _preferredBackBufferWidth, _preferredBackBufferHeight),
                new Rectangle(0, 0, 1080, 2560), Color.White);

                // Make Dialog
                if (playerClass == 1)
                {
                    dialogueBox.DrawDialogue(spriteBatch, "Before leaving, you should \nbuy equipment and supplies. \n" +
                    "You have $" + freshman.GetMoney() + " in cash, but \nyou don't need to spend it all \nnow.",
                    new Vector2(centerX - (centerX / 1.2f), centerY - (centerY / 3f)));
                }
                if (playerClass == 2)
                {
                    dialogueBox.DrawDialogue(spriteBatch, "Before leaving, you should \nbuy equipment and supplies. \n" +
                    "You have $" + upperclassman.GetMoney() + " in cash, but \nyou don't need to spend it all \nnow.",
                    new Vector2(centerX - (centerX / 1.2f), centerY - (centerY / 3f)));
                }


                dialogueBox.DrawDialogue(spriteBatch, "    Press RED to continue",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.9f)));

            }
        }

        public override void PostUpdate(GameTime gameTime)
        {
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();

            CheckButtons(currentKeyboardState);

            // Check for date input
            if (date)
            {
                if (!reddown)
                {
                    semester = 1;
                    reddown = true;
                    date = false;
                    info = true;
                }
                else if (!blue5down)
                {
                    semester = 2;
                    blue5down = true;
                    date = false;
                    info = true;
                }
            }

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
