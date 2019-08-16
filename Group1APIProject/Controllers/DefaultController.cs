using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Group1APIProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Group1APIProject.Controllers
{
    public class DefaultController : Controller
    {
        private readonly DataContext _context;

        public DefaultController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userData = new UserData(User.Identity.Name);
                _context.Add(userData);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}