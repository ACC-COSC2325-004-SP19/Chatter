using Microsoft.AspNetCore.Identity;
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
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using (var context = new ChatterContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ChatterContext>>()))
            {
                string UserId = null;
                var userManager = serviceProvider.GetService<UserManager<User>>();
                var userEmail = "admin@test.com";
                var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

                if (!context.Roles.Any())
                {
                    var roleResult = await roleManager
                        .CreateAsync(new IdentityRole() { Name = Constants.Roles.Admin });
                    roleResult = await roleManager
                        .CreateAsync(new IdentityRole() { Name = Constants.Roles.User });
                }

                if (!context.Users.Any())
                {
                    var user = new User()
                    {
                        FirstName = "Admin",
                        LastName = "Super",
                        Email = userEmail,
                        UserName = userEmail
                    };


                    var result = await userManager.CreateAsync(user, "password");
                    if (!result.Succeeded)
                    {
                        throw new Exception();
                    }
                    user = await userManager.FindByEmailAsync(userEmail);
                    var userId = await userManager.GetUserIdAsync(user);

                    await userManager.AddToRoleAsync(user, Constants.Roles.Admin);
                }

                if (UserId == null)
                {
                    var user = await userManager.FindByEmailAsync(userEmail);
                    UserId = await userManager.GetUserIdAsync(user);
                }
                



                if (context.Board.Any())
                {
                    return;   // DB has been seeded
                }

                context.Board.AddRange(
                    new Board
                    {
                        Topic = "Animals"
                    
                        //Board = new Board(),



                    }
                ); ;
                context.SaveChanges();
                var boardId = context.Board.First().Id;
                    if (context.Blog.Any())
                    {
                        return;   // DB has been seeded
                    }

                    context.Blog.AddRange(
                        new Blog
                        {
                            Title = "First Test Blog",
                            Content = "This is my first test blog from my seed data.",
                            BoardId = boardId




                        },

                        new Blog
                        {
                            Title = "Second Test Blog",
                            Content = "This is my second test blog from my seed data.",
                            BoardId = boardId

                            //Board = new Board(),


                        }
                        );
                    context.SaveChanges();

                }
            }
        }
    }

          