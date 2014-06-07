using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BrickBreaker.Brothers
{
    class ExitScreen : Screen
    {
        public ExitScreen(Game game, SpriteBatch spriteBatch)
            : base(game, spriteBatch)
        {
           
        }

        public override void Update(GameTime gameTime)
        {
            this.Game.Exit();
            base.Update(gameTime);
        }
    }
}
