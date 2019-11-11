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
        public IActionResult SetSettings(Settingsmodel model)
        {
            Board board;
            if (ModelState.IsValid)
            {
                if(model.ChipState == ChipState.Fixed && model.TileIsRandom == true)
                {
                    board = BoardLogic.RandomTiles();
                    return RedirectToAction("BoardDisplay", "Board");
                }
                if (model.ChipState == ChipState.Fixed && model.TileIsRandom == false)
                {
                    board = BoardLogic.Normal();
                    return RedirectToAction("BoardDisplay", "Board", board);
                }
                if(model.ChipState == ChipState.Random && model.TileIsRandom == true)
                {
                    board = BoardLogic.Random();
                    TempData["_board"] = board;
                    return RedirectToAction("BoardDisplay", "Board", board);
                }
                if(model.ChipState == ChipState.Random && model.TileIsRandom == false)
                {
                    board = BoardLogic.RandomChips();
                    return RedirectToAction("BoardDisplay", "Board", board);
                }
                if(model.ChipState == ChipState.Psuedo && model.TileIsRandom == true)
                {
                    board = BoardLogic.PseudoRandom();
                    return RedirectToAction("BoardDisplay", "Board", board);
                }
                if(model.ChipState == ChipState.Psuedo && model.TileIsRandom == false)
                {
                    board = BoardLogic.PseudoChips();
                    return RedirectToAction("BoardDisplay", "Board", board);
                }
            }
            else
            {

            }
            return View();
        }
    }
}