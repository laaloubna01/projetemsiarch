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
            options.MultipartBodyLengthLimit = 209715200; // Limite � 200MB
        });



        // Configuration de DbContext avec la cha�ne de connexion
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


        // Configuration de la m�moire cache et de la session
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30); // Dur�e de la session
            options.Cookie.HttpOnly = true; // S�curit� des cookies
            options.Cookie.IsEssential = true; // N�cessaire pour l'authentification
        });

        // Configuration de CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAnyOrigin", policy =>
            {
                policy.AllowAnyOrigin()    // Permet toutes les origines
                      .AllowAnyMethod()    // Permet toutes les m�thodes (GET, POST, etc.)
                      .AllowAnyHeader();   // Permet tous les en-t�tes
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

        // Activation de la session (doit �tre avant UseAuthorization)
        app.UseSession();

        app.UseAuthorization();

        // D�finition des routes par d�faut
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Admin}/{action=Login}/{id?}");

     

       




        app.Run();
    }
}
