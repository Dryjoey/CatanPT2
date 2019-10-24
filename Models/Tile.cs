using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Tile
    {
        public Tile(int placement, string tilecategorie, int chip)
        {
            this.Placement = placement;
            this.TileCategorie = tilecategorie;
            this.Chip = chip;
        }
        
        public Tile()
        {

        }

        public int Placement { get; set; }
        public string TileCategorie { get; set; } 
        public int Chip { get; set; }
     

    }
}
