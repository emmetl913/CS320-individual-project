using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Spellbound_Showdown.Control.Controllers.Button;
using Spellbound_Showdown.Control.States;
using Component = Spellbound_Showdown.Component;

namespace Spellbound_Showdown.Control.States
{
    internal class Options : State
    {
        private List<Component> _components;
        public Options(Game1 game, GameManager gameManager, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, gameManager, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>($"button");
            var buttonFont = Globals.font;

        }

        public override void Draw(GameManager gameManager, SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void PostUpdate()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
