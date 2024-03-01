using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellbound_Showdown.Control.States
{
    public abstract class State
    {
        #region Fields
        protected ContentManager _content;
        protected GameManager _gameManager;
        protected GraphicsDevice _graphicsDevice;
        protected Game1 _game;
        #endregion
        #region Methods
        public abstract void Draw(GameManager gameManager, SpriteBatch spriteBatch);
        public abstract void PostUpdate();

        public State(Game1 game, GameManager gameManager, GraphicsDevice graphicsDevice, ContentManager content)
        {
            _game = game;
            _gameManager = gameManager;
            _graphicsDevice = graphicsDevice;
            _content = content;
        }
        public abstract void Update();
        #endregion
    }
}
