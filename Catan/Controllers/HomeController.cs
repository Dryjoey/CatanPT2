using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Catan.Models;
using Logic;
using Models;
using Hanssens.Net;

namespace Catan.Controllers
{
    public class HomeController : Controller
    {
        IOLogic iologic = new IOLogic();
        public IActionResult Index()
        {
            UserViewModel CatanUser = new UserViewModel();
            using (var storage = new LocalStorage())
            {
                var key = "UserIDKey";
                //CatanUser.UserId = iologic.GetLastUser();
                storage.Store(key, CatanUser.UserId);
                storage.Persist();

            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
