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
        public static Board board;
        [HttpGet]
        public IActionResult BoardDisplay(Settingsmodel model)
        {

            if (ModelState.IsValid)
            {
                if (model.FullyPseudoRandom && model.IsSmallBoard) // 3-4 (Pseudo)Random
                {
                    board = BoardLogic.PseudoRandom();
                }
                else if (!model.FullyPseudoRandom && model.IsSmallBoard) // 3-4 Fixed
                {
                    board = BoardLogic.Normal();
                }
                else if (model.FullyPseudoRandom && !model.IsSmallBoard) // 5-6 (Pseudo)Random
                {
                    board = BigBoardLogic.PseudoRandom();
                }
                else if (!model.FullyPseudoRandom && !model.IsSmallBoard) // 5-6 Fixed
                {
                    board = BigBoardLogic.Normal();
                }
                else
                {
                    board = BoardLogic.Normal(); // fake it till you make it
                }
            }
            else
            {
                board = BoardLogic.Normal();
            }

            return View(board);
        }

        public IActionResult SaveBoardToLibrary()
        {
            int UserID = 0;
            IOLogic iologic = new IOLogic();
            iologic.SaveBoard(board, UserID);
            return Redirect("BoardController/BoardDisplay");
        }
    }
}