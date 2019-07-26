using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Chatter.Models;

namespace Chatter.Models
{
    public class ChatterContext : DbContext
    {
        public ChatterContext (DbContextOptions<ChatterContext> options)
            : base(options)
        {
        }

        public DbSet<Chatter.Models.User> User { get; set; }

        public DbSet<Chatter.Models.Blog> Blog { get; set; }

        public DbSet<Chatter.Models.Board> Board { get; set; }
    }
}
