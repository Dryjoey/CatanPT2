using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Port
    {
        public Port(int id, string conversion, int placement)
        {
            this.id = id;
            this.Conversion = conversion;
            this.Placement = placement;

        }

        public int id { get; private set; }
        public string Conversion { get; private set; }
        public int Placement { get; private set; }
    }
}
