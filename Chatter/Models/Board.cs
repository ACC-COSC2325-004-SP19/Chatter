using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chatter.Models
{
    public class Board
    {
        public int Id { get; set; }
        [Display(Name = "Board")]
        public string Topic { get; set; }

        public List<Blog> Blogs { get; set; }
    }
}
