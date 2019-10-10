using DAO;
using Models;
using System;

namespace Logic
{
    public class BoardLogic
    {
        public int[] AllChips = new int[19] { 3, 5, 6,
                                             8, 2, 11, 10,
                                          7, 10, 5, 2, 4,
                                             9, 8, 6,  };


        public string[] Tilecategorie = new string[19]
       {
            "lumber",
            "sheep",
            "lumber",
            "wheat",
            "lumber",
            "brick",
            "sheep",
            "desert",
            "brick",
            "lumber",
            "ore",
            "wheat",
            "sheep",
            "brick",
            "wheat",
            "ore",
            "wheat",
            "sheep",
            "ore",
       };
    }
}
