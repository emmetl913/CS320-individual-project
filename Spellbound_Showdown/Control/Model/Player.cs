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
        private static int _dmg;
        public int _speed;
        private static int _range;
        private static bool _isTurn;
        private float _health;
        public Vector2 playerPos;
        public bool walk;
        public Texture2D _texture = Globals.Content.Load<Texture2D>("hero");

        public Player(Texture2D texture, Vector2 position, bool isWalkable, int dmg, int speed, int range, float health, bool isTurn) : base(texture, position, isWalkable)
        {
            // Player Constructor
            _isTurn = isTurn;
            _dmg = dmg;
            _speed = speed;
            _range = range;
            playerPos = position;
            _health = health;
            walk = IsWalkable;
        }
    }
}
