using DAO;
using Models;
using System;

namespace Logic
{
    public class BoardLogic
    {
        BoardDAO boarddao = new BoardDAO();
        public void SendObject(Board board)
        {
            boarddao.AddEntity(board);
        }

    }
}
