using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catan.Models
{
    public class UserViewModel
    {
        public IEnumerable<Board> boards { get; set; }
        public int UserId { get; set; }
    }
}
