using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public static class BoardManagerLogic
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static void SetTiles<T>(IList<T> resources, IList<T> Chips)
        {
            List<Tile> newTiles = new List<Tile>();
            for(int x = 0; x <= resources.Count; x++)
            {
                TileChip tc = new TileChip();
                tc.chip = tc.AllChips[x];
                newTiles.Add(new Tile(x, tc));
            }
        }
    }
}
