using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BrickBreaker.Brothers
{
    /// <summary>
    /// Handles loading all basic game content
    /// </summary>
    class ContentLoader : GameComponent
    {
        Game game;
        SpriteManager spriteManager;
        MapReader mapReader;

        public Player Player
        {
            get { return player; }
        }

        // Player Variables
        Player player;
        Texture2D texture;
        Rectangle boundingBox;
        Vector2 position;

        //Brick Variables
        BasicBrick brick;
        Texture2D brickTexture;
        Rectangle brickBoundingBox;
        Vector2 brickPos;

        SuperBrick superBrick;
        Texture2D superBrickTexture;
        Vector2 superBrickPos;
        Rectangle superBrickRect;

        MegaBrick megaBrick;
        Texture2D megaBrickTexture;
        Vector2 megaBrickPos;
        Rectangle megaBrickRect;

        //Ball Variables
        Ball ball;
        Texture2D ballTexture;
        Rectangle ballBoundingBox;
        Vector2 ballPos;

        //wall Variables
        Wall wLeft, wRight, wCeiling;
        Texture2D wLeftTexture, wRightTexture, wCeilingTexture;
        Rectangle wLeftBB, wRightBB, wCeilingBB;
        Vector2 wLeftPos, wRightPos, wCeilingPos;

        public ContentLoader(Game game, SpriteManager spriteManager)
            : base(game)
        {
            this.game = game;
            this.spriteManager = spriteManager;
            InitializeAssets();
        }

        void InitializeAssets()
        {
            // Create basic game objects
            player = new Player(texture = game.Content.Load<Texture2D>("Sprites/Paddle"), position = new Vector2(game.GraphicsDevice.Viewport.Width / 2, game.GraphicsDevice.Viewport.Height - 25), boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height));

            brick = new BasicBrick(brickTexture = game.Content.Load<Texture2D>("Sprites/BasicBrick"), brickPos = new Vector2(game.GraphicsDevice.Viewport.Width / 2, game.GraphicsDevice.Viewport.Height / 2), brickBoundingBox = new Rectangle((int)brickPos.X, (int)brickPos.Y, brickTexture.Width, brickTexture.Height));
            superBrick = new SuperBrick(superBrickTexture = game.Content.Load<Texture2D>("Sprites/SuperBrick"), superBrickPos = Vector2.Zero, superBrickRect = new Rectangle());
            megaBrick = new MegaBrick(megaBrickTexture = game.Content.Load<Texture2D>("Sprites/MegaBrick"), megaBrickPos = Vector2.Zero, megaBrickRect = new Rectangle());

            mapReader = new MapReader(brickTexture, superBrickTexture, megaBrickTexture, spriteManager);

            ball = new Ball(ballTexture = game.Content.Load<Texture2D>("Sprites/Ball"), ballPos = new Vector2(player.Position.X + player.Position.X / 2, game.GraphicsDevice.Viewport.Height - 30 - ballTexture.Height), ballBoundingBox = new Rectangle((int)ballPos.X, (int)ballPos.Y, ballTexture.Width, ballTexture.Height));

            // Create and initialize walls
            wLeft = new Wall(wLeftTexture = game.Content.Load<Texture2D>("Sprites/WallLeft"), wLeftPos = new Vector2(0, 0), wLeftBB = new Rectangle(0, 0, wLeftTexture.Width, wLeftTexture.Height), true);
            wRight = new Wall(wRightTexture = game.Content.Load<Texture2D>("Sprites/WallRight"), wRightPos = new Vector2(game.GraphicsDevice.Viewport.Width - wRightTexture.Width, 0), wRightBB = new Rectangle(game.GraphicsDevice.Viewport.Width - wRightTexture.Width, 0, wRightTexture.Width, wRightTexture.Height), true);
            wCeiling = new Wall(wCeilingTexture = game.Content.Load<Texture2D>("Sprites/Ceiling"), wCeilingPos = new Vector2(0, 0), wCeilingBB = new Rectangle(0, 0, wCeilingTexture.Width, wCeilingTexture.Height));

            DisplayAssets();
        }

        void DisplayAssets()
        {
            spriteManager.AddSprite(player);
            spriteManager.AddBrick(brick);
            spriteManager.AddBall(ball);

            spriteManager.AddSprite(wLeft);
            spriteManager.AddSprite(wRight);
            spriteManager.AddSprite(wCeiling);
        }

    }
}
