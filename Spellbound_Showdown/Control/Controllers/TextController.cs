using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spellbound_Showdown.Control.Controllers
{
    internal class TextController
    {
        private static string _outText;
        public string OutText => _outText;

        public static void Update(string _text, TurnController turnController)
        {
            // Take the inputed text and check if it matches a possible move

            if (_text == "ATTACK")
            {
                _outText = "You Attack!";
                turnController.NextTurn();
            }
            else if (_text == "HEAL")
            {
                _outText = "You Heal!";
                turnController.NextTurn();
            }
            else if (_text == "BLOCK")
            {
                _outText = "You Block!";
                turnController.NextTurn();
            }
            else if (_text == "MENU")
            {
                _outText = "Returning to Menu";
            }
               
            
        }

       

        // Draw method for text
        public static void Draw()
        {
            if (_outText != null) Globals.SpriteBatch.DrawString(Globals.font, _outText, new(1280, 1000), Color.Black);
        }
    }
}
