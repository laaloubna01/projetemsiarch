using Microsoft.AspNetCore.Mvc;
using projetemsiarch.Data;
using projetemsiarch.Models;
using Microsoft.EntityFrameworkCore;

namespace projetemsiarch.Controllers
{
    public class SemestresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SemestresController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Details(int id)
        {
            var semestre = await _context.Semestres
                .Include(s => s.Modules)
                .SingleOrDefaultAsync(s => s.Id == id);

            if (semestre == null)
            {
                return NotFound();
            }

            return View(semestre);
        }
    }

}
