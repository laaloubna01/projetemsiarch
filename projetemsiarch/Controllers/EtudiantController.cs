using Microsoft.AspNetCore.Mvc;
using projetemsiarch.Data;
using projetemsiarch.Models;
using System.Linq;

namespace projetemsiarch.Controllers
{
    public class EtudiantController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EtudiantController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Afficher la liste des étudiants
        [HttpGet]
        public IActionResult Index()
        {
            var etudiants = _context.Etudiants.ToList();
            return View(etudiants);
        }

        // Ajouter un étudiant (afficher formulaire)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Ajouter un étudiant (POST)
        [HttpPost]
        public IActionResult Create(Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                _context.Etudiants.Add(etudiant);
                _context.SaveChanges();
                TempData["Success"] = "Étudiant ajouté avec succès !";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Erreur lors de l'ajout de l'étudiant.";
            return View(etudiant);
        }

        // Modifier un étudiant (afficher formulaire)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var etudiant = _context.Etudiants.Find(id);
            if (etudiant == null)
            {
                return NotFound();
            }
            return View(etudiant);
        }

        // Modifier un étudiant (POST)
        [HttpPost]
        public IActionResult Edit(int id, Etudiant etudiant)
        {
            if (id != etudiant.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Etudiants.Update(etudiant);
                    _context.SaveChanges();
                    TempData["Success"] = "Étudiant modifié avec succès !";
                    return RedirectToAction("Index");
                }
                catch
                {
                    TempData["Error"] = "Erreur lors de la mise à jour.";
                }
            }
            return View(etudiant);
        }

        // Supprimer un étudiant (GET pour confirmation)
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var etudiant = _context.Etudiants.Find(id);
            if (etudiant == null)
            {
                return NotFound();
            }
            return View(etudiant);
        }

        // Supprimer un étudiant (POST)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var etudiant = _context.Etudiants.Find(id);
            if (etudiant != null)
            {
                _context.Etudiants.Remove(etudiant);
                _context.SaveChanges();
                TempData["Success"] = "Étudiant supprimé avec succès !";
            }
            else
            {
                TempData["Error"] = "Erreur lors de la suppression.";
            }
            return RedirectToAction("Index");
        }
    }
}
