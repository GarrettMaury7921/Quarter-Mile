using QuarterMile.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using System;
using Devcade;
using System.Linq;
using Microsoft.Xna.Framework.Media;
// HEAVILY MODIFIED VERSION OF Oyyou's MonoGame_Tutorials #13. All credit goes to Oyyou for the original code.
// https://github.com/Oyyou/MonoGame_Tutorials/tree/master/MonoGame_Tutorials/Tutorial013


namespace QuarterMile.States
{
    /* 
    Class MenuState:
        MenuState Constructor: Loads Button Icon with fronts for the text on said button,
            - contains each button by making a new button class
        @ Draw Method
        @ Update Method
        @ PostUpdate Method
        @ Button On Click Methods
        @ Slider Methods
    */
    public class MenuState : State
    {
        // Attributes
        public static List<Component> _components;
        public List<Component> _main_menu_components;
        public List<Component> _settings_components;
        public List<Component> _empty_components;
        private readonly Song title_music;
        private readonly SoundEffect sliderUpSound;
        private readonly SoundEffect sliderDownSound;
        private readonly string musicType;
        private readonly string soundEffectType;
        private readonly string state_name;
        public static int _gameID;
        public static int _difficultyID;
        private bool keyPressed;
        private int currentButton;
        private readonly float centerX;
        private readonly float centerY;
        private readonly int buttonWidth;
        private readonly int buttonHeight;
        public static bool inGame;
        private PreGameState preGame;

        // MenuState Constructor
        public MenuState(Game1 game, GraphicsDevice graphicsDevice, int PreferredBackBufferWidth, int PreferredBackBufferHeight, ContentManager content, string _state_name) :
            base(game, graphicsDevice, PreferredBackBufferWidth, PreferredBackBufferHeight, content, _state_name)
        {
            // Attributes
            musicType = "music";
            soundEffectType = "effect";
            inGame = false;
            state_name = _state_name;
            currentButton = 1;
            buttonWidth = 500;
            buttonHeight = 60;
            centerX = (_preferredBackBufferWidth - buttonWidth) / 2;
            centerY = (_preferredBackBufferHeight - buttonHeight) / 2;


            // ***** LOAD ASSETS *****

            // Load Main Menu Background
            Texture2D main_menu = _content.Load<Texture2D>("Menu_Assets/QuarterMileBackground");
            Texture2D main_menu2 = _content.Load<Texture2D>("Menu_Assets/MainMenuBackground");

            // Load the buttons for the menu
            var buttonTexture = _content.Load<Texture2D>("Menu_Assets/button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");

            // Load the sliders for the menu
            var sliderTexture = _content.Load<Texture2D>("Menu_Assets/slider");
            var sliderThumbTexture = _content.Load<Texture2D>("Menu_Assets/slider_ball");

            // SOUND EFFECTS
            sliderUpSound = _content.Load<SoundEffect>("SoundEffects/SliderUp");
            sliderDownSound = _content.Load<SoundEffect>("SoundEffects/SliderDown");

            // SONGS
            title_music = _content.Load<Song>("Songs/title");
            MediaPlayer.Play(title_music);
            MediaPlayer.IsRepeating = true;

            // ***** ALL STARTING BUTTONS ARE DEFINED BELOW *****
            // These are all the things that the user can select in the menu
            // Each button has an on-click event
            var travelButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2((int)(centerX + (PreferredBackBufferWidth * 0.27f)), (int)(centerY + (PreferredBackBufferHeight * 0.32f))),
                Text = "      Travel",
            };
            travelButton.Click += TravelButton_Click;

            var settingsButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2((int)(centerX + (PreferredBackBufferWidth * 0.27f)), (int)(centerY + (PreferredBackBufferHeight * 0.39f))),
                Text = "      Settings",
            };
            settingsButton.Click += SettingsButton_Click;

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2((int)(centerX + (PreferredBackBufferWidth * 0.27f)), (int)(centerY + (PreferredBackBufferHeight * 0.46f))),
                Text = "      Quit",
            };
            quitGameButton.Click += QuitGameButton_Click;

            var BackButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2((int)(centerX + (PreferredBackBufferWidth * 0.27f)), (int)(centerY + (PreferredBackBufferHeight * 0.46f))),
                Text = "     Back",
            };
            BackButton.Click += BackButton_Click;

            // ***** ALL SLIDERS DEFINED BELOW *****
            // MUSIC VOLUME SLIDER
            var MusicVolumeSliderButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2((int)(centerX + (PreferredBackBufferWidth * 0.27f)), (int)(centerY + (PreferredBackBufferHeight * 0.34f))),
                // Setting the text to the correct place above the slider
                textOffset = new Vector2(40, -40),
                Text = "Music",
            };
            MusicVolumeSliderButton.Click += MusicVolumeSliderButton_Click;
            var MusicVolumeSlider = new Slider(sliderTexture, sliderThumbTexture, musicType)
            {
                Position = new Vector2((int)(centerX + (PreferredBackBufferWidth * 0.44f)), (int)(centerY + (PreferredBackBufferHeight * 0.365f))),
                BarColor = Color.White,
            };

            // SOUND EFFECT SLIDER
            var EffectVolumeSliderButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2((int)(centerX + (PreferredBackBufferWidth * 0.27f)), (int)(centerY + (PreferredBackBufferHeight * 0.41f))),
                // Setting the text to the correct place above the slider
                textOffset = new Vector2(44, -40),
                Text = "Sound Effects",
            };
            EffectVolumeSliderButton.Click += EffectVolumeSliderButton_Click;
            var EffectVolumeSlider = new Slider(sliderTexture, sliderThumbTexture, soundEffectType)
            {
                Position = new Vector2((int)(centerX + (PreferredBackBufferWidth * 0.44f)), (int)(centerY + (PreferredBackBufferHeight * 0.435f))),
                BarColor = Color.White,
            };


            // ***** TYPES OF COMPONENTS *****
            // Change to these components to change the menu
            _empty_components = new List<Component>()
            {

            };
            _main_menu_components = new List<Component>()
            {
                travelButton,
                settingsButton,
                quitGameButton,
            };
            _settings_components = new List<Component>()
            {
                MusicVolumeSliderButton,
                MusicVolumeSlider,
                EffectVolumeSliderButton,
                EffectVolumeSlider,
                BackButton,
            };

            // Random background
            Random rand = new();
            int randomInt = rand.Next(1, 3); // Generates a random integer between x and y-1
            switch (randomInt)
            {
                case 1:
                    ChangeMenuBackground(main_menu);
                    break;
                case 2:
                    ChangeMenuBackground(main_menu2);
                    break;
                default:
                    ChangeMenuBackground(main_menu);
                    break;

            } // switch

            // Using starting main menu component
            _components = _main_menu_components;

            // Put the mouse in the correct spot
            Mouse.SetPosition((int)travelButton.Position.X + 150, (int)travelButton.Position.Y + 20);
        } // MenuState Constructor

        // **********************************
        // ***** BUTTON ON-CLICK EVENTS *****
        // **********************************

        private void TravelButton_Click(object sender, EventArgs e)
        {
            _components = _empty_components;
            MediaPlayer.Stop();

            // Make next game state
            preGame = new(_game, _graphicsDevice, _preferredBackBufferWidth, _preferredBackBufferHeight, _content, "preGame");
            Game1.ChangeState(preGame);
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            _components = _settings_components;
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _components = _main_menu_components;
        }

        // *******************
        // ***** SLIDERS *****
        // *******************

        private void MusicVolumeSliderButton_Click(object sender, EventArgs e)
        {
            // Plays no sound since music is playing in the background
        }
        private void EffectVolumeSliderButton_Click(object sender, EventArgs e)
        {
            sliderUpSound.Play();
        }

        // *************************************
        // ***** Game1.cs Override Methods *****
        // *************************************
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D background)
        {
            // Draw the main menu background
            spriteBatch.Draw(background, new Rectangle(0, 0, _preferredBackBufferWidth, _preferredBackBufferHeight),
                new Rectangle(0, 0, 1080, 2560), Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            // Put the menu items on the screen
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }

            // Menu Controls
            DoMenuControls();

        }

        public override void PostUpdate(GameTime gameTime)
        {
            // remove the sprites if no longer needed
        }

        // OTHER METHODS

        private static void ChangeMenuBackground(Texture2D background)
        {
            Game1.main_menu = background;
        }

        // Keyboard and Arcade controls for the menu screen
        private void DoMenuControls()
        {
            // Make keyboard state so cursor only moves once when pressed
            KeyboardState currentKeyboardState = Keyboard.GetState();

            if (currentKeyboardState.GetPressedKeys().Length > 0)
            {
                // Get number of elements so we can move the cursor up and down and know the limits
                int numOfElements = _components.Count;

                // For moving the cursor up and down
                // For current button the highest button is 1, when you move down the screen the number goes up
                if ((currentKeyboardState.IsKeyDown(Keys.Up) || Input.GetButton(1, Input.ArcadeButtons.StickUp)
                    || Input.GetButton(2, Input.ArcadeButtons.StickUp)) && !keyPressed && currentButton > 1)
                {
                    // Get the next button pos (up) and set mouse to it
                    currentButton -= 1;
                    int count = 0;
                    foreach (var component in _components)
                    {
                        if (component is Button btn && count == currentButton - 1)
                        {
                            // Make sure it's normal color
                            btn._isSlider = false;

                            string cords = btn.Position.ToString();
                            string[] parts = cords.Replace("{", "").Replace("}", "").Split(' ');

                            int x = int.Parse(parts[0].Split(':')[1]);
                            int y = int.Parse(parts[1].Split(':')[1]);


                            Mouse.SetPosition(x, y);
                            break;
                        }
                        else if (component is Slider slider && count == currentButton - 1)
                        {
                            // Make the slider a different color when we are selecting it
                            int count2 = 0;
                            foreach (var component2 in _components)
                            {
                                if (component2 is Button btn2 && count2 == currentButton - 2)
                                {
                                    // Turn the slider a different color when selected and play the sound
                                    btn2._isSlider = true;
                                    sliderDownSound.Play();
                                }

                                count2++;
                            } // for each

                        } // else if
                        count++;

                    } // for each loop

                    keyPressed = true;
                }
                if ((currentKeyboardState.IsKeyDown(Keys.Down) || Input.GetButton(1, Input.ArcadeButtons.StickDown)
                    || Input.GetButton(2, Input.ArcadeButtons.StickDown)) && !keyPressed && currentButton < numOfElements)
                {
                    // Get the next button pos (below) and set mouse to it
                    currentButton += 1;
                    int count = 0;
                    foreach (var component in _components)
                    {
                        // Make sure the slider color is not on hover
                        if (component is Button btn_slider)
                        {
                            btn_slider._isSlider = false;
                        }

                        if (component is Button btn && count == currentButton - 1)
                        {
                            // Make sure it's normal color
                            btn._isSlider = false;

                            string cords = btn.Position.ToString();
                            string[] parts = cords.Replace("{", "").Replace("}", "").Split(' ');

                            int x = int.Parse(parts[0].Split(':')[1]);
                            int y = int.Parse(parts[1].Split(':')[1]);

                            Mouse.SetPosition(x, y);
                            break;
                        }
                        else if (component is Slider slider && count == currentButton - 1)
                        {
                            // Make the slider a different color when we are selecting it
                            int count2 = 0;
                            foreach (var component2 in _components)
                            {
                                if (component2 is Button btn2 && count2 == currentButton - 2)
                                {
                                    // Turn the slider a different color when selected and play the sound
                                    btn2._isSlider = true;
                                    sliderDownSound.Play();
                                }

                                count2++;
                            } // for each

                        }
                        count++;

                    } // foreach loop

                    keyPressed = true;
                }

                // Mouse click implemented in Button.cs
                if ((currentKeyboardState.IsKeyDown(Keys.Enter) || Input.GetButton(1, Input.ArcadeButtons.A1)
                    || Input.GetButton(2, Input.ArcadeButtons.A1)) && !keyPressed)
                {
                    // Go through each component and activate the one we are on
                    int count = 0;
                    foreach (var component in _components)
                    {
                        if (component is Button btn && count == currentButton - 1)
                        {
                            btn.EnterButtonHit();
                            // Extract the cords from the button position and put the cursor on the first button in the components
                            if (_components.FirstOrDefault(x => x is Button) is Button btn2)
                            {
                                string cords = btn2.Position.ToString();

                                string[] parts = cords.Replace("{", "").Replace("}", "").Split(' ');

                                int x = int.Parse(parts[0].Split(':')[1]);
                                int y = int.Parse(parts[1].Split(':')[1]);

                                Mouse.SetPosition(x, y);

                                // Reset the button with the new menu components
                                currentButton = 1;
                            }
                            // Get out of a loop
                            break;
                        }
                        else if (component is Slider slider && count == currentButton - 1)
                        {
                            // If the current component is a slider, activate it by setting its value
                            // Debug.WriteLine("SLIDER NOT IMPLEMENTED YET");
                        }
                        count++;
                    } // foreach loop


                    keyPressed = true;

                } // If Statement

                // Changing values of sliders to the left
                if ((currentKeyboardState.IsKeyDown(Keys.Left) || Input.GetButton(1, Input.ArcadeButtons.StickLeft)
                    || Input.GetButton(2, Input.ArcadeButtons.StickLeft)) && !keyPressed)
                {
                    int count = 0;
                    foreach (var component in _components)
                    {
                        if (component is Slider slider && count == currentButton - 1)
                        {
                            if (slider.Type.Equals("music"))
                            {
                                slider.Value -= 0.003f;
                            }
                            if (slider.Type.Equals("effect"))
                            {
                                slider.Value -= 0.003f;
                                sliderDownSound.Play();
                            }
                        }
                        count++;
                    } // for each statement

                } // If statement

                // Changing values of sliders to the right
                if ((currentKeyboardState.IsKeyDown(Keys.Right) || Input.GetButton(1, Input.ArcadeButtons.StickRight)
                    || Input.GetButton(2, Input.ArcadeButtons.StickRight)) && !keyPressed)
                {
                    int count = 0;
                    foreach (var component in _components)
                    {
                        if (component is Slider slider && count == currentButton - 1)
                        {
                            if (slider.Type.Equals("music"))
                            {
                                slider.Value += 0.003f;
                            }
                            if (slider.Type.Equals("effect"))
                            {
                                slider.Value += 0.003f;
                                sliderUpSound.Play();
                            }
                        }
                        count++;
                    } // for each statement
                }

                // For going back to the original menu button

            }
            // Set to false if not being pressed
            else if (keyPressed)
            {
                keyPressed = false;
            }

        } // Do Menu Controls

    } // Public class MenuState end

} // Name space end