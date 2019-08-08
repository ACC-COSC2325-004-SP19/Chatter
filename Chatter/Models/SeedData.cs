using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chatter.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ChatterContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ChatterContext>>()))
            {
                if (context.Blog.Any())
                {
                    return;   // DB has been seeded
                }

                context.Blog.AddRange(
                    new Blog
                    {
                        Title = "First Test Blog",
                        Content = "This is my first test blog from my seed data.",
                        //Board = new Board(),
                        


                    },

                    new Blog
                    {
                        Title = "Second Test Blog",
                        Content = "This is my second test blog from my seed data.",
                        //Board = new Board(),
                      

                    }
                ); ;
                context.SaveChanges();
            }
        }
    }
}
          