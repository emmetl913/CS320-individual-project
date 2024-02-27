using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using Spellbound_Showdown.Control;

namespace Spellbound_Showdown
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameManager _gameManager;

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
            base.Initialize();
            Globals.WindowSize = new(1920, 1280);
            Globals.font = Content.Load<SpriteFont>("BaseFont");
            _graphics.PreferredBackBufferWidth = Globals.WindowSize.X;
            _graphics.PreferredBackBufferHeight = Globals.WindowSize.Y;
            _graphics.ApplyChanges();
            
            Globals.Content = Content;
            _gameManager = new();
        }

        protected override void LoadContent()
        {
            // Load sprite batch into global variable
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.SpriteBatch = _spriteBatch;
            
            
        }

        protected override void Update(GameTime gameTime)
        {
            // Exit if escape key is pressed
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update gameTime and gameManager
            Globals.Update(gameTime);
            _gameManager.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Make backround black and call gameManager draw method
            GraphicsDevice.Clear(Color.Black);            
            _gameManager.Draw();
            

            base.Draw(gameTime);
        }
    }
}
