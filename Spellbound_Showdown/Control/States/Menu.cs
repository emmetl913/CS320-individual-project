using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Spellbound_Showdown;
using Spellbound_Showdown.Control.Controllers.Button;
using Spellbound_Showdown.Control.States;
using Component = Spellbound_Showdown.Component;

namespace Spellbound_Showdown.Control
{
    public class Menu : State
    {
        private List<Component> _components;

        public Menu(Game1 game, GameManager gameManager, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, gameManager, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>($"button");
            var buttonFont = Globals.font;

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2((Globals.WindowSize.X/2)-160, Globals.WindowSize.Y/3),
                Text = "New Game",
            };

            newGameButton.Click += NewGameButton_Click;

            var loadGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2((Globals.WindowSize.X/2) - 160, (Globals.WindowSize.Y / 3)+ 100),
                Text = "Options",
            };

            loadGameButton.Click += LoadGameButton_Click;

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2((Globals.WindowSize.X/2) - 160, (Globals.WindowSize.Y / 3) + 200),
                Text = "Quit Game",
            };

            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Component>()
            {
                newGameButton,
                loadGameButton,
                quitGameButton,
            };
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Load Game");
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _gameManager, _graphicsDevice, _content));
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        public override void Update()
        {
            foreach (var component in _components)
                component.Update();
        }

        public override void Draw(GameManager _gameManager, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _components)
                component.Draw(spriteBatch);
            spriteBatch.DrawString(Globals.Content.Load<SpriteFont>("TitleFont"), "Name of my game", new((Globals.WindowSize.X/4)+75, (Globals.WindowSize.Y - (Globals.WindowSize.Y-100))), Color.White);
            spriteBatch.End();
        }

        public override void PostUpdate()
        {
            
        }
    }
}