using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BrickBreaker.Brothers
{
    public class BasicBrick : Brick
    {
        public BasicBrick(Texture2D sprite, Vector2 position, Rectangle rect)
            :base(sprite, position, rect)
        {
            breakHitCount = 1;
            hitCount = 0;
            pointWorth = 5;

            Console.WriteLine("Brick Width: " + sprite.Width);
            Console.WriteLine("Brick Height: " + sprite.Height);
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
