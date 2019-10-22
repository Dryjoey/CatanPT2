using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Catan.Controllers
{
    public class BoardController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Board/BoardTest.cshtml");
        }

        public IActionResult BigBoard()
        {
            return View("Views/Board/BigBoardTest.cshtml");
        }

        public IActionResult SmallBoard()
        {
            return View("Views/Board/BoardTest.cshtml");
        }
    }
}