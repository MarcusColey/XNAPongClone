using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BrickBreaker.Brothers
{
    class AboutScreen : Screen
    {
        GUIManager guiManager;
        string aboutText, pressExitText;
        GUITextElement uiAboutText;
        GUITextElement uiPressExitText;
        Vector2 position;
        SpriteFont font;
        SpriteBatch spriteBatch;

        public AboutScreen(Game game, SpriteBatch spriteBatch)
            : base(game, spriteBatch)
        {
            guiManager = new GUIManager(spriteBatch, this);
            this.spriteBatch = spriteBatch;
        }

        public override void Initialize()
        {
            aboutText = "Brick breaker clone created by Marcus Coley";
            font = Game.Content.Load<SpriteFont>("Fonts/BBFont");
            position = new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - (font.MeasureString(aboutText).X / 2), Game.GraphicsDevice.Viewport.Height / 2 - (font.MeasureString(aboutText)).Y / 2);
            uiAboutText = new GUITextElement(aboutText, position, font, Color.White, 2, Game);
            pressExitText = "Press Escape to return";
            uiPressExitText = new GUITextElement(pressExitText, new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - (font.MeasureString(pressExitText).X / 2), Game.GraphicsDevice.Viewport.Height / 2 + (font.MeasureString(pressExitText).Y)), font, Color.White, 99, Game);

            guiManager.AddGUIElement(uiPressExitText);
            guiManager.AddGUIElement(uiAboutText);

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                ChangeScreens(0);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            guiManager.DrawUI();

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void ChangeScreens(int screenNumber)
        {
            InvokeOnChangeScreen(screenNumber);
            base.ChangeScreens(screenNumber);
        }

    }
}
