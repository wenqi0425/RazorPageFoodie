﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPageFoodie.Models;
using System.IO;
using System.Web;

namespace RazorPageFoodie.Controllers
{
    public class RecipesController : Controller
    {
        private readonly FoodieContext _context;

        [BindProperty]
        public Recipe RecipeData { get; set; }
        public RecipeItem RecipeItemData { get; set; }
        public Wrapper WrapperData { get; set; }

        public RecipesController(FoodieContext context)
        {
            _context = context;
        }

        // GET: Recipes
        public async Task<IActionResult> Index(string recipeName)
        {
            if (recipeName == null)
            {
                var recipe = await _context.Recipes.FindAsync(recipeName);
            }

            return View(await _context.Recipes.ToListAsync());
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Wrapper wrapper)
        {
            wrapper.Recipe = new Recipe();
            wrapper.RecipeItem = new RecipeItem();
            byte[] bytes = null;

            if (WrapperData.Recipe.ImageFile != null)
            {
                using (Stream s = WrapperData.Recipe.ImageFile.OpenReadStream())
                {
                    using (BinaryReader r = new BinaryReader(s))
                    {
                        bytes = r.ReadBytes((Int32)s.Length);
                    }
                }

                WrapperData.Recipe.ImageData = Convert.ToBase64String(bytes, 0, bytes.Length);
            }

            _context.Recipes.Add(WrapperData.Recipe);
            _context.RecipeItems.Add(WrapperData.RecipeItem);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CookingSteps,Introduction,ImageData")] Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    byte[] bytes = null;

                    if (RecipeData.ImageFile != null)
                    {
                        using (Stream s = RecipeData.ImageFile.OpenReadStream())
                        {
                            using (BinaryReader r = new BinaryReader(s))
                            {
                                bytes = r.ReadBytes((Int32)s.Length);
                            }
                        }

                        RecipeData.ImageData = Convert.ToBase64String(bytes, 0, bytes.Length);
                    }

                    _context.Update(RecipeData);
                    _context.SaveChanges();
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.Id == id);
        }
    }
}
