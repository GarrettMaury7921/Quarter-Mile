using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace QuarterMile.Controls
{
    public class DialogueBox
    {
        // Attributes
        private readonly SpriteFont font;
        private readonly int iconWidth;
        private readonly int iconHeight;

        public DialogueBox(ContentManager content)
        {
            // LOAD ASSETS

            #region
#if DEBUG
            font = content.Load<SpriteFont>("Fonts/Font_Smaller");
            iconWidth = 32;
            iconHeight = 32;
#else
			font = content.Load<SpriteFont>("Fonts/Devcade_Big_Font");
            iconWidth = 96;
            iconHeight = 96;
#endif
            #endregion
        }

        public void DrawDialogue(SpriteBatch spriteBatch, string text, Vector2 position)
        {
            spriteBatch.DrawString(font, text, position, Color.White);
        }

        public void DrawDialogueBlack(SpriteBatch spriteBatch, string text, Vector2 position)
        {
            spriteBatch.DrawString(font, text, position, Color.Black);
        }

        public void DrawDialogueWithIcon(SpriteBatch spriteBatch, string text, Vector2 position, Texture2D icon)
        {
            // Draw the icon
            spriteBatch.Draw(icon, new Rectangle((int)position.X, (int)position.Y, iconWidth, iconHeight), 
                Color.White);
            spriteBatch.DrawString(font, text, position, Color.White);
        }
    }
}
