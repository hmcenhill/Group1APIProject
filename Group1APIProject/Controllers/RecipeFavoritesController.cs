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
            var dataContext = _context.RecipeFavorites.Include(r => r.Result).Include(r => r.UserData).Where(x => x.UserData.UserName == User.Identity.Name);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFavorite(string title, string ing, string pic, string link)
        {
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = await _context.Users.FirstOrDefaultAsync(m => m.UserName == User.Identity.Name);
                if (currentUser == null)
                {
                    var userData = new UserData(User.Identity.Name);
                    _context.Add(userData);
                    await _context.SaveChangesAsync();
                    currentUser = userData;
                }

                var recipe = new Result
                {
                    Title = title,
                    Ingredients = ing,
                    Href = link,
                    Thumbnail = pic
                };
                _context.Add(recipe);
                await _context.SaveChangesAsync();

                recipe = await _context.Result.FirstOrDefaultAsync(m => m.Href == link);

                var favorite = new RecipeFavorite();
                favorite.UserDataId = currentUser.UserDataID;
                favorite.ResultId = recipe.ResultId;
                _context.Add(favorite);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        // GET: RecipeFavorites/Create
        public IActionResult Create()
        {
            ViewData["ResultId"] = new SelectList(_context.Result, "ResultId", "ResultId");
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
            ViewData["ResultId"] = new SelectList(_context.Result, "ResultId", "ResultId", recipeFavorite.ResultId);
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
            ViewData["ResultId"] = new SelectList(_context.Result, "ResultId", "ResultId", recipeFavorite.ResultId);
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
            ViewData["ResultId"] = new SelectList(_context.Result, "ResultId", "ResultId", recipeFavorite.ResultId);
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
