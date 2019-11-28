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
            ThreeStepJumps = new ThreeStepJumpCollector();
        }

        public Board()
        {
            ThreeStepJumps = new ThreeStepJumpCollector();
        }

        public ThreeStepJumpCollector ThreeStepJumps { get; set; }

        public int BoardId { get; set; }
        public int UserId { get; set; }
        public List<Tile> Tiles { get; set; }
        public List<Port> Ports { get; set; }
    }
}
