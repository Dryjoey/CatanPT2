using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;

namespace Catan.Models
{
    public class DummyCollectionViewModel
    {
        public int UserID { get; set; }
        public List<Board> Boards { get; set; }

        IOLogic logic = new IOLogic();

        public DummyCollectionViewModel(List<Board> boards)
        {
            UserID = 4;
            boards = logic.GetBoardsFromUser(4).ToList();
            Boards = boards;
        }
    }
}
