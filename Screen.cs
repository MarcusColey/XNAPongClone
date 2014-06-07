using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BrickBreaker.Brothers
{
    class Screen : DrawableGameComponent
    {
        public delegate void ChangeScreen(int screenNumber);
        public event ChangeScreen OnChangeScreen;

        public Screen(Game game, SpriteBatch spritBatch)
            : base(game)
        {
            
        }

        public virtual void ChangeScreens(int screenNumber)
        {
        }

        protected void InvokeOnChangeScreen(int screenNumber)
        {
            OnChangeScreen(screenNumber);
        }
    }
}
