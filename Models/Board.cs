using System;

namespace Models
{
    public class Board
    {
        public Board(int id, Tile tile, Port port)
        {
            this.id = id;
            this.tile = tile;
            this.port = port;
        }

        public int id { get; private set; }
        public Tile tile { get; private set; }
        public Port port { get; private set; }
    }
}
