using System;
using System.Collections.Generic;

namespace Models
{
    public class Board
    {
        public Board(List<Tile> tiles, List<Port> ports)
        {
            Tiles = tiles;
            Ports = ports;
        }

        public Board()
        {

        }
        
        public List<Tile> Tiles { get; set; }
        public List<Port> Ports { get; set; }


    }
}
