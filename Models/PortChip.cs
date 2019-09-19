using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class PortChip :IChip
    {
        public PortChip(string value)
        {
            this.value = value;
        }

        public string value { get; private set; }
    }
}
