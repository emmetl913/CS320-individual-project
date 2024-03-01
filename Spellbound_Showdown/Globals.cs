using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Spellbound_Showdown
{
    internal class Globals
    {
        // Global variables
        public static float volumeLevel { get; set; }
        public static SpriteFont font { get; set; }
        public static SpriteFont titlefont { get; set; }
        public static float Time { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }
        public static ContentManager Content { get; set; }
        public static Point WindowSize { get; set; }
        public static void Update(GameTime gt)
        {
            Time = (float)gt.ElapsedGameTime.TotalSeconds;
        }
    }
}
