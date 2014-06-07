using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BrickBreaker.Brothers
{
    class LoadingScreen : Screen
    {
        SpriteBatch spriteBatch;
        GUIManager guiManager;
        GUITextElement uiLoadingText;
        SpriteFont font;
        string loadingText;

        public LoadingScreen(Game game, SpriteBatch spriteBatch)
            : base(game, spriteBatch)
        {
            this.spriteBatch = spriteBatch;
            guiManager = new GUIManager(spriteBatch, this);
        }

        public override void Initialize()
        {
            loadingText = "Loading...";
            font = Game.Content.Load<SpriteFont>("Fonts/BBFont");
            uiLoadingText = new GUITextElement(loadingText, new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - (font.MeasureString(loadingText).X), Game.GraphicsDevice.Viewport.Height / 2 - (font.MeasureString(loadingText).Y)), font, Color.White, 99, Game);
            guiManager.AddGUIElement(uiLoadingText);

            base.Initialize();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            spriteBatch.Begin();

            guiManager.DrawUI();

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
