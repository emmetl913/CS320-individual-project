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
            float row = player.Position.X / 64;
            float col = player.Position.Y / 64;

            if (Mouse.GetState().X <= map.Tiles.Length)
            {
                int mouseX = Mouse.GetState().X;
                int mouseY = Mouse.GetState().Y;

                int tileX = mouseX / 64;
                int tileY = mouseY / 64;

                if (tileX >= 0 && tileX < map.MapSize.X &&
                    tileY >= 0 && tileY < map.MapSize.Y)
                {
                    
                    if ((int)Vector2.Distance(new(row, col), new Vector2(tileX, tileY)) <= player._speed
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

        public void Draw()
        {
            if (Mouse.GetState().X <= 1280)
            {
                Globals.SpriteBatch.Draw(_texture, new(_pos.X * 64, _pos.Y * 64), null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0f);
            }
        }

    }
}
