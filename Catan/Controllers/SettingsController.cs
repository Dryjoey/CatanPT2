using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http;
using Catan.Models;

namespace Catan.Controllers
{
    public class SettingsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index(Settingsmodel model)
        {
            HttpContext.Session.Get("RandomTile");
            HttpContext.Session.Get("RandomChip");
            HttpContext.Session.Get("IsFourPlayer");
            if (ModelState.IsValid)
            {
                if (model.IsSmallBoard == true)
                {
                    return RedirectToAction("BoardDisplay", "Board");
                }
                else
                {
                    return RedirectToAction("BoardDisplay", "Board");
                }
            }
            return View();
        }
    }
}