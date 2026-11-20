using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Monogame_2._5___Mouse_Clicks
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Rectangle window;
        Texture2D quitButtonTexture;
        Rectangle quitButtonRect;
        MouseState mouseState;
        MouseState prevMouseState;
        Color buttonColor;
        Random generator = new Random();
        int randX, randY;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, 800, 500);
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.PreferredBackBufferWidth = window.Width;
            this.Window.Title = "The quitting game";
            buttonColor = Color.White;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            quitButtonTexture = Content.Load<Texture2D>("quitbutton");
            randX = window.Width / 2 - 100;
            randY = window.Height / 2 - 50;
            quitButtonRect = new Rectangle(randX, randY, 200, 100);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            quitButtonRect = new Rectangle(randX, randY, 200, 100);
            prevMouseState = mouseState;
            mouseState = Mouse.GetState();
            if (quitButtonRect.Contains(mouseState.Position))
            {
                buttonColor = Color.Yellow;
                randX = generator.Next(0, 601);
                randY = generator.Next(0, 401);
            }
            else
            {
                buttonColor = Color.White;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
            {
                if (quitButtonRect.Contains(mouseState.Position))
                    Exit();
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.PaleGoldenrod);


            _spriteBatch.Begin();

            _spriteBatch.Draw(quitButtonTexture, quitButtonRect, buttonColor);

            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
