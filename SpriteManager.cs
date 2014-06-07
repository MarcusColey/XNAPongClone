using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BrickBreaker.Brothers
{
    public class SpriteManager
    {
        List<Brick> removeList; // List of game objects to remove after looping (Cannot modify collections while looping through)
        List<GameObject> gameObjects; // Mainly walls
        List<Brick> bricks;
        List<Ball> balls;
        Game game;

        // Event that will fire when player points have changed
        public delegate void PointsChanged();
        public event PointsChanged OnPointsChanged;

        public SpriteManager(Game game)
        {
            bricks = new List<Brick>();
            removeList = new List<Brick>();
            gameObjects = new List<GameObject>();
            balls = new List<Ball>();

            this.game = game;
        }

        public void AddBrick(Brick brick)
        {
            bricks.Add(brick);
        }

        public void AddSprite(GameObject entity)
        {
            gameObjects.Add(entity);
        }

        public void AddBall(Ball ball)
        {
            balls.Add(ball);
        }

        public void Update()
        {
            foreach(GameObject entity in gameObjects)
            {
                entity.Update();
            }
        }

        public void UpdateBalls()
        {
            foreach (Ball ball in balls)
            {
                // Make the ball move
                ball.Update();
                if (ball.Position.Y > game.GraphicsDevice.Viewport.Height)
                {
                    // find the player in the list of gameobject
                    foreach (GameObject player in gameObjects) // Inefficient, I know :/!.
                    {
                        if (player.GetType() == typeof(Player))
                        {
                            Player tempPlayer = (Player)player;
                            tempPlayer.AddLives(-1);
                            OnPointsChanged();
                            if (balls.Count == 1)
                                ball.Reset();
                            else
                                balls.Remove(ball);
                        }
                    }
                }

                // Check for collision with game objects
                foreach (GameObject entity in gameObjects)
                {
                    for (int i = 1; i < 5; i++)
                    {
                        ball.Intersects(entity.BoundingBox, i);
                    }
                }

                // Update the bricks eg, check fir collision
                foreach(Brick brick in bricks)
                {
                    for (int i = 1; i < 5; i++)
                    {
                        if (ball.Intersects(brick.BoundingBox, i) && brick.Hit() <= 0)
                        {
                            removeList.Add(brick);
                        }
                    }
                }

            }

            // Destroy all bricks that have been hit
            DestroyEntities(removeList);
        }

        void DestroyEntities(List<Brick> removeList)
        {
            foreach (Brick entity in removeList)
            {

                // find the player gameobject and add score
                foreach (GameObject player in gameObjects) // Inefficient, I know :/.
                {
                    if(player.GetType() == typeof(Player))
                    {
                        Player tempPlayer = (Player)player;
                        tempPlayer.AddPoints(entity.GetPoints());
                        OnPointsChanged();
                    }
                }

                bricks.Remove(entity);
            }
            removeList.RemoveRange(0, removeList.Count); // Remove all objects from the list to stop infinite point adding
        }

        // All drawing is done here
        public void Draw(SpriteBatch spritebatch)
        {
            // Draw game objects (Walls mainly)
            foreach (GameObject entity in gameObjects)
            {
                entity.Draw(spritebatch);
            }

            // Draw bricks
            foreach (Brick brick in bricks)
            {
                brick.Draw(spritebatch);
            }

            //Draw the ball
            foreach (Ball ball in balls)
            {
                ball.Draw(spritebatch);
            }
        }
    }
}
