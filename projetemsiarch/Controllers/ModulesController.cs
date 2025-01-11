using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetemsiarch.Data;
using projetemsiarch.Models;

namespace projetemsiarch.Controllers
{
    public class ModulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var modules = await _context.Modules.ToListAsync();
            return View(modules);
        }


        public IActionResult Details(int id)
        {
            var module = _context.Modules
                .Include(m => m.Archives)
                .FirstOrDefault(m => m.Id == id);

            if (module == null)
            {
                TempData["Error"] = "Module introuvable.";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Archives", new { moduleId = id, moduleName = module.Nom });
        }
    }
}