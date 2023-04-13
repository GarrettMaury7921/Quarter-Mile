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

        // Shop
        private int skateboardPrice;
        private int foodPrice;
        private int clothingPrice;
        private double studyPrice;
        private int wheelPrice;
        private int truckPrice;
        private int bearPrice;

        // Game variables
        private bool date;
        private int semester;
        private bool info;
        private bool shop;
        private bool shop2;
        private bool shop3;

        // Inventory
        Inventory inventory;

        // Next Game State
        ActualGameState nextState;

        public QuarterMileState(Game1 game, GraphicsDevice graphicsDevice, int preferredBackBufferWidth, int preferredBackBufferHeight, ContentManager content, string state_name) : base(game, graphicsDevice, preferredBackBufferWidth, preferredBackBufferHeight, content, state_name)
        {
            playerClass = 0;
            name1 = "";
            name2 = "";
            name3 = "";
            name4 = "";
            dialogueBox = new DialogueBox(_content);

            skateboardPrice = 0;
            foodPrice = 0;
            clothingPrice = 0;
            studyPrice = 0;
            wheelPrice = 0;
            truckPrice = 0;
            bearPrice = 0;

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
            reddown = true;
            blue5down = true;

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
            if (shop)
            {
                spriteBatch.Draw(ethan, new Rectangle(
                    (int)(centerX - (centerX / 1.2f)), // X position of the destination rectangle
                    (int)(centerY - (centerY * 1.16f)), // Y position of the destination rectangle
                    (int)(_preferredBackBufferWidth * 0.4f), // Width of the destination rectangle
                    (int)(_preferredBackBufferHeight * 0.5f)), // Height of the destination rectangle
                    Color.White);

                dialogueBox.DrawDialogue(spriteBatch, "Hello, I'm Ethan. Current chair \nof CSH! So I see you're going \nto Academic Side. I can fix \nyou up with what you need:" +
                    "\n\nHave you heard of weird clock? \nJust don't tell anyone how it \nworks, okay?",
                    new Vector2(centerX - (centerX / 1.2f), centerY - (centerY / 3f)));
                dialogueBox.DrawDialogue(spriteBatch, "- You'll need: A team of \nskateboards to carry your lazy \nbutt",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.3f)));
                dialogueBox.DrawDialogue(spriteBatch, "- Clothing for both summer \nand winter",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.5f)));

                dialogueBox.DrawDialogue(spriteBatch, "    Press RED to continue",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.9f)));

            }
            if (shop2)
            {
                spriteBatch.Draw(ethan, new Rectangle(
                    (int)(centerX - (centerX / 1.2f)), // X position of the destination rectangle
                    (int)(centerY - (centerY * 1.16f)), // Y position of the destination rectangle
                    (int)(_preferredBackBufferWidth * 0.4f), // Width of the destination rectangle
                    (int)(_preferredBackBufferHeight * 0.5f)), // Height of the destination rectangle
                    Color.White);

                dialogueBox.DrawDialogue(spriteBatch, "Hello, I'm Ethan. Current chair \nof CSH! So I see you're going \nto Academic Side. I can fix \nyou up with what you need:" +
                    "\n\nHave you heard of weird clock? \nJust don't tell anyone how it \nworks, okay?",
                    new Vector2(centerX - (centerX / 1.2f), centerY - (centerY / 3f)));
                dialogueBox.DrawDialogue(spriteBatch, "- Plenty of food for the trip",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.3f)));
                dialogueBox.DrawDialogue(spriteBatch, "- Study guides for your exams",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.5f)));
                dialogueBox.DrawDialogue(spriteBatch, "- Spare parts for your \nskateboard",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.7f)));

                dialogueBox.DrawDialogue(spriteBatch, "    Press RED to continue",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.9f)));

            }
            if (shop3)
            {
                spriteBatch.Draw(ethan, new Rectangle(
                    (int)(centerX - (centerX / 1.1f)), // X position of the destination rectangle
                    (int)(centerY - (centerY * 1.2f)), // Y position of the destination rectangle
                    (int)(_preferredBackBufferWidth * 0.4f), // Width of the destination rectangle
                    (int)(_preferredBackBufferHeight * 0.5f)), // Height of the destination rectangle
                    Color.White);

                dialogueBox.DrawDialogueWithIcon(spriteBatch, "     Done Shopping \n (B4)",
                    new Vector2(centerX - (centerX / 4f), centerY - (centerY / 1.1f)), dark_blue_button);

                // Shop
                int spareParts = wheelPrice + bearPrice + truckPrice;
                double bill = skateboardPrice + foodPrice + clothingPrice + studyPrice + spareParts;
                dialogueBox.DrawDialogue(spriteBatch, "Ethan's Corner Store, NRH.\n" +
                    "-------------------------\n" +
                    "1. Skateboard      $" + skateboardPrice + "\n" +
                    "2. Food           $" + foodPrice + "\n" +
                    "3. Clothing        $" + clothingPrice + "\n" +
                    "4. Study Guides   $" + (int)studyPrice + "\n" +
                    "5. Spare parts    $" + spareParts + "\n" +
                    "-------------------------\n" +
                    "Total Bill: $ " + (int)bill,
                    new Vector2(centerX - (centerX / 1.2f), centerY - (centerY / 3f)));
                if (playerClass == 1)
                {
                    dialogueBox.DrawDialogue(spriteBatch, "Amount you have: $" + (int)freshman.GetMoney(),
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.25f)));
                }
                if (playerClass == 2)
                {
                    dialogueBox.DrawDialogue(spriteBatch, "Amount you have: $" + (int)upperclassman.GetMoney(),
                     new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.25f)));
                }

                dialogueBox.DrawDialogueWithIcon(spriteBatch, "   Anime Skateboard: $50",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.32f)), red_button);
                dialogueBox.DrawDialogueWithIcon(spriteBatch, "   RIT Food (1 lb): $20",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.42f)), blue_button);
                dialogueBox.DrawDialogueWithIcon(spriteBatch, "   Clothing (1 Set): $50",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.52f)), green_button);
                dialogueBox.DrawDialogueWithIcon(spriteBatch, "   Study Guide (1 Packet): $15.95",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.62f)), white_button);
                dialogueBox.DrawDialogueWithIcon(spriteBatch, "   Skateboard Wheel (B1) $16",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.72f)), dark_blue_button);
                dialogueBox.DrawDialogueWithIcon(spriteBatch, "   Skateboard Truck (B2) $20",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.82f)), dark_blue_button);
                dialogueBox.DrawDialogueWithIcon(spriteBatch, "   Skateboard Bearings (B3) $18",
                    new Vector2(centerX - (centerX / 1.2f), centerY + (centerY * 0.92f)), dark_blue_button);


            } // shop 3

        } // draw

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
            if (info && !reddown)
            {
                reddown = true;
                info = false;
                shop = true;
            }
            if (shop && !reddown)
            {
                reddown = true;
                shop = false;
                shop2 = true;
            }
            if (shop2 && !reddown)
            {
                reddown = true;
                shop2 = false;

                // Reset buttons
                blue1down = true;
                blue2down = true;
                blue3down = true;
                blue4down = true;
                blue5down = true;
                greendown = true;
                whitedown = true;

                shop3 = true;
            }
            if (shop3)
            {
                if (!reddown)
                {
                    reddown = true;
                    if (playerClass == 1 && (freshman.GetMoney() - 50) >= 0)
                    {
                        freshman.SetMoney(freshman.GetMoney() - 50);
                        skateboardPrice += 50;
                    }
                    if (playerClass == 2 && (upperclassman.GetMoney() - 50) >= 0)
                    {
                        upperclassman.SetMoney(upperclassman.GetMoney() - 50);
                        skateboardPrice += 50;
                    }
                } // skateboard price
                if (!blue5down)
                {
                    blue5down = true;
                    if (playerClass == 1 && (freshman.GetMoney() - 20) >= 0)
                    {
                        freshman.SetMoney(freshman.GetMoney() - 20);
                        foodPrice += 20;
                    }
                    if (playerClass == 2 && (upperclassman.GetMoney() - 20) >= 0)
                    {
                        upperclassman.SetMoney(upperclassman.GetMoney() - 20);
                        foodPrice += 20;
                    }
                } // food price
                if (!greendown)
                {
                    greendown = true;
                    if (playerClass == 1 && (freshman.GetMoney() - 50) >= 0)
                    {
                        freshman.SetMoney(freshman.GetMoney() - 50);
                        clothingPrice += 50;
                    }
                    if (playerClass == 2 && (upperclassman.GetMoney() - 50) >= 0)
                    {
                        upperclassman.SetMoney(upperclassman.GetMoney() - 50);
                        clothingPrice += 50;
                    }
                } // clothing price
                if (!whitedown)
                {
                    whitedown = true;
                    if (playerClass == 1 && (freshman.GetMoney() - 15.95) >= 0)
                    {
                        freshman.SetMoney(freshman.GetMoney() - 15.95);
                        studyPrice += 15.95;
                    }
                    if (playerClass == 2 && (upperclassman.GetMoney() - 15.95) >= 0)
                    {
                        upperclassman.SetMoney(upperclassman.GetMoney() - 15.95);
                        studyPrice += 15.95;
                    }
                } // study price
                if (!blue1down)
                {
                    blue1down = true;
                    if (playerClass == 1 && (freshman.GetMoney() - 16) >= 0)
                    {
                        freshman.SetMoney(freshman.GetMoney() - 16);
                        wheelPrice += 16;
                    }
                    if (playerClass == 2 && (upperclassman.GetMoney() - 16) >= 0)
                    {
                        upperclassman.SetMoney(upperclassman.GetMoney() - 16);
                        wheelPrice += 16;
                    }
                } // wheel price
                if (!blue2down)
                {
                    blue2down = true;
                    if (playerClass == 1 && (freshman.GetMoney() - 20) >= 0)
                    {
                        freshman.SetMoney(freshman.GetMoney() - 20);
                        truckPrice += 20;
                    }
                    if (playerClass == 2 && (upperclassman.GetMoney() - 20) >= 0)
                    {
                        upperclassman.SetMoney(upperclassman.GetMoney() - 20);
                        truckPrice += 20;
                    }
                } // truck price
                if (!blue3down)
                {
                    blue3down = true;
                    if (playerClass == 1 && (freshman.GetMoney() - 18) >= 0)
                    {
                        freshman.SetMoney(freshman.GetMoney() - 18);
                        bearPrice += 18;
                    }
                    if (playerClass == 2 && (upperclassman.GetMoney() - 18) >= 0)
                    {
                        upperclassman.SetMoney(upperclassman.GetMoney() - 18);
                        bearPrice += 18;
                    }
                } // bearings price
                if (!blue4down)
                {
                    blue4down = true;
                    if (playerClass == 1)
                    {
                        inventory = new Inventory(freshman.GetMoney(), semester, skateboardPrice / 50, foodPrice / 20,
                            clothingPrice / 50, studyPrice / 15.95, wheelPrice / 16, truckPrice / 20, bearPrice / 18,
                            freshman.GetHealth(), name1, name2, name3, name4);
                    }
                    if (playerClass == 2)
                    {
                        inventory = new Inventory(upperclassman.GetMoney(), semester, skateboardPrice / 50, foodPrice / 20,
                            clothingPrice / 50, studyPrice / 15.95, wheelPrice / 16, truckPrice / 20, bearPrice / 18,
                            upperclassman.GetHealth(), name1, name2, name3, name4);
                    }

                    shop3 = false;
                    nextState = new ActualGameState(_game, _graphicsDevice, _preferredBackBufferWidth, _preferredBackBufferHeight, 
                        _content, "TrailState", inventory, freshman, upperclassman);
                    Game1.ChangeState(nextState); // Change State

                }
            } // shop 3

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
