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

        //Saves recent generated Board with UserID | Save board
        public void SaveBoard(Board board, int UserId) => boardDao.InsertBoard(board, UserId);
 
        //Get List of boards via UserId | Returns List: Boards
        public IEnumerable<Board> GetBoardsFromUser(int UserId) => boardDao.GetAllBoardsFromUser(UserId);
        
        //Deletes board via BoardID
        public void DeleteBoard(int BoardId) => boardDao.DeleteBoard(BoardId);
        
        //Gets specific board via BoardID | Returns Board;
        public Board GetBoard(int BoardId) => boardDao.GetBoard(BoardId);


        //Checks what last User in DB  | Creates new User/Returns UserID
        public int GetLastUser() => userDao.GetLastUser();
    }
}
