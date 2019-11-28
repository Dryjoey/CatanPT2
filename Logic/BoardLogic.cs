using DAO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Logic
{
    public static class BoardLogic
    {
        public static int[] Chips = new int[] { 3, 5, 6, 8, 2, 11, 10, 10, 5, 12, 4, 9, 8, 3, 6, 4, 9, 11 };

        public static int NumberOfTiles = 18;
        public static int NumberOfThreeStepJumps = 20;

        public static string[] Resources = new string[] { "lumber", "sheep", "lumber", "wheat", "lumber", "brick", "sheep", "brick", "lumber", "ore", "wheat", "sheep", "brick", "wheat", "ore", "wheat", "sheep", "ore" };
        
        public static string[] Ports = new string[] { "two-one brick", "two-one wool", "two-one wood", "two-one wheat", "two-one ore", "three-one any", "three-one any", "three-one any", "three-one any" };
        public static int[][] adjecent = new int[][]
        {
        new int[]{ 1, 3, 4},
        new int[]{ 0, 2, 4, 5},
        new int[]{ 1, 5, 6},
        new int[]{ 0, 4, 7, 8},
        new int[]{ 0, 1, 3, 5, 8, 9},
        new int[]{ 1, 2, 4, 6, 9, 10},
        new int[]{ 2, 5, 10, 11},
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

        public static int[][] TSJAdjecent = new int[][]
        {
            new int[]{0},
            new int[]{0},
            new int[]{0, 1},
            new int[]{1},
            new int[]{1, 2},
            new int[]{2},
            new int[]{2},
            new int[]{3},
            new int[]{0, 3},
            new int[]{0, 3, 4},
            new int[]{0, 1, 4},
            new int[]{1, 4, 5},
            new int[]{1, 2, 5},
            new int[]{2, 5, 6},
            new int[]{2, 6},
            new int[]{6},
            new int[]{7},
            new int[]{3, 7},
            new int[]{3, 7, 8},
            new int[]{3, 4, 8},
            new int[]{4, 8, 9},
            new int[]{4, 5, 9},
            new int[]{5, 9, 10},
            new int[]{5, 6, 10},
            new int[]{6, 10, 11},
            new int[]{6, 11},
            new int[]{11},
            new int[]{7},
            new int[]{7, 12},
            new int[]{7, 8, 12},
            new int[]{8, 12, 13},
            new int[]{8, 9, 13},
            new int[]{9, 13, 14},
            new int[]{9, 10, 14},
            new int[]{10, 14, 15},
            new int[]{10, 11, 15},
            new int[]{11, 15},
            new int[]{11},
            new int[]{12},
            new int[]{12, 16},
            new int[]{12, 13, 16},
            new int[]{13, 16, 17},
            new int[]{13, 14, 17},
            new int[]{14, 17, 18},
            new int[]{14, 15, 18},
            new int[]{15, 18},
            new int[]{15},
            new int[]{16},
            new int[]{16},
            new int[]{16, 17},
            new int[]{17},
            new int[]{17, 18},
            new int[]{18},
            new int[]{18}
        };

        public static int chip = 1;
        
        private static HashSet<int> exclude = new HashSet<int>();
        private static Random rng = new Random();

        public static Board Normal()
        {
            Board board = new Board();
            List<Tile> tiles = CreateNewEmptyTileList();
            List<Port> ports = CreateNewEmptyPortList();
            board.Ports = FillPorts(ports);
            board.Tiles = FillTiles(tiles);
            AddDesert(board);
            SetStars(board.Tiles);
            FillThreeStepJumpValues(board);
            return board;
        }

        public static Board PseudoRandom()
        {
            Board board = new Board();

            bool check = false;
            while(check == false)
            {
                List<Tile> tiles = CreateNewEmptyTileList();
                List<Port> ports = CreateNewEmptyPortList();
                board.Ports = FillRandomPorts(ports);
                board.Tiles = tiles;
                RandomizeTiles(tiles);
                AddRandomDesert(board);
                check = CheckRedTiles(board.Tiles);
            }
            SetStars(board.Tiles);
            FillThreeStepJumpValues(board);
            return board;
        }

        public static void FillThreeStepJumpValues(Board board)
        {
            for(int x = 0; x < TSJAdjecent.Length; x++)
            {
                int ThreeStepJumpValue = 0;
                for (int y = 0; y < TSJAdjecent[x].Length; y++)
                {
                    ThreeStepJumpValue += board.Tiles[TSJAdjecent[x][y]].Stars;
                }
                board.ThreeStepJumpValues.Add(ThreeStepJumpValue);
            }
        }

        public static Board RandomTiles()
        {
            Board board = new Board();
            List<Tile> tiles = CreateNewEmptyTileList();
            List<Port> ports = CreateNewEmptyPortList();
            board.Ports = FillRandomPorts(ports);
            board.Tiles = FillRandomTiles(tiles);
            AddRandomDesert(board);
            return board;

        }
        public static Board RandomChips()
        {
            Board board = new Board();
            List<Tile> tiles = CreateNewEmptyTileList();
            List<Port> ports = CreateNewEmptyPortList();
            board.Tiles = FillRandomChipsTiles(tiles);
            board.Ports = FillPorts(ports);
            AddDesert(board);
            return board;
        }

        public static Board RandomResources()
        {
            Board board = new Board();
            List<Tile> tiles = CreateNewEmptyTileList();
            List<Port> ports = CreateNewEmptyPortList();
            board.Tiles = FillRandomResourceTiles(tiles);
            board.Ports = FillRandomPorts(ports);
            AddRandomDesert(board);
            return board;
        }
        
        public static List<Tile> CreateNewEmptyTileList()
        {
            List<Tile> tileList = new List<Tile>();
            for (int i = 0; i < NumberOfTiles; i++)
            {
                tileList.Add(new Tile());
            }
            return tileList;
        }
        public static List<Port> CreateNewEmptyPortList()
        {
            List<Port> PortList = new List<Port>();
            foreach (string port in Ports)
            {
                PortList.Add(new Port());
            }
            return PortList;
        }
        public static List<Tile> FillPseudoRandomTiles(List<Tile> tiles)
        {
            
            RandomizeTiles(tiles);
            
            //bool check = CheckRedTiles(tiles);
            //while (check == false)
            //{
            //    RandomizeTiles(tiles);
                
            //    check = CheckRedTiles(tiles);
                
            //}
            return tiles;
            
        }

        public static void RandomizeTiles(List<Tile> tiles)
        {            
            tiles = SetChips(tiles, shuffle(Chips));
            tiles = SetResources(tiles, shuffle(Resources));
            
        }

        public static List<Port> FillRandomPorts(List<Port> port)
        {
            port = SetPorts(port, shuffle(Ports));
            return port;
        }

        public static List<Port> FillPorts(List<Port> port)
        {
            port = SetPorts(port, Ports);
            return port;
        }

        public static List<Tile> FillRandomTiles(List<Tile> tiles)
        {
            tiles = SetChips(tiles, shuffle (Chips));
            tiles = SetResources(tiles, shuffle(Resources));
            return tiles;
        }

        public static List<Tile> FillRandomResourceTiles(List<Tile> tiles)
        {
            tiles = SetChips(tiles, (Chips));
            tiles = SetResources(tiles, shuffle(Resources));
            return tiles;
        }

        public static List<Tile> FillRandomChipsTiles(List<Tile> tiles)
        {
            tiles = SetChips(tiles, shuffle(Chips));
            tiles = SetResources(tiles, (Resources));
            return tiles;
        }

        public static List<Tile> FillTiles(List<Tile> tiles)
        {
            tiles = SetChips(tiles, Chips);
            tiles = SetResources(tiles, Resources);
            return tiles;
        }

        public static string[] shuffle(string[] array)
        {
            return array.OrderBy(x => rng.Next()).ToArray();
        }

        public static int[] shuffle(int[] array)
        {
            return array.OrderBy(x => rng.Next()).ToArray();
        }

        public static bool CheckRedTiles(List<Tile> tiles)
        {
            for (int x = 0; x < tiles.Count; x++)
            {
                if ((tiles[x].Chip == 6 || tiles[x].Chip == 8) && CompareRedWithAdjecents(tiles, x) == false)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool CompareRedWithAdjecents(List<Tile> tiles, int index)
        {
            foreach (int p in adjecent[index])
            {
                if (tiles[p].Chip == 6 || tiles[p].Chip == 8)
                {
                    return false;
                }
            }
            return true;
        }

        public static List<Tile> Position(List<Tile> tiles)
        {
            foreach (Tile tile in tiles)
            {
                if (tile.Chip == 8 || tile.Chip == 6)
                {
                    PositionRed(tile);
                }
                else
                {
                    PositionRest(tile);
                }
            }
            return tiles;
        }

        private static void PositionRed(Tile tile)
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
            }
        }

        private static void RemoveAdjacent(List<int> placeable, int position)
        {
            foreach (int x in adjecent[position])
            {
                if (!placeable.Contains(x)) placeable.Remove(x);
             
                if (!exclude.Contains(x)) exclude.Add(x);
            }
        }

        private static void PositionRest(Tile tile)
        {
            tile.Position = GetNewPositionValue();
        }

        private static int GetNewPositionValue()
        {
            var range = Enumerable.Range(0, 18).Where(i => !exclude.Contains(i));
            int index = rng.Next(0, 18 - exclude.Count);
            int finalValue = range.ElementAt(index);
            exclude.Add(finalValue);    
            return finalValue;
        }
         
        public static List<Tile> SetResources(List<Tile> tiles, string[] resources)
        {
            for (int i = 0; i < resources.Length; i++)
            {
                tiles[i].Resource = resources[i];
            }
            return tiles;
        }

        public static List<Port> SetPorts(List<Port> ports, string[] Ports)
        {
            for (int i = 0; i < Ports.Length; i++)
            {
                ports[i].Conversion = Ports[i];
            }
            return ports;
        }



        public static List<Tile> SetChipsPseudoRandom(List<Tile> tiles, int[] chips)
        {
            for(int i = 0; i< chips.Length; i++)
            {
                tiles[i].Chip = chips[i];
            }
            return tiles.ToList();
        }

        public static List<Tile> SetChips(List<Tile> tiles, int[] chips)
        {
            for (int i = 0; i < chips.Length; i++)
            {
                tiles[i].Chip = chips[i];
            }
            return tiles.ToList();
        }

        public static void AddRandomDesert(Board board)
        {
            
            Tile tile = new Tile(7,"desert");
            board.Tiles.Insert(rng.Next(18),tile);
        }
        public static void AddRandomDesert(List<Tile> tiles)
        {

            Tile tile = new Tile(7, "desert");
            tiles.Insert(rng.Next(18), tile);
        }

        public static void AddDesert(Board board)
        {
            Tile tile = new Tile(7, "desert");
            board.Tiles.Insert(9, tile);
        }

        public static void SetStars(List<Tile> tiles)
        {
            foreach (Tile tile in tiles)
            {
                switch (tile.Chip)
                {

                    case 2:
                        tile.Stars = 1;
                        break;
                    case 3:
                        tile.Stars = 2;
                        break;
                    case 4:
                        tile.Stars = 3;
                        break;
                    case 5:
                        tile.Stars = 4;
                        break;
                    case 6:
                        tile.Stars = 6;
                        break;
                    case 8:
                        tile.Stars = 6;
                        break;
                    case 9:
                        tile.Stars = 4;
                        break;
                    case 10:
                        tile.Stars = 3;
                        break;
                    case 11:
                        tile.Stars = 2;
                        break;
                    case 12:
                        tile.Stars = 1;
                        break;

                }
            }
        }
    }
}
