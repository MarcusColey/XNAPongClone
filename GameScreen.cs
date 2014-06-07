using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BrickBreaker.Brothers
{
    class GameScreen : Screen
    {
        SpriteBatch spriteBatch;

        //Fields
        ContentLoader loader; // Load all basic content
        SpriteManager spriteManager; // Manages all sprite game objects
        Player player;

        // gui Manager to display points and lives;
        GUIManager guiManager;
        GUITextElement uiPoints;
        GUITextElement uiLives;
        Vector2 pointsPos;
        Vector2 livesPos;
        SpriteFont font;
        string pointsText, livesText;

        public GameScreen(Game game, SpriteBatch spriteBatch)
            : base(game, spriteBatch)
        {
            game.IsMouseVisible = false;
            this.spriteBatch = spriteBatch;

            guiManager = new GUIManager(spriteBatch, this);
        }

        public override void Initialize()
        {
            //spriteManager = new SpriteManager(this.Game);
            loader = new ContentLoader(this.Game, spriteManager = new SpriteManager(this.Game));
            // Retrieve the player object from 'loader' for later use
            player = loader.Player;

            pointsText = "Points: " + player.GetPoints();
            livesText = "Lives: " + player.getLives();

            pointsPos = new Vector2(10, 10);
            font = Game.Content.Load<SpriteFont>("Fonts/BBFont");
            livesPos = new Vector2(Game.GraphicsDevice.Viewport.Width - (font.MeasureString(livesText).X + 15), 10);

            uiPoints = new GUITextElement(pointsText, pointsPos, font, Color.White, 99, this.Game);
            uiLives = new GUITextElement(livesText, livesPos, font, Color.White, 99, this.Game);

            guiManager.AddGUIElement(uiPoints);
            guiManager.AddGUIElement(uiLives);
          
            spriteManager.OnPointsChanged += UpdatePoints;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);

            Game.Components.Add(loader);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            spriteManager.Update();
            spriteManager.UpdateBalls();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            guiManager.DrawUI();
            spriteManager.Draw(spriteBatch);
            

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void UpdatePoints()
        {
            // Update the ui elements with the proper score nad life count
            guiManager.RemoveAllGUIElements();
            
            pointsText = "Points: " + player.GetPoints();
            livesText = "Lives: " + player.getLives();

            uiPoints = new GUITextElement(pointsText, pointsPos, font, Color.White, 99, this.Game);
            uiLives = new GUITextElement(livesText, livesPos, font, Color.White, 99, this.Game);

            guiManager.AddGUIElement(uiPoints);
            guiManager.AddGUIElement(uiLives);
        }
    }
}
