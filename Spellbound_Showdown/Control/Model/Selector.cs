using SharpDX.Direct2D1;
using SharpDX.MediaFoundation;
using Spellbound_Showdown.Control;
using Spellbound_Showdown.Control.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellbound_Showdown.Model
{
    internal class Selector
    {
        private Texture2D _texture =  Globals.Content.Load<Texture2D>($"selectorY");
        public Texture2D Texture => _texture;
        private Vector2 _pos;
        public Vector2 Origin { get; protected set; }
        public Selector(Vector2 position)
        {
            _pos = position; 
        }

        // Update Method for Selector
        public void Update(Player player, Level map)
        {
            _pos = new(Mouse.GetState().X / 64, Mouse.GetState().Y/64);
            

            if (Mouse.GetState().X <= map.Tiles.Length*64)
            {

                int tileX = Mouse.GetState().X / 64;
                int tileY = Mouse.GetState().Y / 64;

                if (tileX >= 0 && tileX < map.MapSize.X/64 &&
                    tileY >= 0 && tileY < map.MapSize.Y/64)
                {
                    
                    if ((int)Vector2.Distance(player.Position / 64, new Vector2(Mouse.GetState().X / 64, Mouse.GetState().Y / 64)) <= player._speed
                        && map.Tiles[tileX, tileY].IsWalkable)
                    {
                        _texture = Globals.Content.Load<Texture2D>("selectorY");
                    }
                    else
                    {
                        _texture = Globals.Content.Load<Texture2D>("selectorN");
                    }
                }

            }
        }

        public bool tileState()
        {
            if (_texture == Globals.Content.Load<Texture2D>("selectorY")) { return true; }
            else { return false; }
        }

        public void Draw()
        {
            if (Mouse.GetState().X <= 1280)
            {
                Globals.SpriteBatch.Draw(_texture, new(_pos.X * 64, _pos.Y * 64), null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0f);
            }
        }

    }
}
