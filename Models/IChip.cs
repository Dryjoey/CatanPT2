using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public abstract class IChip
    {
        public IChip(int id)
        {
            this.id = id;
        }

        public int id { get; private set; }
    }
}
