using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projetemsiarch.Data;
using projetemsiarch.Models;

namespace projetemsiarch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Vérifier si l'admin est connecté
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("AdminEmail")))
            {
                // Si l'admin n'est pas connecté, rediriger vers la page de login
                return RedirectToAction("Login", "Admin");
            }

            return View();
        }

        // Affichage des filières
        public IActionResult Filieres()
        {
            var filieres = _db.Filieres.ToList();
            return View(filieres);
        }

        // Page Privacy
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AdminHome()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("AdminEmail")))
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }


        // Gestion des erreurs
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
