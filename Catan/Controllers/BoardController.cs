using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logic;
using Models;

namespace Catan.Controllers
{
    public class BoardController : Controller
    {

        public IActionResult BoardDisplay()
        {
            Board board = BoardLogic.Normal();
            return View(board);
        }

        public IActionResult BigBoardTest()
        {
            Board board = BoardLogic.Normal(); //there needs to be a function for bigBoard!
            return View(board);
        }

        public IActionResult BoardTest()
        {
            Board board = BoardLogic.Normal();
            return View(board);
        }
    }
}