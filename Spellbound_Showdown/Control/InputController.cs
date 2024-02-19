using Spellbound_Showdown.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Spellbound_Showdown.Control
{
    internal class InputController
    {
        private static int _gridColumn;
        private static int _gridRow;
        public static int GridColumn => _gridColumn;
        public static int GridRow => _gridRow;
        public static void Update()
        {
            GridUtility gridUtility = new GridUtility(64, 64, 20, 20);
            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                Point mousePosition = new Point(mouseState.X, mouseState.Y);
                (_gridColumn, _gridRow) = gridUtility.ScreenToGrid(mousePosition.X, mousePosition.Y);

            }

        }

    }   
}       
