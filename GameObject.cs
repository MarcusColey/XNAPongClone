using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BrickBreaker.Brothers
{
    // Do NOT make instances of this class!
    public class GameObject
    {
        protected Texture2D sprite;

        protected Rectangle boundingBox;
        public Rectangle BoundingBox
        {
            get { return boundingBox; }
        }

        protected Vector2 position;

        // Read only
        public Vector2 Position
        {
            get { return position; }
        }

        public GameObject(Texture2D sprite,  Vector2 position, Rectangle rect)
        {
            this.sprite = sprite;
            this.boundingBox = rect;
            this.position = position;
        }

        public virtual void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(sprite, position, Color.White);
        }

        public virtual void Draw(Vector2 position, Texture2D sprite, Color color, SpriteBatch spritebatch)
        {
        }

        public virtual void Update()
        {

        }
    }
}
