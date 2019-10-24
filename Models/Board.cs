using System;
using System.Collections.Generic;

namespace Models
{
    public class Board
    {
        public Board(int id, int userid )
        {
            this.Id = id;
            this.UserId = userid;
        }
        public Board()
        {

        }
       
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public List<Tile> Tile { get; set; }
        public List<Port> Port { get; set; }
    }
}
