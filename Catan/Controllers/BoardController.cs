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
        public IActionResult BoardDisplay(Board board)
        {
            Board board = BoardLogic.Normal();
            return View(board);
        }
    }
}