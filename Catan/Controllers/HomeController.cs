using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Catan.Models;
using DAO;

namespace Catan.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            BoardDAO boardDAO = new BoardDAO();
           
            return View(boardDAO.GetBoard(1));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
