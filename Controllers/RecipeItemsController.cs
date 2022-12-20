using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPageFoodie.Models;

namespace RazorPageFoodie.Controllers
{
    public class RecipeItemsController : Controller
    {
        private readonly FoodieContext _context;

        public RecipeItemsController(FoodieContext context)
        {
            _context = context;
        }

        // GET: RecipeItems
        public async Task<IActionResult> Index()
        {
            var foodieContext = _context.RecipeItems.Include(r => r.Recipe);
            return View(await foodieContext.ToListAsync());
        }

        // GET: RecipeItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeItem = await _context.RecipeItems
                .Include(r => r.Recipe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipeItem == null)
            {
                return NotFound();
            }

            return View(recipeItem);
        }

        // GET: RecipeItems/Create
        public IActionResult Create()
        {
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "CookingSteps");
            return View();
        }

        // POST: RecipeItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Amount,RecipeId")] RecipeItem recipeItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipeItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "CookingSteps", recipeItem.RecipeId);
            return View(recipeItem);
        }

        // GET: RecipeItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeItem = await _context.RecipeItems.FindAsync(id);
            if (recipeItem == null)
            {
                return NotFound();
            }
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "CookingSteps", recipeItem.RecipeId);
            return View(recipeItem);
        }

        // POST: RecipeItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Amount,RecipeId")] RecipeItem recipeItem)
        {
            if (id != recipeItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipeItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeItemExists(recipeItem.Id))
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
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "CookingSteps", recipeItem.RecipeId);
            return View(recipeItem);
        }

        // GET: RecipeItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeItem = await _context.RecipeItems
                .Include(r => r.Recipe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipeItem == null)
            {
                return NotFound();
            }

            return View(recipeItem);
        }

        // POST: RecipeItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipeItem = await _context.RecipeItems.FindAsync(id);
            _context.RecipeItems.Remove(recipeItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeItemExists(int id)
        {
            return _context.RecipeItems.Any(e => e.Id == id);
        }
    }
}
