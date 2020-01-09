using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logic;
using Models;
using Hanssens.Net;
using Catan.Models;

namespace Catan.Controllers
{
    public class LibraryController : Controller
    {
        private readonly IOLogic _ioLogic = new IOLogic();
        public IActionResult Index(int userId)
        {
            List<Board> ListOfBoards = _ioLogic.GetBoardsFromUser(userId).ToList();
            return View(new DummyCollectionViewModel(ListOfBoards));
        }
        public RedirectToActionResult LoadBoard(int boardId)
        {
            Board loadedBoard = _ioLogic.GetBoard(boardId);
            return RedirectToAction("BoardDisplay", "Board", new { loadedBoard });
        }
        public RedirectToActionResult SaveBoard(Board board, int userId)
        {
            _ioLogic.SaveBoard(board, userId);
            return RedirectToAction("Index", "Library");
        }
    }
}