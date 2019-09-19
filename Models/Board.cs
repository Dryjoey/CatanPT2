using System;

namespace Models
{
    public class Board
    {
        public Board(int id, Tile tile, Port port)
        {
            this.Id = id;
            this.Tile = tile;
            this.Port = port;
        }

        public Board(int id, int portid, int tileid)
        {
            Id = id;
            Portid = portid;
            Tileid = tileid;
        }

        public int Id { get; private set; }
        public Tile Tile { get; private set; }
        public Port Port { get; private set; }
        public int Portid { get; private set; }
        public int Tileid { get; private set; }
    }
}
