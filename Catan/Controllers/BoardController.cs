using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logic;
using Models;

namespace Catan.Controllers
{
    public class BoardController : Controller
    {

        public IActionResult Index()
        {
            return View("Views/Board/BoardTest.cshtml");
        }

        public IActionResult BigBoard()
        {
            Board bigBoard = new Board();
            bigBoard.Tiles = new List<Tile>() {
                new Tile(9, "ore", 0),
                new Tile(9, "ore", 1),
                new Tile(9, "brick", 2),
                new Tile(9, "wheat", 3),
                new Tile(8, "desert", 4),
                new Tile(9, "sheep", 5),
                new Tile(5, "ore", 6),
                new Tile(2, "sheep", 7),
                new Tile(8, "ore", 8),
                new Tile(2, "sheep", 9),
                new Tile(9, "ore", 10),
                new Tile(9, "sheep", 11),
                new Tile(6, "ore", 12),
                new Tile(5, "sheep", 13),
                new Tile(8, "ore", 14),
                new Tile(2, "sheep", 15),
                new Tile(2, "ore", 16),
                new Tile(2, "sheep", 17),
                new Tile(2, "ore", 18),
                new Tile(9, "sheep", 19),
                new Tile(5, "ore", 20),
                new Tile(2, "sheep", 21),
                new Tile(8, "ore", 22),
                new Tile(2, "sheep", 23),
                new Tile(9, "ore", 24),
                new Tile(9, "sheep", 25),
                new Tile(6, "ore", 26),
                new Tile(5, "sheep", 27),
                new Tile(8, "ore", 28),
                new Tile(2, "sheep", 29)
            };
            return View("Views/Board/BigBoardTest.cshtml", bigBoard);
        }

        public IActionResult SmallBoard()
        {
            Board board = new Board();
            board.Tiles = new List<Tile>() {
                new Tile(9, "lumber", 0),
                new Tile(9, "ore", 1),
                new Tile(9, "brick", 2),
                new Tile(9, "wheat", 3),
                new Tile(8, "desert", 4),
                new Tile(9, "sheep", 5),
                new Tile(5, "ore", 6),
                new Tile(2, "sheep", 7),
                new Tile(8, "ore", 8),
                new Tile(2, "sheep", 9),
                new Tile(9, "ore", 10),
                new Tile(9, "sheep", 11),
                new Tile(6, "ore", 12),
                new Tile(5, "sheep", 13),
                new Tile(8, "ore", 14),
                new Tile(2, "sheep", 15),
                new Tile(2, "ore", 16),
                new Tile(2, "sheep", 17),
                new Tile(2, "ore", 18)
            };
            return View("Views/Board/BoardTest.cshtml", board);
        }
    }
}