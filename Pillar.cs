using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project3
{
    class Pillar
    {
        public Texture2D texture;
        public Vector2 position;
        public Color pillarColor;
        public Vector2 initialPosition;

        public Pillar(Texture2D newTexture, Vector2 newPosition, Color newColor)
        {
            texture = newTexture;
            initialPosition = newPosition;
            position = newPosition;
            pillarColor = newColor;
        }

        public void Update()
        {
            if(Keyboard.GetState().IsKeyDown(Keys.A)|| Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                position = initialPosition;
                initialPosition.X -= 50f;
            }
            else if(Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                position = initialPosition;
                initialPosition.X += 50f;
            }
            else if(Keyboard.GetState().IsKeyUp(Keys.A) || Keyboard.GetState().IsKeyUp(Keys.Left)||Keyboard.GetState().IsKeyUp(Keys.D) || Keyboard.GetState().IsKeyUp(Keys.Right))
            {
                initialPosition = position;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)initialPosition.X, (int)initialPosition.Y, texture.Width, 100), null, pillarColor, 0f, new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.None, 0f);
        }
    }
}
