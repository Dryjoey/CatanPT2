using DAO;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class IOLogic
    {

        private BoardDAO boardDao = new BoardDAO();
        private UserDAO userDao = new UserDAO();

        //Saves recent generated Board with UserID | Save board || Checked ||
        public void SaveBoard(Board board, int UserId) => boardDao.InsertBoard(board, UserId);
        //Get List of boards via UserId | Returns List: Boards || Checked ||
        public IEnumerable<Board> GetBoardsFromUser(int UserId) => boardDao.GetAllBoardsFromUser(UserId);
        //Deletes board via BoardID || Checked ||
        public void DeleteBoard(int BoardId) => boardDao.DeleteBoard(BoardId);
        //Gets specific board via BoardID | Returns Board || Checked ||
        public Board GetBoard(int BoardId) => boardDao.GetBoard(BoardId);
        //Checks what last User in DB  | Creates new User/Returns UserID || Checked ||
        public int GetLastUser() => userDao.GetLastUser();
    }
}
