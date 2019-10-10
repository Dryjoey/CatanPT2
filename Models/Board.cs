using System;

namespace Models
{
    public class Board
    {
        public Board(int id, Tile tile, Port port)
        {
            this.Tile = tile;
            this.Port = port;
        }

        
       
        public Tile Tile { get; private set; }
        public Port Port { get; private set; }

        

    }
}
