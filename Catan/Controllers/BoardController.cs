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
                if (model.IsSmallBoard == true)
                {
                    if (model.ChipState == ChipState.Fixed && model.TileIsRandom == true)
                    {
                        board = BoardLogic.RandomResources();
                        return View(board);
                    }
                    if (model.ChipState == ChipState.Fixed && model.TileIsRandom == false)
                    {
                        board = BoardLogic.Normal();
                        return View(board);
                    }
                    if (model.ChipState == ChipState.Random && model.TileIsRandom == true)
                    {
                        board = BoardLogic.PseudoRandom();
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
                }
                else
                {
                    if (model.ChipState == ChipState.Fixed && model.TileIsRandom == true)
                    {
                        board = BigBoardLogic.RandomResources();
                        return View(board);
                    }
                    if (model.ChipState == ChipState.Fixed && model.TileIsRandom == false)
                    {
                        board = BigBoardLogic.Normal();
                        return View(board);
                    }
                    if (model.ChipState == ChipState.Random && model.TileIsRandom == true)
                    {
                        board = BigBoardLogic.PseudoRandom();
                        return View(board);
                    }
                    if (model.ChipState == ChipState.Random && model.TileIsRandom == false)
                    {
                        board = BigBoardLogic.RandomChips();
                        return View(board);
                    }
                    if (model.ChipState == ChipState.Psuedo && model.TileIsRandom == true)
                    {
                        board = BigBoardLogic.PseudoRandom();
                        return View(board);
                    }
                }
            }
            return View();
        }
    }
}