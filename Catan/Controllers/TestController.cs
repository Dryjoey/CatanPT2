using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Catan.Models;
using Logic;
using Models;
using DAO;
using Hanssens.Net;

namespace Catan.Controllers
{
    public class TestController : Controller
    {
        private IOLogic io = new IOLogic();
        
        public IActionResult TestView()
        {
            int userid = 4;
            //int userid = io.GetLastUser();
            Board board = io.GetBoard(21);
            return View("Views/TestView.cshtml", BigBoardLogic.Normal());
        }
    }
}