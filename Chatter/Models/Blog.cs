using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chatter.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public int? BoardId { get; set; }
        public Board Board { get; set; }
                
    }
}
