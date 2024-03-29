﻿using SharpDX.Direct3D9;
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
            // Constructor
            this.tileX = tileX;
            this.tileY = tileY;
            this.gridX = gridX;
            this.gridY = gridY;
        }

        public bool IsValidGridPosition(int gridColumn, int gridRow, Level map)
        {
            // Check if a given location can be moved on or not
            if (map.Tiles[gridColumn, gridRow].IsWalkable == true)
            {
                return true;
            } else 
            {
                return false;
            }
        }
        public (int gridColumn, int gridRow) ScreenToGrid(int screenX, int screenY)
        {
            // Convert screen coords to grid coords
            int gridColumn = screenX;
            int gridRow = screenY;
            return (gridColumn, gridRow);
        }
    }
}
