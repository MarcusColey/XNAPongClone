using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BrickBreaker.Brothers
{
    class GUITextElement : GUIElement
    {
        Color textColour;
        Color hightlightColour;

        Color drawColour;
        SpriteFont font;
        int screenCallbackNumber;

        public GUITextElement(string text, Vector2 position, SpriteFont spriteFont , Color color, int screenCallbackNumber ,Game game)
            :base(game)
        {
            this.screenCallbackNumber = screenCallbackNumber;

            this.position = position;
            this.text = text;

            textColour = color;
            drawColour = textColour;
            this.font = spriteFont;

            hightlightColour = Color.Yellow;

            boundingBox = new Rectangle((int)position.X, (int)position.Y, (int)font.MeasureString(text).X, (int)font.MeasureString(text).Y);
        }

        string text;
        public string Text
        {
            get { return text; }
        }

        Vector2 position;
        public Vector2 Position
        {
            get { return position; }
        }
        public override void CheckBounds(Rectangle reference, Screen sender = null)
        {
            if (reference.Intersects(this.boundingBox))
            {
                Highlight(true);

                if (sender != null && Mouse.GetState().LeftButton == ButtonState.Pressed)
                    sender.ChangeScreens(screenCallbackNumber);
            }
            else
                Highlight(false);
        }

        public void Highlight(bool enable)
        {
            if (enable)
                drawColour = hightlightColour;
            else
                drawColour = textColour;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, position, drawColour);
        } 
    }
}
