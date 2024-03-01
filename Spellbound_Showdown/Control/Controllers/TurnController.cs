using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellbound_Showdown.Control.Controllers
{
    public enum TurnState
    { 
        Player,
        Enemy,
    }
    internal class TurnController
    {
        public static bool win = false;
        private TurnState currentTurn;
        public TurnController()
        { 
            currentTurn = TurnState.Player;
        }

        public void NextTurn()
        {
            switch (currentTurn)
            { 
                case TurnState.Player:
                    currentTurn = TurnState.Enemy;
                    break;
                case TurnState.Enemy:
                    currentTurn -= TurnState.Player;
                    break;
            }
        }

        public TurnState getTurn()
        {
            return currentTurn;
        }
    }
}
