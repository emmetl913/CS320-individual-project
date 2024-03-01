using Spellbound_Showdown.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Spellbound_Showdown.Control.Controllers
{
    internal class InputController
    {
        private static int _gridColumn;
        private static int _gridRow;
        public static int GridColumn => _gridColumn;
        public static int GridRow => _gridRow;
        public static void Update(TurnController turnController)
        {
            // Use grid utility to determine what tile the mouse is in
            GridUtility gridUtility = new GridUtility(64, 64, 20, 20);
            MouseState mouseState = Mouse.GetState();
            // When the mouse is pressed, change gridColumn and gridRow variables
            if (mouseState.LeftButton == ButtonState.Pressed && turnController.getTurn() == TurnState.Player)
            {
                Point mousePosition = new Point(mouseState.X, mouseState.Y);
                (_gridColumn, _gridRow) = gridUtility.ScreenToGrid(mousePosition.X, mousePosition.Y);
                turnController.NextTurn();

            }

        }

    }
}
