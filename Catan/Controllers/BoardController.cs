using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logic;
using Models;
using Catan.Models;
using Hanssens.Net;

namespace Catan.Controllers
{
    public class BoardController : Controller
    {
        [HttpPost]
        public IActionResult BoardDisplay(Settingsmodel model)
        {
            Board board;
            if (ModelState.IsValid)
            {
                if (model.ChipState == ChipState.Fixed && model.TileIsRandom == true)
                {
                    board = BoardLogic.RandomTiles();
                    return View(board);
                }
                if (model.ChipState == ChipState.Fixed && model.TileIsRandom == false)
                {
                    board = BoardLogic.Normal();
                    return View(board);
                }
                if (model.ChipState == ChipState.Random && model.TileIsRandom == true)
                {
                    board = BoardLogic.Random();
                    return View(board);
                }
                if (model.ChipState == ChipState.Random && model.TileIsRandom == false)
                {
                    board = BoardLogic.RandomChips();
                    return View(board);
                }
                if (model.ChipState == ChipState.Psuedo && model.TileIsRandom == true)
                {
                    board = BoardLogic.PseudoRandom();
                    return View(board);
                }
                if (model.ChipState == ChipState.Psuedo && model.TileIsRandom == false)
                {
                    board = BoardLogic.PseudoChips();
                    return View(board);
                }
            }
            else
            {

            }
            return View();
        }
    }
}