using DAO;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    class IOLogic
    {

        private BoardDAO boardDao = new BoardDAO();
        private UserDAO userDao = new UserDAO();
        public void SaveBoard(Board board, int UserId) => boardDao.InsertBoard(board, UserId);
        public IEnumerable<Board> GetBoardsFromUser(int UserId) => boardDao.GetAllBoardsFromUser(UserId);
        public void DeleteBoard(int BoardId) => boardDao.DeleteBoard(BoardId);
        public Board GetBoard(int BoardId) => boardDao.GetBoard(BoardId);
        public int GetLastUser() => userDao.GetLastUser();
    }
}
