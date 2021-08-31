using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project3
{
    class Character
    {
        public Texture2D texture;
        public Vector2 velocity;
        public Vector2 position;

        public bool isVisible = true;

        public Character(Texture2D newTexture,Vector2 newPosition)
        {
            texture = newTexture;
            position = newPosition;
            velocity = new Vector2(0, 2);
        }

        public void Update(GraphicsDevice graphicsDevices)
        {
            position += velocity;

            if(position.Y>graphicsDevices.Viewport.Height)
            {
                isVisible = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, 100, 100), null, Color.White, 0f, new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.None, 0f);
        }


    }
}
