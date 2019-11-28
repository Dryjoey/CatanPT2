using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public static class BigBoardLogic
    {
        public static int[] Chips = new int[] { 3, 5, 6, 8, 2, 11, 10, 10, 5, 12, 4, 9, 8, 3, 6, 4, 9, 11, 3, 5, 6, 8, 2, 11, 10, 10, 5, 12, 4, 9 };
        public static int[] Tiles = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29 };
        public static string[] Ports = new string[] { "two-one brick", "two-one wool", "two-one wood", "two-one wheat", "two-one ore",  "three-one any", "three-one any", "three-one any", "three-one any", "three-one any", "three-one any" };
        public static string[] Resources = new string[] { "lumber", "sheep", "lumber", "wheat", "lumber", "brick", "sheep", "brick", "lumber", "ore", "wheat", "sheep", "brick", "wheat", "ore", "wheat", "sheep", "ore", "lumber", "sheep", "lumber", "wheat", "lumber", "brick", "sheep", "brick", "lumber", "ore", "wheat", "sheep" };
        public static int[][] adjecent = new int[][]
        {
            new int[]{1, 4, 5},
            new int[]{0, 2, 5, 6},
            new int[]{1, 3, 6, 7},
            new int[]{2, 7, 8},
            new int[]{0, 5, 9, 10},
            new int[]{0, 1, 4, 6, 10, 11},
            new int[]{1, 2, 5, 7, 11, 12},
            new int[]{2, 3, 6, 8, 12, 13},
            new int[]{3, 7, 13, 14},
            new int[]{4, 10, 15},
            new int[]{4, 5, 9, 11, 15, 16},
            new int[]{5, 6, 10, 12, 16, 17},
            new int[]{6, 7, 11, 13, 17, 18},
            new int[]{7, 8, 12, 14, 18, 19},
            new int[]{8, 13, 19, 20},
            new int[]{9, 10, 16, 21},
            new int[]{10, 11, 15, 17, 21, 22},
            new int[]{11, 12, 16, 18, 22, 23},
            new int[]{12, 13, 17, 19, 23, 24},
            new int[]{13, 14, 18, 20, 24, 25},
            new int[]{14, 19, 25},
            new int[]{15, 16, 22, 26},
            new int[]{16, 17, 21, 23, 26, 27},
            new int[]{17, 18, 22, 24, 27, 28},
            new int[]{18, 19, 23, 25, 28, 29},
            new int[]{19, 20, 24, 29},
            new int[]{21, 22, 27},
            new int[]{22, 23, 26, 28},
            new int[]{23, 24, 27, 29},
            new int[]{24, 25, 28}
        };
        private static Random rng = new Random();
        public static Board Normal()
        {
            Board board = new Board();
            List<Tile> tiles = CreateNewEmptyTileList();
            List<Port> ports = CreateNewEmptyPortList();
            board.Tiles = FillTiles(tiles);
            board.Ports = FillPorts(ports);
            AddDesert(board);
            return board;
        }
        public static Board PseudoRandom()
        {
            Board board = new Board();

            bool check = false;
            while (check == false)
            {
                List<Tile> tiles = CreateNewEmptyTileList();
                List<Port> ports = CreateNewEmptyPortList();
                FillRandomPorts(ports);
                RandomizeTiles(tiles);
                board.Tiles = tiles;
                AddRandomDesert(board);
                check = CheckRedTiles(board.Tiles);
            }
            return board;
        }
        public static Board Random()
        {
            Board board = new Board();
            List<Tile> tiles = CreateNewEmptyTileList();
            board.Tiles = FillRandomTiles(tiles);
            AddRandomDesert(board);
            return board;

        }
        public static Board RandomChips()
        {
            Board board = new Board();
            List<Tile> tiles = CreateNewEmptyTileList();
            board.Tiles = FillRandomChipsTiles(tiles);
            AddDesert(board);
            return board;
        }

        public static Board RandomResources()
        {
            Board board = new Board();
            List<Tile> tiles = CreateNewEmptyTileList();
            board.Tiles = FillRandomResourceTiles(tiles);
            AddRandomDesert(board);
            return board;
        }
        public static void RandomizeTiles(List<Tile> tiles)
        {
            tiles = SetChips(tiles, shuffle(Chips));
            tiles = SetResources(tiles, shuffle(Resources));

        }
        public static List<Tile> CreateNewEmptyTileList()
        {
            List<Tile> tileList = new List<Tile>();
            foreach (int tile in Tiles)
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
        public static List<Tile> FillRandomTiles(List<Tile> tiles)
        {
            tiles = SetChips(tiles, shuffle(Chips));
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

        public static List<Tile> SetResources(List<Tile> tiles, string[] resources)
        {
            for (int i = 0; i < resources.Length; i++)
            {
                tiles[i].Resource = resources[i];
            }
            return tiles;
        }

        public static List<Tile> SetChipsPseudoRandom(List<Tile> tiles, int[] chips)
        {
            for (int i = 0; i < chips.Length; i++)
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

            Tile tile = new Tile(7, "desert");
            board.Tiles.Insert(rng.Next(37), tile);
        }

        public static void AddDesert(Board board)
        {
            Tile tile = new Tile(7, "desert");
            Tile tile1 = new Tile(7, "desert");
            board.Tiles.Insert(19, tile);
            board.Tiles.Insert(25, tile);
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
        public static List<Port> SetPorts(List<Port> ports, string[] Ports)
        {
            for (int i = 0; i < Ports.Length; i++)
            {
                ports[i].Conversion = Ports[i];
            }
            return ports;
        }
    }
}
