using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BrickBreaker.Brothers
{
    class GUIElement
    {
        public GUIElement(Game game)
        {
        }

        protected Rectangle boundingBox;
        public Rectangle BoundingBox
        {
            get { return boundingBox; }
        }

        public virtual void CheckBounds(Rectangle reference, Screen sender = null)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
