using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spellbound_Showdown.Control
{
    internal class TextController
    {
        private static string _outText;

        public static void Update(string _text)
        {
            
            if (_text == "ATK")
            {
                _outText = "You Attack!";
            }
            else if (_text == "HEAL")
            {
                _outText = "You Heal!";
            }
            else if (_text == "BLOCK")
            {
                _outText = "You Block!";
            }
        }

        public static void Draw()
        {
            if (_outText != null) Globals.SpriteBatch.DrawString(Globals.font, _outText, new(1280, 1000), Color.Black);
        }
    }
}
