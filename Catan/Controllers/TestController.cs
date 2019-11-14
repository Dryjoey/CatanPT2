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
        public IActionResult TestView()
        {

            return View("Views/TestView.cshtml", BigBoardLogic.Normal());
        }
    }
}