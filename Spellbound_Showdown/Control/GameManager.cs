using Spellbound_Showdown.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellbound_Showdown.Control
{
    internal class GameManager
    {
        private readonly Level _map;
        private readonly Player _player;

        public GameManager()
        {
            _map = new();
            _player = new(Globals.Content.Load<Texture2D>("hero"), new(Globals.WindowSize.X/2, Globals.WindowSize.Y/2), false);
        }

        public Level getMap()
        {
            return _map;
        }

        public void Update()
        {
            InputController.Update();
            _player.Position = 
        }

        public void Draw()
        {
            Globals.SpriteBatch.Begin();
            _map.Draw();
            _player.Draw();
            Globals.SpriteBatch.End();
        }
    }
}
