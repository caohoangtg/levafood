using Manage.IServices;
using Manage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manage.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: CategoryController
        public async Task<ActionResult> Index()
        {
            var categories = await _categoryService.GetCategories();

            return View(categories);
        }

        // GET: CategoryController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var category = await _categoryService.GetCategory(id);
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CategoryViewModel model, IFormCollection collection)
        {
            try
            {
                await _categoryService.CreateCategory(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var category = await _categoryService.GetCategory(id);
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, CategoryViewModel model, IFormCollection collection)
        {
            try
            {
                await _categoryService.UpdateCategory(id, model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var category = await _categoryService.GetCategory(id);
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, CategoryViewModel model, IFormCollection collection)
        {
            try
            {
                await _categoryService.DeleteCategory(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
