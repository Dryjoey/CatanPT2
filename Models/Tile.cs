using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Tile
    {
        public Tile(int id, Categorie categorie, TileChip tilechip)
        {
            this.id = id;
            this.categorie = categorie;
            this.tilechip = tilechip;
        }

        public int id { get; private set; }
        public Categorie categorie { get; private set; }
        public TileChip tilechip { get; private set; }
    }
}
