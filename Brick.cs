using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BrickBreaker.Brothers
{
    public class Brick : GameObject
    {
        protected int breakHitCount, hitCount, pointWorth;

        public Brick(Texture2D sprite, Vector2 position, Rectangle rect)
            : base(sprite, position, rect)
        {
        }

        public virtual int GetPoints()
        {
            return pointWorth;
        }

        public virtual int Hit()
        {
            hitCount++;
            return breakHitCount - hitCount;
        }
    }
}
