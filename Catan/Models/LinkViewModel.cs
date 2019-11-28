using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catan.Models
{
    public class LinkViewModel
    {
        public string PreviousURL { get; set; }

        public LinkViewModel(string previousURL)
        {
            PreviousURL = previousURL;
        }
    }
}
