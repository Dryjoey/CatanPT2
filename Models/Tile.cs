using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Tile
    {
        public int id { get; private set; }
        public string tilecategorie; 
        public int chip;
        public string placement;
        /*
         * Subject to change towards actuall DataValues
         * Please check and manifest working type DataValues further.
         * DAT BETEKENT: Tile voldoet nog niet aan alle data eisen die wij hebben uitgezet. moet veranderd worden.
        */ 
        public string Resource { get; set; }
        public int Position { get; set; }

    }
}
