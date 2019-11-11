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
            Board board = BoardLogic.PseudoChips();
            return View(board);
        }

        public IActionResult BigBoardTest()
        {
            Board board = BigBoardLogic.Normal(); //there needs to be a function for bigBoard!
            return View(board);
        }

        //these are going to change. 
        public IActionResult RandomChips()
        {
            Board board = BoardLogic.RandomChips();
            return View("BoardDisplay",board);
        }

        public IActionResult RandomResources()
        {
            Board board = BoardLogic.RandomTiles();
            return View("BoardDisplay",board);
        }
        public IActionResult Random()
        {
            Board board = BoardLogic.Random();
            return View("BoardDisplay", board);
        }
    }
}