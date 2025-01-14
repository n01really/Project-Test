﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project_Test
{
    public class Game1 : Game
    {
        Texture2D playerTexture;
        Vector2 playerPosition;
        float playerSpeed;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            playerPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, 
                                         _graphics.PreferredBackBufferHeight / 2);
            playerSpeed = 200f;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            playerTexture = Content.Load<Texture2D>("player");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            float updatedPlayerSpeed = playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
            {
                playerPosition.Y -= updatedPlayerSpeed;
            }

            if (kstate.IsKeyDown(Keys.Down))
            {
                playerPosition.Y += updatedPlayerSpeed;
            }

            if (kstate.IsKeyDown(Keys.Left))
            {
                playerPosition.X -= updatedPlayerSpeed;
            }

            if (kstate.IsKeyDown(Keys.Right))
            {
                playerPosition.X += updatedPlayerSpeed;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);



            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(playerTexture, 
                playerPosition, 
                null, 
                Color.White, 
                0f, 
                new Vector2(playerTexture.Width / 2, playerTexture.Height /2), 
                Vector2.One, 
                SpriteEffects.None, 
                0f);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
