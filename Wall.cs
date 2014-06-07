using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BrickBreaker.Brothers
{
    class Wall : GameObject
    {
        bool isVertical;
        public bool IsVertical
        {
            get
            {
                return isVertical;
            }
        }

        public Wall(Texture2D sprite, Vector2 position, Rectangle boundingBox, bool setVertical = false)
            : base(sprite, position, boundingBox)
        {
            isVertical = setVertical;
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
        }
    }
}
