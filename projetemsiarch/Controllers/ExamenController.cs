using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetemsiarch.Data;
using projetemsiarch.Models;

namespace projetemsiarch.Controllers
{
    public class ExamenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExamenController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int semestreId)
        {
            var semestre = await _context.Semestres
                .Include(s => s.Examens)
                .FirstOrDefaultAsync(s => s.Id == semestreId);

            if (semestre == null)
                return NotFound();

            return View(semestre.Examens);
        }

        public IActionResult Create(int semestreId)
        {
            ViewData["SemestreId"] = semestreId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Examen examen)
        {
            if (ModelState.IsValid)
            {
                _context.Examens.Add(examen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { semestreId = examen.SemestreId });
            }
            return View(examen);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var examen = await _context.Examens.FindAsync(id);
            if (examen == null)
                return NotFound();

            return View(examen);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Examen examen)
        {
            if (id != examen.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Examens.Any(e => e.Id == examen.Id))
                        return NotFound();
                }
                return RedirectToAction(nameof(Index), new { semestreId = examen.SemestreId });
            }
            return View(examen);
        }
    }
}
