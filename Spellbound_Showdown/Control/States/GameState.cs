using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spellbound_Showdown.Control.States;

namespace Spellbound_Showdown.Control.States
{
    internal class GameState : State
    {
        public GameState(Game1 game, GameManager gameManager, GraphicsDevice graphicsDevice, ContentManager content) 
            : base(game, gameManager, graphicsDevice, content)
        {
        }

        public override void Draw(GameManager _gameManager, SpriteBatch spriteBatch)
        {
            _gameManager.Draw();
        }

        public override void PostUpdate()
        {
            
        }

        public override void Update()
        {
            _gameManager.Update();
            if (_gameManager.getOutText() == "MENU")
            {
                _game.ChangeState(new Menu(_game, _gameManager, _graphicsDevice, _content));
                _gameManager.resetOutText();
            }
        }
    }
}
