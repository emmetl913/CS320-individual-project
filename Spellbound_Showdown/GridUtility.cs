using Spellbound_Showdown.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellbound_Showdown
{
    internal class GridUtility
    {
        private int tileX;
        private int tileY;
        private int gridX;
        private int gridY;
        


        public GridUtility(int tileX, int tileY, int gridX, int gridY)
        {
            this.tileX = tileX;
            this.tileY = tileY;
            this.gridX = gridX;
            this.gridY = gridY;
        }

        public bool IsValidGridPosition(int gridColumn, int gridRow)
        {
            return true;
        }
        public (int gridColumn, int gridRow) ScreenToGrid(int screenX, int screenY)
        {
            int gridColumn = (screenX) / gridX;
            int gridRow = (screenY) / gridY;
            return (gridColumn, gridRow);
        }
    }
}
