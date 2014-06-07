using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BrickBreaker.Brothers
{
    public class Ball : GameObject
    {
        Vector2 startingPosition;
        Vector2 velocity;
        Random rand;

        // bool flag letting us know that the LM button wasnt pressed last frame
        bool wasButtonDown;

        public Ball(Texture2D sprite, Vector2 position, Rectangle rect)
            : base(sprite, position, rect)
        {
            startingPosition = position;
            rand = new Random();
            wasButtonDown = false;
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
        }

        public override void Update()
        {
            if (velocity != Vector2.Zero)
            {
                position += velocity;
                boundingBox.X = (int)position.X;
                boundingBox.Y = (int)position.Y;
            }
            else
            {
                position.X = Mouse.GetState().X - sprite.Width / 2;
            }

            if (wasButtonDown == true && velocity == Vector2.Zero && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                // Uncomment for release
                //velocity = new Vector2(rand.Next(-6, -1), rand.Next(-6, -1));

                velocity = new Vector2(2, -3);
            }

            // Make sure the LMB was realeased last frame so the user can click to launch the ball properly
            wasButtonDown = Mouse.GetState().LeftButton == ButtonState.Released;
        }

        /// <summary>
        /// Side key's: 1:Right 2:Left 3:Top 4:Bottom
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="side"></param>
        /// <returns></returns>
        public bool Intersects(Rectangle reference, int side)
        {
            switch (side)
            {
                case 1:
                {
                    if (this.boundingBox.Right >= reference.X && this.boundingBox.X <= reference.X && this.boundingBox.Y >= reference.Y && boundingBox.Y + this.boundingBox.Height <= reference.Bottom)
                    {
                        xBounce();
                        return true;
                    }
                    else
                        return false;
                }
                case 2:
                {
                    if (this.boundingBox.Left <= reference.Right && this.boundingBox.X + this.boundingBox.Width >= reference.X + reference.Width && this.boundingBox.Y >= reference.Y && this.boundingBox.Y + this.boundingBox.Height <= reference.Bottom)
                    {
                        xBounce();
                        return true;
                    }
                    else
                        return false;
                }
                case 3:
                {
                    if (this.boundingBox.Top <= reference.Bottom && this.boundingBox.Y >= reference.Y && this.boundingBox.X >= reference.X && (this.boundingBox.X + this.boundingBox.Width) <= (reference.X + reference.Width))
                    {
                        Bounce();
                        return true;
                    }
                    else
                        return false;
                }
                case 4:
                {
                    if ((this.boundingBox.Y + this.boundingBox.Height) >= (reference.Y) && this.boundingBox.Y <= reference.Y && this.boundingBox.X >= reference.X && (this.boundingBox.X + this.boundingBox.Width) <= (reference.X + reference.Width))
                    {
                        Bounce();
                        return true;
                    }
                    else
                        return false;
                }
                default:
                    return false;
            }
        }

        public void Reset()
        {
            velocity = Vector2.Zero;
            position = startingPosition;
        }

        public void xBounce()
        {
            velocity.X *= -1;
        }

        public void Bounce()
        {
            velocity.Y *= -1;
        }
    }
}
