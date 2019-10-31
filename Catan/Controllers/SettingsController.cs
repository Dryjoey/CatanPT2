using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Catan.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SetBoardSettings(bool tileIsRandomized, bool chipIsRandomized, bool IsFourplayers)
        {
            bool fourPlayer = IsFourplayers;
            if(fourPlayer == true)
            {
                return View("BoardTest");
            }
            else
            {
                return View("BigBoardTest");
            }
        }
    }
}