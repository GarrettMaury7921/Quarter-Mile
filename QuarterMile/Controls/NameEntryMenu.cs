using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace QuarterMile.Controls
{
    public class NameEntryMenu
    {
        // Attributes
        private readonly string alphabet;
        private readonly SpriteFont spriteFont;
        public char[] chars;
        private string savedLetter;

        public void SetLetter(string letter)
        {
            savedLetter = letter;
        }

        public string GetLetter()
        {
            return savedLetter;
        }

        public NameEntryMenu(ContentManager content)
        {
            spriteFont = content.Load<SpriteFont>("Fonts/Font_BIG");
            alphabet = " abcdefghijklmnopqrstuvwxyz1234567890!@#$%^&*()-=_[]{}|;':,.<>/?`~";

            // Get alphabet into an array
            chars = alphabet.ToCharArray();
        }

        public void DrawUnderline(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.DrawString(spriteFont, "_", position, Color.White);
        }
        public void DrawLetter(SpriteBatch spriteBatch, int index, Vector2 position)
        {
            spriteBatch.DrawString(spriteFont, chars[index].ToString(), position, Color.White);
            SetLetter(chars[index].ToString());
        }

    } // pubic class

} // name space
