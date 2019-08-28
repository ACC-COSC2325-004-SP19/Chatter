using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chatter.Models;
using Microsoft.AspNetCore.Identity;

namespace Chatter.Controllers
{
    public class UsersController : Controller
    {
        private readonly ChatterContext _context;
        private readonly UserManager<User> _userManager;

        public UsersController(ChatterContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Users
        public ActionResult Index()
        {
            var users = ConvertFromDatabase(_context.Users.ToArray());
            return View(users);
        }

        private IEnumerable<UserViewModel> ConvertFromDatabase(IEnumerable<User> users)
        {
            return users.Select(u => new UserViewModel()
            {
                EmailAddress = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Id = u.Id,
                Type = (UserType)u.TypeId, 
            }).ToList();
        }

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                throw new Exception();
            var newUser = ConvertFromDatabase(new[] { user }).First();
            return View(newUser);

        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel user)
        {
            try
            {
                var newUser = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.EmailAddress,
                    TypeId = (int)user.Type
                };

                var result = await _userManager.CreateAsync(newUser);
                if(!result.Succeeded)
                {
                    throw new Exception();
                }

                var newRole = string.Empty;
                switch(user.Type)
                {
                    case UserType.Administrator:
                        newRole = Constants.Roles.Admin;
                        break;
                    case UserType.User:
                        newRole = Constants.Roles.User;
                        break;
                }
                await _userManager.AddToRoleAsync(newUser, newRole);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,userName")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
