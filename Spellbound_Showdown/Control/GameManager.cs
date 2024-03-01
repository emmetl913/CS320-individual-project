using SharpDX.Direct3D9;
using Spellbound_Showdown.Control.Controllers;
using Spellbound_Showdown.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Spellbound_Showdown.Control
{
    public class GameManager
    {
        private readonly Level _map;
        private readonly Player _player;
        private readonly Enemy _enemy;
        private readonly Selector _selector;
        GridUtility gridUtility = new GridUtility(64, 64, 20, 20);
        Textbox _textbox = new(Globals.Content.Load<Texture2D>("backround"), new(1280, 900, 640, 180));
        TurnController _turnController;

        public GameManager()
        {
            // Constructor for player & enemy position variables & map creation
            Vector2 playerStartPos = new Vector2();
            Vector2 enemyStartPos = new Vector2();
            _map = new();
            _turnController = new(); 

            // Find first available tile for player and enemy spawn location
            for (int i = 0; i < 20; i++)
            {
                if (_map.Tiles[i, 0].IsWalkable == true) { playerStartPos = new(i * 64, 0); }
                if (_map.Tiles[i, 19].IsWalkable == true) { enemyStartPos = new(i * 64, 19 * 64); }
            }
            // Constructor for enemy, player, and selector
            _player = new(Globals.Content.Load<Texture2D>("hero"), playerStartPos, false, 3, 5, 4, 10, true);
            _enemy = new(Globals.Content.Load<Texture2D>("skeleton"), enemyStartPos, false, 5, 2, 4, 8, false);
            _selector = new(playerStartPos);
        }

        

        // Update Method
        public void Update()
        {
            // Check for left click button press
            InputController.Update(_turnController);

            // Update Text/Textbox
            TextController.Update(_textbox.GetText(), _turnController);
            _textbox.Update();

            // Adjust Player position based on user input and check if the move is valid
            Vector2 temp = new Vector2(InputController.GridColumn / 64 * 64, InputController.GridRow / 64 * 64);
            int row = InputController.GridRow / 64;
            int col = InputController.GridColumn / 64;
            _selector.Update(_player, _map);

            if ((int)Vector2.Distance(_player.Position / 64, new Vector2(Mouse.GetState().X / 64, Mouse.GetState().Y / 64)) <= _player._speed)
            {
                if (row >= 0 && row < _map.Tiles.GetLength(0) &&
                    col >= 0 && col < _map.Tiles.GetLength(1) &&
                    _map.Tiles[col, row].IsWalkable)
                {
                    _player.Position = temp;
                }
            }

            _enemy.MyTurn(_turnController, _player);


        }

        // Get and Reset Methods for text input
        public string getOutText()
        {
            return _textbox.GetText();
        }
        public void resetOutText()
        {
            _textbox.setText(" ");
        }

        // Draw Method
        public void Draw()
        {
            Globals.SpriteBatch.Begin();

            // Draw Sprites
            _map.Draw();
            _player.Draw();
            _enemy.Draw();
            _textbox.Draw();
            _selector.Draw();
            
            // Draw Text
            TextController.Draw();
            Globals.SpriteBatch.DrawString(Globals.font, InputController.GridColumn / 64 + 1 + "," + (InputController.GridRow / 64 + 1),
                new Vector2(Globals.WindowSize.X - 100, 20), Color.White);

            // Draw Text for Testing
            Globals.SpriteBatch.DrawString(Globals.font, "Player: " + _player.Position.X / 64 + " , " + _player.Position.Y / 64,
                new Vector2(Globals.WindowSize.X - 250, 50), Color.White);
            Globals.SpriteBatch.DrawString(Globals.font, "Mouse: " + Mouse.GetState().X / 64 + " , " + Mouse.GetState().Y / 64,
               new Vector2(Globals.WindowSize.X - 250, 100), Color.White);
            Globals.SpriteBatch.DrawString(Globals.font, "Vector: " + (int)Vector2.Distance(_player.Position / 64, new Vector2(Mouse.GetState().X / 64, Mouse.GetState().Y / 64)),
               new Vector2(Globals.WindowSize.X - 250, 150), Color.White);
            Globals.SpriteBatch.DrawString(Globals.font, "Turn Counter: " + _turnController.getTurn(),
               new Vector2(Globals.WindowSize.X - 350, 200), Color.White);
            Globals.SpriteBatch.End();
        }
    }
}
