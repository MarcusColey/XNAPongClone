using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BrickBreaker.Brothers
{
    class MainMenuScreen : Screen
    {
        SpriteBatch spriteBatch;
        GUIManager guiManager;
        GUITextElement uiStart, uiExit, uiAbout;
        Vector2 center;
        SpriteFont font;
        string startText, exitText, settingsText, aboutText;

        public MainMenuScreen(Game game, SpriteBatch spriteBatch)
            : base(game, spriteBatch)
        {
            this.spriteBatch = spriteBatch;
            guiManager = new GUIManager(spriteBatch, this);
        }

        public override void Initialize()
        {
            Game.IsMouseVisible = true;

            font = Game.Content.Load<SpriteFont>("Fonts/BBFont");
            center = new Vector2(Game.GraphicsDevice.Viewport.Width / 2, Game.GraphicsDevice.Viewport.Height / 2);
            startText = "Start";
            exitText = "Exit to windows";
            aboutText = "About";

            uiStart = new GUITextElement(startText, new Vector2(center.X - (font.MeasureString(startText).X / 2), 100), font, Color.White, 1,this.Game);
            uiAbout = new GUITextElement(aboutText, new Vector2(center.X - (font.MeasureString(aboutText).X / 2), 175), font, Color.White, 2,this.Game); 
            uiExit = new GUITextElement(exitText, new Vector2(center.X - (font.MeasureString(exitText).X / 2), 250), font, Color.White, 3,this.Game);

            guiManager.AddGUIElement(uiStart);
            guiManager.AddGUIElement(uiAbout);
            guiManager.AddGUIElement(uiExit);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            guiManager.UpdateUI();

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
