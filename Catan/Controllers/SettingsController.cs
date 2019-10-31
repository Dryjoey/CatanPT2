using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace Catan.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SaveBoardSettings(bool tileRandom, bool chipRandom, bool fourPlayer)
        {
            Response.Cookies.Append("TileRandom","True");
            Response.Cookies.Append("TileRandom","False");
            Response.Cookies.Append("ChipRandom","True");
            Response.Cookies.Append("ChipRandom","False");
            Response.Cookies.Append("FourPlayer","True");
            Response.Cookies.Append("FourPlayer", "False");
            try
            {
                if (fourPlayer == true)
                {
                    return RedirectToAction("BoardController", "Smallboard");
                }
                else
                {
                    return RedirectToAction("BoardController", "Bigboard");
                }
            }
            catch(ArgumentException)
            {
                return View();
            }
        }
    }
}