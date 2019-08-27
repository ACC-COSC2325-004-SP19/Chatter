using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Chatter.Models;
using Microsoft.EntityFrameworkCore;

namespace Chatter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ChatterContext _context;

        public HomeController(ChatterContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var blogs = await _context.Blog.ToListAsync();
            foreach (var blog in blogs)
            {
                blog.Board = await _context.Board.FindAsync(blog.BoardId);

            }
            return View(blogs);

            
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
