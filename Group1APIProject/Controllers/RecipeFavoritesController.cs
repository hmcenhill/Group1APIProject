using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Group1APIProject.Models;

namespace Group1APIProject.Controllers
{
    public class RecipeFavoritesController : Controller
    {
        private readonly DataContext _context;

        public RecipeFavoritesController(DataContext context)
        {
            _context = context;
        }

        // GET: RecipeFavorites
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.RecipeFavorites.Include(r => r.Result).Include(r => r.UserData);
            return View(await dataContext.ToListAsync());
        }

        // GET: RecipeFavorites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeFavorite = await _context.RecipeFavorites
                .Include(r => r.Result)
                .Include(r => r.UserData)
                .FirstOrDefaultAsync(m => m.RecipeFavoriteId == id);
            if (recipeFavorite == null)
            {
                return NotFound();
            }

            return View(recipeFavorite);
        }

        // GET: RecipeFavorites/Create
        public IActionResult Create()
        {
            ViewData["ResultId"] = new SelectList(_context.Recipes, "ResultId", "ResultId");
            ViewData["UserDataId"] = new SelectList(_context.Users, "UserDataID", "UserDataID");
            return View();
        }

        // POST: RecipeFavorites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeFavoriteId,UserDataId,ResultId")] RecipeFavorite recipeFavorite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipeFavorite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResultId"] = new SelectList(_context.Recipes, "ResultId", "ResultId", recipeFavorite.ResultId);
            ViewData["UserDataId"] = new SelectList(_context.Users, "UserDataID", "UserDataID", recipeFavorite.UserDataId);
            return View(recipeFavorite);
        }

        // GET: RecipeFavorites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeFavorite = await _context.RecipeFavorites.FindAsync(id);
            if (recipeFavorite == null)
            {
                return NotFound();
            }
            ViewData["ResultId"] = new SelectList(_context.Recipes, "ResultId", "ResultId", recipeFavorite.ResultId);
            ViewData["UserDataId"] = new SelectList(_context.Users, "UserDataID", "UserDataID", recipeFavorite.UserDataId);
            return View(recipeFavorite);
        }

        // POST: RecipeFavorites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeFavoriteId,UserDataId,ResultId")] RecipeFavorite recipeFavorite)
        {
            if (id != recipeFavorite.RecipeFavoriteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipeFavorite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeFavoriteExists(recipeFavorite.RecipeFavoriteId))
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
            ViewData["ResultId"] = new SelectList(_context.Recipes, "ResultId", "ResultId", recipeFavorite.ResultId);
            ViewData["UserDataId"] = new SelectList(_context.Users, "UserDataID", "UserDataID", recipeFavorite.UserDataId);
            return View(recipeFavorite);
        }

        // GET: RecipeFavorites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeFavorite = await _context.RecipeFavorites
                .Include(r => r.Result)
                .Include(r => r.UserData)
                .FirstOrDefaultAsync(m => m.RecipeFavoriteId == id);
            if (recipeFavorite == null)
            {
                return NotFound();
            }

            return View(recipeFavorite);
        }

        // POST: RecipeFavorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipeFavorite = await _context.RecipeFavorites.FindAsync(id);
            _context.RecipeFavorites.Remove(recipeFavorite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeFavoriteExists(int id)
        {
            return _context.RecipeFavorites.Any(e => e.RecipeFavoriteId == id);
        }
    }
}
