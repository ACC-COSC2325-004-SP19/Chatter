using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chatter.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Topic { get; set; }

        public List<Blog> BlogId { get; set; }
    }
}
