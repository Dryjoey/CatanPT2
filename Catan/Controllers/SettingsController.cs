using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http;
using Catan.Models;
using Logic;
using Models;

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
                if(model.ChipState == ChipState.Fixed && model.TileIsRandom == true)
                {
                    Board board = BoardLogic.RandomTiles();
                    return RedirectToAction("BoardDisplay","Board");
                }
                if (model.ChipState == ChipState.Fixed && model.TileIsRandom == false)
                {
                    Board board = BoardLogic.Normal();
                    return RedirectToAction("BoardDisplay", "Board");
                }
                if(model.ChipState == ChipState.Random && model.TileIsRandom == true)
                {
                    Board board = BoardLogic.Random();
                    return RedirectToAction("BoardDisplay", "Board");
                }
                if(model.ChipState == ChipState.Random && model.TileIsRandom == false)
                {
                    Board board = BoardLogic.RandomChips();
                    return RedirectToAction("BoardDisplay", "Board");
                }
                if(model.ChipState == ChipState.Psuedo && model.TileIsRandom == true)
                {
                    Board board = BoardLogic.PseudoRandom();
                    return RedirectToAction("BoardDisplay", "Board");
                }
                if(model.ChipState == ChipState.Psuedo && model.TileIsRandom == false)
                {
                    Board board = BoardLogic.PseudoChips();
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