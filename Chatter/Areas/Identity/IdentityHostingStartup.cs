using System;
using Chatter.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Chatter.Areas.Identity.IdentityHostingStartup))]
namespace Chatter.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddIdentity<User, IdentityRole>(options =>
                {
                    //Default password settings
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 1;
                })
.AddRoleManager<RoleManager<IdentityRole>>()
.AddDefaultUI()
.AddDefaultTokenProviders()
.AddEntityFrameworkStores<ChatterContext>();

            });
        }
    }
}