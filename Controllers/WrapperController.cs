using RazorPageFoodie.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System;
using System.Linq;

namespace RazorPageFoodie.Controllers
{
    public class WrapperController : Controller
    {
        private readonly FoodieContext _context;

        [BindProperty]
        public Wrapper WrapperData { get; set; }

        
        public WrapperController(FoodieContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var wrapper = new Wrapper();
            //var recipe = new Recipe();
            wrapper.Recipe = new Recipe();
            wrapper.RecipeItem = new RecipeItem();
            return View(wrapper);
        }

        public IActionResult Create()
        {
            return View();
        }

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

            wrapper.RecipeItem.RecipeId = wrapper.Recipe.Id;

            _context.Recipes.Add(WrapperData.Recipe);
            _context.RecipeItems.Add(WrapperData.RecipeItem);
            _context.SaveChanges();
            return View(wrapper);
        }

        

        /*
        public async Task<IActionResult> Details(int? recipeId)
        {
            var wrapper = new Wrapper();
            if (recipeId == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.Id == recipeId);
            if (recipe == null)
            {
                return NotFound();
            }

            var recipeItem = await _context.RecipeItems
                .FirstOrDefaultAsync(item => item.RecipeId == recipeId);

            return View(wrapper);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Wrapper/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,List<RecipeItem>,CookingSteps,Introduction,ImageData")] Recipe recipe)
        {
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
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        
        // GET: Wrapper/Edit/5
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

        
        // POST: Wrapper/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,List<RecipeItem>,CookingSteps,Introduction,ImageData")] Recipe recipe)
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

                    _context.Update(WrapperData.Recipe);
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
        }*/
    }
}
