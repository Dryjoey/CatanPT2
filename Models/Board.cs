using System;

namespace Models
{
    public class Board
    {
        public Board(int id, int userid )
        {
            this.Id = id;
            this.UserId = userid;
        }
       
        public int Id { get; private set; }
        public int UserId { get; private set; }

    }
}
