using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellbound_Showdown.Model
{

    internal class Player : Sprite
    {
        // Setup
        public const float speed = 5;
        private Vector2 _minPos, _maxPos;
        public Vector2 playerPos;
        public bool walk;
        public Texture2D _texture = Globals.Content.Load<Texture2D>("hero");

        public Player(Texture2D texture, Vector2 position, bool isWalkable) : base(texture, position, isWalkable)
        {
            playerPos = position;
            walk = IsWalkable;
        }

        public void SetBounds(Point mapSize, Point tileSize)
        {
            _minPos = new Vector2((-tileSize.X / 2) + Origin.X, (-tileSize.Y / 2) + Origin.Y);
            _maxPos = new Vector2(mapSize.X - (tileSize.X / 2) - Origin.X, mapSize.Y - (tileSize.Y) - Origin.Y);
        }

    }
}
