using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetemsiarch.Data;
using projetemsiarch.Models;

public class FilieresController : Controller
{
    private readonly ApplicationDbContext _context;

    public FilieresController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Affichage de la liste des filières
    public async Task<IActionResult> Index()
    {
        var filieres = await _context.Filieres.ToListAsync();
        return View(filieres);
    }

    // Affichage des détails d'une filière, incluant la liste des semestres
    public async Task<IActionResult> Details(int id)
    {
        var filiere = await _context.Filieres
            .Include(f => f.Semestres)  // Inclure la liste des semestres
            .FirstOrDefaultAsync(f => f.Id == id);

        if (filiere == null)
        {
            return NotFound();
        }

        return View(filiere);
    }
}
