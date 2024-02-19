using SharpDX.Direct3D9;
using Spellbound_Showdown.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Spellbound_Showdown.Control
{
    internal class GameManager
    {
        private readonly Level _map;
        private readonly Player _player;
        GridUtility gridUtility = new GridUtility(64, 64, 20, 20);
        Textbox _textbox = new(Globals.Content.Load<Texture2D>("mountain"), new(1280, 900, 640, 180));
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
            TextController.Update(_textbox.GetText());
            _textbox.Update();
            Vector2 temp = new Vector2((InputController.GridColumn/64)*64, (InputController.GridRow/64)*64);
            int row = InputController.GridRow / 64;
            int col = InputController.GridColumn / 64;
            if (row >= 0 && row < _map.Tiles.GetLength(0) &&
                col >= 0 && col < _map.Tiles.GetLength(1) &&
                _map.Tiles[col, row].IsWalkable)
            {
                _player.Position = temp;
            }
            
        }

        public void Draw()
        {
            Globals.SpriteBatch.Begin();
            _map.Draw();
            _player.Draw();
            _textbox.Draw();
            TextController.Draw();
            Globals.SpriteBatch.DrawString(Globals.font, ((InputController.GridColumn/64)+1) + "," + ((InputController.GridRow/64)+1),
                new Vector2((Globals.WindowSize.X-100), 20), Color.White);
            Globals.SpriteBatch.End();
        }
    }
}
