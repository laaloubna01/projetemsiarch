using Microsoft.AspNetCore.Mvc;
using projetemsiarch.Data;
using projetemsiarch.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace projetemsiarch.Controllers
{
    public class ArchivesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ArchivesController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Afficher la liste des archives
        public IActionResult Index()
        {
            var archives = _db.Archives.ToList();
            return View(archives);
        }

        // Créer une archive (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Créer une archive (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Archive archive)
        {
            if (ModelState.IsValid)
            {
                archive.ModuleId = archive.ModuleId == 0 ? (int)ViewBag.ModuleId : archive.ModuleId;
                // Ajouter l'archive à la base de données
                _db.Archives.Add(archive);
                _db.SaveChanges();
                return RedirectToAction("Index"); // Rediriger vers la liste des archives
            }

            // Si le modèle n'est pas valide, retourner à la vue de création
            return View(archive);
        }
        // Modifier une archive (GET)
        public IActionResult Edit(int id)
        {
            var archive = _db.Archives.FirstOrDefault(a => a.ArchiveId == id);
            if (archive == null)
            {
                return NotFound(); // Si l'archive n'existe pas, retourner une erreur
            }
            return View(archive); // Retourner la vue avec l'archive à modifier
        }

        // Modifier une archive (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Archive archive)
        {
            if (id != archive.ArchiveId)
            {
                return BadRequest(); // Si l'ID de l'archive ne correspond pas, retourner une erreur
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Mise à jour de l'archive dans la base de données
                    _db.Entry(archive).State = EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Index"); // Rediriger vers la liste des archives après modification
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_db.Archives.Any(a => a.ArchiveId == id))
                    {
                        return NotFound(); // Si l'archive n'existe plus, retourner une erreur
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            // Si le modèle est invalide, retourner à la vue d'édition avec les erreurs de validation
            return View(archive);
        }

        // Supprimer une archive (GET)
        public IActionResult Delete(int id)
        {
            var archive = _db.Archives.Find(id);
            if (archive == null) return NotFound();
            return View(archive);
        }

        // Supprimer une archive (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var archive = _db.Archives.Find(id);
            if (archive == null) return NotFound();
            _db.Archives.Remove(archive);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
