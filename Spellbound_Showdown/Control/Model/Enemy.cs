using SharpDX.MediaFoundation;
using SharpDX.MediaFoundation.DirectX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Spellbound_Showdown.Model
{
    internal class Enemy : Sprite
    {
        public Vector2 pos;
        public bool walk;
        private int _speed;
        private int _dmg;
        private int _range;
        private bool _isTurn;
        private float _health;
        public Enemy(Texture2D texture, Vector2 position, bool isWalkable, int speed, int dmg, int range, float health, bool isTurn) : base(texture, position, isWalkable)
        {
            // Constructor for enemy stats
            pos = position;
            walk = IsWalkable;
            _speed = speed;
            _dmg = dmg;
            _range = range;
            _health = health;
        }

        public static void MyTurn()
        { 
            
        }

        public static void Update()
        { 
            
        }
    }
}
