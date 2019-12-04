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
        public IActionResult Index()
        {
            List<Board> ListOfBoards = new List<Board>();
            return View(new DummyCollectionViewModel(ListOfBoards));
        }
    }
}