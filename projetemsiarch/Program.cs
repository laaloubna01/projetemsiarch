using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using projetemsiarch.Data;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();


        //
        builder.Services.Configure<FormOptions>(options =>
        {
            options.MultipartBodyLengthLimit = 209715200; // Limite à 200MB
        });



        // Configuration de DbContext avec la chaîne de connexion
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


        // Configuration de la mémoire cache et de la session
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30); // Durée de la session
            options.Cookie.HttpOnly = true; // Sécurité des cookies
            options.Cookie.IsEssential = true; // Nécessaire pour l'authentification
        });

        // Configuration de CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAnyOrigin", policy =>
            {
                policy.AllowAnyOrigin()    // Permet toutes les origines
                      .AllowAnyMethod()    // Permet toutes les méthodes (GET, POST, etc.)
                      .AllowAnyHeader();   // Permet tous les en-têtes
            });
        });

        var app = builder.Build();


        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts(); // Force l'utilisation de HTTPS
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        // Activation de CORS
        app.UseCors("AllowAnyOrigin");

        // Activation de la session (doit être avant UseAuthorization)
        app.UseSession();

        app.UseAuthorization();

        // Définition des routes par défaut
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Admin}/{action=Login}/{id?}");

     

       




        app.Run();
    }
}
