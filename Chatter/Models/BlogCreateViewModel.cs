using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chatter.Models
{
    public class BlogCreateViewModel
    {
        public Blog blog { get; set; }

        public List<Board> Boards { get; set; }

    }
}
