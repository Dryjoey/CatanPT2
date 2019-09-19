using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public abstract class IChip
    {
        protected IChip(int id)
        {
            this.id = id;
        }

        public int id { get; private set; }
    }
}
