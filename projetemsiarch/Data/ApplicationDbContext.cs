using Microsoft.EntityFrameworkCore;
using projetemsiarch.Models;

namespace projetemsiarch.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Etudiant> Etudiants { get; set; } = null!;
        public DbSet<Admin> Admin { get; set; } = null!;
        public DbSet<Filiere> Filieres { get; set; } = null!;
        public DbSet<Semestre> Semestres { get; set; } = null!;
        public DbSet<Module> Modules { get; set; } = null!;
        public DbSet<Archive> Archives { get; set; } = null!;
        public DbSet<Examen> Examens { get; set; } = null!;
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relation Filiere -> Semestre
            modelBuilder.Entity<Filiere>()
                .HasMany(f => f.Semestres)
                .WithOne(s => s.Filiere)
                .HasForeignKey(s => s.FiliereId);

            // Relation Semestre -> Module
            modelBuilder.Entity<Semestre>()
                .HasMany(s => s.Modules)
                .WithOne(m => m.Semestre)
                .HasForeignKey(m => m.SemestreId);


            modelBuilder.Entity<Module>()
            .HasMany(m => m.Archives)
            .WithOne(a => a.Module)
            .HasForeignKey(a => a.ModuleId);

            // Exemple de données fictives
            modelBuilder.Entity<Etudiant>().HasData(
                new Etudiant
                {
                    Id = 1,
                    Nom = "Dupont",
                    Prenom = "Pierre",
                    Email = "pierre.dupont@example.com",
                    Password = "Password123"
                },
                new Etudiant
                {
                    Id = 2,
                    Nom = "Martin",
                    Prenom = "Sophie",
                    Email = "sophie.martin@example.com",
                    Password = "Password456"
                }
            );
        }
    }
}
