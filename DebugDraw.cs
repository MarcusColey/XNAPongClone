using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BrickBreaker.Brothers
{
    public class DebugDraw : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D dummyTexture;
        Rectangle dummyRectangle;
        Color Colori;

        GameObject go;

        public DebugDraw(GameObject go, Color colori, Game game)
            : base(game)
        {
            // Choose a high number, so we will draw on top of other components.
            DrawOrder = 1000;
            dummyRectangle = go.BoundingBox;
            Colori = colori;
            this.go = go;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            dummyTexture = new Texture2D(GraphicsDevice, 1, 1);
            dummyTexture.SetData(new Color[] { Color.White });
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            dummyRectangle = go.BoundingBox;
            spriteBatch.Draw(dummyTexture, dummyRectangle, Colori);
            spriteBatch.End();
        }
    }
}
