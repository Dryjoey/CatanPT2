using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using DAO;

namespace Catan.Models
{
    public class DummyCollectionViewModel
    {
        public int UserID { get; set; }
        public List<Board> IDOnlyBoards { get; set; }

        public List<Tile> BoardTiles = new List<Tile>();

        public List<Board> FullBoard = new List<Board>();

        IOLogic logic = new IOLogic();

        public DummyCollectionViewModel(List<Board> boards)
        {
            UserID = 0;
            boards = logic.GetBoardsFromUser(UserID).ToList();
            IDOnlyBoards = boards;
            foreach(Board board in IDOnlyBoards)
            {
                FullBoard.Add(logic.GetBoard(board.BoardId));
            }
        }
    }
}
