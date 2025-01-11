using Microsoft.AspNetCore.Mvc;
using projetemsiarch.Data;
using projetemsiarch.Models;
using System.Linq; // Assurez-vous d'importer System.Linq

public class AdminController : Controller
{
    private readonly ApplicationDbContext _db;

    public AdminController(ApplicationDbContext db)
    {
        _db = db;
    }

    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        // Rechercher l'admin avec l'email donné
        var admin = _db.Admin.FirstOrDefault(a => a.Email == email);

        if (admin != null)
        {
            // Comparer les mots de passe en clair
            if (admin.Password == password)
            {
                // Stocker l'ID de l'admin dans la session
                HttpContext.Session.SetString("AdminId", admin.Id.ToString());
                HttpContext.Session.SetString("AdminEmail", admin.Email);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Message d'erreur si les mots de passe ne correspondent pas
                ViewBag.ErrorMessage = "Mot de passe incorrect.";
                return View();
            }
        }
        else
        {
            // Message d'erreur si l'admin avec cet email n'est pas trouvé
            ViewBag.ErrorMessage = "Email incorrect.";
            return View();
        }
    }
    public IActionResult Logout()
    {
        // Supprimer la variable de session de l'utilisateur
        HttpContext.Session.Remove("IsAuthenticated");

        // Rediriger vers la page de connexion
        return RedirectToAction("Login", "Admin");
    }

}
