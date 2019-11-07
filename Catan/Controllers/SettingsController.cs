using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http;
using Catan.Models;
using Logic;

namespace Catan.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SetSettings(Settingsmodel model)
        {
            if (ModelState.IsValid)
            {
                if(model.ChipIsRandom && model.TileIsRandom == true)
                {
                    return RedirectToAction("Random","Board");
                }
                if (model.TileIsRandom == true)
                {
                    return RedirectToAction("RandomResources", "Board");
                }
                if (model.ChipIsRandom == true)
                {
                    return RedirectToAction("RandomChips", "Board");
                }
                else
                {
                    return RedirectToAction("BoardDisplay", "Board");
                }
            }
            else
            {

            }
            return View();
        }
    }
}