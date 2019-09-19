using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Port
    {
        public Port(int id)
        {
            this.id = id;
        }

        public int id { get; private set; }
    }
}
