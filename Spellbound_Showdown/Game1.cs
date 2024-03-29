﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using Spellbound_Showdown.Control;
using Spellbound_Showdown.Control.States;

namespace Spellbound_Showdown
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameManager _gameManager;
        private State _currentState;
        private State _nextState;

        
        public Game1()
        {
            // Setup Content Directory, graphics manager, and mouse visibility
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        
        protected override void Initialize()
        {
            // Init
            Globals.Content = Content;
            Globals.WindowSize = new(1920, 1280);
            Globals.font = Content.Load<SpriteFont>("BaseFont");
            _graphics.PreferredBackBufferWidth = Globals.WindowSize.X;
            _graphics.PreferredBackBufferHeight = Globals.WindowSize.Y;
            _graphics.ApplyChanges();
            _gameManager = new();

            base.Initialize();
            
        }
        public void ChangeState(State state)
        {
            _nextState = state;
        }
        protected override void LoadContent()
        {
            // Load sprite batch into global variable
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.SpriteBatch = _spriteBatch;

            _currentState = new Menu(this, _gameManager, _graphics.GraphicsDevice, Globals.Content);
        }

        protected override void Update(GameTime gameTime)
        {
            // Exit if escape key is pressed
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (_nextState != null)
            {
                _currentState = _nextState;

                _nextState = null;
            }

            _currentState.Update();

            _currentState.PostUpdate();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Make backround black and call gameManager draw method
            GraphicsDevice.Clear(Color.Black);

            _currentState.Draw(_gameManager, _spriteBatch);

            base.Draw(gameTime);
        }
    }
}
