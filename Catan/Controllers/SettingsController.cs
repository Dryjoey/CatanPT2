using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Session;
using Catan.Models;

namespace Catan.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveBoardSettings(Settingsmodel model)
        {
            Session["RandomChip"] = model.ChipIsRandom;
            Session["RandomTile"] = model.TileIsRandom;
            Session["IsFourPlayer"] = model.IsSmallBoard;

            if (ModelState.IsValid)
            {
                try
                {
                    if(model.IsSmallBoard == true)
                    {
                        return RedirectToAction("Board", "SmallBoard");
                    }
                }
                catch
                {
                    return View();
                }
            }
            return RedirectToAction("Board", "SmallBoard");
        }
    }
}