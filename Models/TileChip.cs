using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class TileChip :IChip 
    {
        public TileChip(string value)
        {
            this.value = value;
        }

        public string value { get; private set; }
    }
}
