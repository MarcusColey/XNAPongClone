using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BrickBreaker.Brothers
{
    public class Player : GameObject
    {
        int playerScore;
        int playerLives;

        public Player(Texture2D sprite, Vector2 position, Rectangle rect)
            : base(sprite, position, rect)
        {
            playerScore = 0;
            playerLives = 3;
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
        }

        public override void Update()
        {
            //Update the paddled position with either the keyboard or mouse
            position.X = Mouse.GetState().X - 50; // Move the paddle according to the mouses X position (+50 to move the paddle from its center)
            boundingBox.X = (int)position.X; // Move the bounding box with the paddle
        }

        public void AddPoints(int points)
        {
            playerScore += points;
        }

        public void AddLives(int lives)
        {
            playerLives += lives;
        }

        public int GetPoints()
        {
            return playerScore;
        }

        public int getLives()
        {
            return playerLives;
        }
    }
}
