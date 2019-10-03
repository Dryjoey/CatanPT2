using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Tile
    {
        public Tile(int id, TileChip tilechip)
        {
            this.id = id;
            this.tilechip = tilechip;
        }

        public int id { get; private set; }
        public TileChip tilechip { get; private set; }

        public string [] Tilecategorie = new string[19] 
        {
            "desert",
            "brick",
            "brick",
            "brick",
            "lumber",
            "lumber",
            "lumber",
            "lumber",
            "ore",
            "ore",
            "ore",
            "sheep",
            "sheep",
            "sheep",
            "sheep",
            "wheat",
            "wheat",
            "wheat",
            "wheat"
        };
    }
}
