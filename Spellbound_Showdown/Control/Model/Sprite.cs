using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Spellbound_Showdown.Model
{
    internal class Sprite
    {
        private readonly Texture2D _texture;
        public Vector2 Position { get; set; }
        public Vector2 Origin { get; protected set; }
        public bool IsWalkable { get; protected set; }

        public Sprite(Texture2D texture, Vector2 position, bool isWalkable)
        {
            //Constructor for Sprite Parent
            _texture = texture;
            Position = position;
            IsWalkable = isWalkable;
        }

        // Draw Method
        public void Draw()
        {
            Globals.SpriteBatch.Draw(_texture, Position, null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0f);
        }
    }
}
