using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Catan.Models;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Catan.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Board board = BoardLogic.Normal();
            return View(board);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
