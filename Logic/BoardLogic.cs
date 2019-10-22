﻿using DAO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Logic
{
    public static class BoardLogic
    {
        public static int[] AllChips = new int[] { 3, 5, 6, 8, 2, 11, 10, 7, 10, 5, 12, 4, 9, 8, 3, 6, 4, 9, 11 };
        public static int[] Tiles = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };
        public static string[] Recource = new string[] { "lumber", "sheep", "lumber", "wheat", "lumber", "brick", "sheep", "desert", "brick", "lumber", "ore", "wheat", "sheep", "brick", "wheat", "ore", "wheat", "sheep", "ore" };
        public static int[][] adjecent = new int[][]
        {
        new int[] {1,3,4},
        new int[] {0,2,4,5},
        new int[]{1,5,6},
        new int[]{0,4,7,8},
        new int[]{0,1,3,5,8,9},
        new int[]{1,2,4,6,9,10},
        new int[]{2, 5, 10, 11},
        new int[]{ 3, 8, 12 },
        new int[]{ 3, 4, 7, 9, 12, 13 },
        new int[]{ 4, 5, 8, 10, 13, 14 },
        new int[]{ 5, 6, 9, 11, 14, 15 },
        new int[]{ 6, 10, 15 },
        new int[]{ 7, 8, 13, 16 },
        new int[]{ 8, 9, 12, 14, 16, 17 },
        new int[]{ 9, 10, 13, 15, 17, 18 },
        new int[]{ 10, 11, 14, 18 },
        new int[]{ 12, 13, 17 },
        new int[]{ 13, 14, 16, 18 },
        new int[]{ 14, 15, 17 }
        };

        public static Random rng = new Random();

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
        public static void Position(List<Tile> tiles)
        {
            foreach (Tile tile in tiles)
            {
                if (tile.chip == 8 || tile.chip == 6)
                {
                    PositionRed(tiles, tile);
                }
                else
                {
                    PositionRest(tiles, tile);
                }
            }
        }
        //Bleeding : Not tested
        private static void PositionRed(List<Tile> tiles, Tile tile)
        {
            List<int> emptyPositions = new List<int>()
            {
                1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18
            };
            List<int> placeable = new List<int>()
            {
                1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18
            };
            int[] redTiles = { 6, 6, 8, 8 };
            for (int i = 0; i <= redTiles.Length; i++)
            {
                int newPosition = GetNewPositionValue();
                tile.Position = newPosition;
                emptyPositions.Remove(newPosition);
                placeable.Remove(newPosition);
                RemoveAdjacent(placeable, newPosition);
                tiles.Remove(tile);
            }
        }
        //Bleeding : Not tested
        private static void RemoveAdjacent(List<int> placeable, int position)
        {
            foreach (int x in adjecent[position])
            {
                placeable.Remove(x);
            }
        }
        //Bleeding : Not tested
        private static void PositionRest(List<Tile> tiles, Tile tile)
        {
            tile.Position = GetNewPositionValue();
            tiles.Remove(tile);
        }
        //Bleeding

        /*************************************************************************/
        /* Generates new position filtering already used int values within range */
        /*************************************************************************/
        private static int GetNewPositionValue()
        {
            var exclude = new HashSet<int>();
            var range = Enumerable.Range(0, 18).Where(i => !exclude.Contains(i));

            var rand = new Random();
            int index = rand.Next(0, 18 - exclude.Count);
            int finalValue = range.ElementAt(index);
            exclude.Add(finalValue);
            return finalValue;
        }

    }
}
