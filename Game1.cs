using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Project3
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D background;
        private Texture2D pillarTexture;

        private Texture2D[] characterTextures = new Texture2D[2];
        private Vector2[] spawnPositions = new Vector2[3];
        private Vector2[] pillarPosition = new Vector2[4];
        private Color[] pillarColors = new Color[4];

        private List<Character> characters = new List<Character>();
        private List<Pillar> pillars = new List<Pillar>();

        private float spawnTime = 0f;
        private bool pillarsCreated = false;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        
        }

        protected override void Initialize()
        {
            spawnPositions[0] = new Vector2(GraphicsDevice.Viewport.Width/4-25, 0);
            spawnPositions[1] = new Vector2(GraphicsDevice.Viewport.Width / 2, 0);
            spawnPositions[2] = new Vector2((3*(GraphicsDevice.Viewport.Width / 4))+25, 0);

            pillarPosition[0] = new Vector2(0, GraphicsDevice.Viewport.Height * 0.8f);
            pillarPosition[1] = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height * 0.6f);
            pillarPosition[2] = new Vector2(0, GraphicsDevice.Viewport.Height * 0.4f);
            pillarPosition[3] = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height * 0.2f);

            pillarColors[0] = Color.Yellow;
            pillarColors[1] = Color.Blue;
            pillarColors[2] = Color.Green;
            pillarColors[3] = Color.Red;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("Map");
            pillarTexture = Content.Load<Texture2D>("Pillars");
            characterTextures[0] = Content.Load<Texture2D>("Human");
            characterTextures[1] = Content.Load<Texture2D>("Monster");
        }

        protected override void Update(GameTime gameTime)
        {
            if (!pillarsCreated)
            {
                for (int i = 0; i < 4; i++)
                {
                    pillars.Add(new Pillar(pillarTexture, pillarPosition[i], pillarColors[i]));
                }
                pillarsCreated = true;
            }

            spawnTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            foreach(Character character in characters )
            {
                character.Update(GraphicsDevice);
            }
            foreach (Pillar pillar in pillars)
            {
                pillar.Update();
            }
            if (spawnTime>=2)
            {
                spawnTime = 0;
                for(int i=0;i<3;i++)
                {
                    characters.Add(new Character(characterTextures[new Random().Next(0, 2)], spawnPositions[i]));
                }
            }

            for(int i=0;i<characters.Count;i++)
            {
                if(!characters[i].isVisible)
                {
                    characters.RemoveAt(i);
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
           
            _spriteBatch.Begin();
            _spriteBatch.Draw(background, new Rectangle(0,0, GraphicsDevice.Viewport.Bounds.Width,GraphicsDevice.Viewport.Bounds.Height),Color.White);
            foreach(Character character in characters)
            {
                character.Draw(_spriteBatch);
            }
            foreach (Pillar pillar in pillars)
            {
                pillar.Draw(_spriteBatch);
            }
            _spriteBatch.End();
        }
    }
}
