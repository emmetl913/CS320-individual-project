﻿using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellbound_Showdown.Model
{
    internal class Level
    {

        private readonly Point _mapTileSize = new(20, 20);

        private readonly Sprite[,] _tiles;
        public Sprite[,] Tiles => _tiles;

        public Point TileSize { get; private set; }
        public Point MapSize { get; private set; }

        // Map Setup
        public Level()
        {
            // Create a new array that is the tile size (20x20)
            _tiles = new Sprite[_mapTileSize.X, _mapTileSize.Y];

            // Fill textures list with possible textures for tilemap
            List<Texture2D> textures = new(5)
            {
                Globals.Content.Load<Texture2D>($"walkable1"),
                Globals.Content.Load<Texture2D>($"walkable2"),
                Globals.Content.Load<Texture2D>($"walkable3"),
                Globals.Content.Load<Texture2D>($"unwalkable1"),
                Globals.Content.Load<Texture2D>($"unwalkable1")
            };

            // Create two Vector2 variables for pixel size of tile, and pixel size of tilemap 
            TileSize = new(textures[0].Width, textures[0].Height);
            MapSize = new(TileSize.X * _mapTileSize.X, TileSize.Y * _mapTileSize.Y);

            Random random = new Random();

            // Fill the map with a Random selection of tiles 
            for (int y = 0; y < _mapTileSize.Y; y++)
            {
                for (int x = 0; x < _mapTileSize.X; x++)
                {
                    int r = random.Next(0, textures.Count);
                    if (r != 3) _tiles[x, y] = new(textures[r], new(x * TileSize.X, y * TileSize.Y), true);
                    if (r >= 3 ) _tiles[x, y] = new(textures[r], new(x * TileSize.X, y * TileSize.Y), false);
                    //if (r == 4) _tiles[x, y] = new(textures[r], new(x * TileSize.X, y * TileSize.Y), false);
                }
            }


        }


        // Draw method for tilemap
        public void Draw()
        {
            for (int y = 0; y < _mapTileSize.Y; y++)
            {
                for (int x = 0; x < _mapTileSize.X; x++)
                {
                    _tiles[x, y].Draw();

                }
            }


        }
    }
}
