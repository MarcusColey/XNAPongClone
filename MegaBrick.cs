using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BrickBreaker.Brothers
{
    class MegaBrick : Brick
    {
        public MegaBrick(Texture2D sprite, Vector2 position, Rectangle boundingBox)
            : base(sprite, position, boundingBox)
        {
            breakHitCount = 3;
            hitCount = 0;
            pointWorth = 25;
        }

        public override int Hit()
        {
            return base.Hit();
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
        }
    }
}
