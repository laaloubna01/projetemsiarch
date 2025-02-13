﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projetemsiarch.Data;

#nullable disable

namespace projetemsiarch.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250107155527_CRUD2")]
    partial class CRUD2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("projetemsiarch.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("projetemsiarch.Models.Archive", b =>
                {
                    b.Property<int>("ArchiveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArchiveId"));

                    b.Property<int>("ModuleId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArchiveId");

                    b.HasIndex("ModuleId");

                    b.ToTable("Archives");
                });

            modelBuilder.Entity("projetemsiarch.Models.Etudiant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Etudiants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "pierre.dupont@example.com",
                            Nom = "Dupont",
                            Password = "Password123",
                            Prenom = "Pierre"
                        },
                        new
                        {
                            Id = 2,
                            Email = "sophie.martin@example.com",
                            Nom = "Martin",
                            Password = "Password456",
                            Prenom = "Sophie"
                        });
                });

            modelBuilder.Entity("projetemsiarch.Models.Examen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SemestreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SemestreId");

                    b.ToTable("Examens");
                });

            modelBuilder.Entity("projetemsiarch.Models.Filiere", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Filieres");
                });

            modelBuilder.Entity("projetemsiarch.Models.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SemestreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SemestreId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("projetemsiarch.Models.Semestre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FiliereId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FiliereId");

                    b.ToTable("Semestres");
                });

            modelBuilder.Entity("projetemsiarch.Models.Archive", b =>
                {
                    b.HasOne("projetemsiarch.Models.Module", "Module")
                        .WithMany("Archives")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");
                });

            modelBuilder.Entity("projetemsiarch.Models.Examen", b =>
                {
                    b.HasOne("projetemsiarch.Models.Semestre", "Semestre")
                        .WithMany("Examens")
                        .HasForeignKey("SemestreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Semestre");
                });

            modelBuilder.Entity("projetemsiarch.Models.Module", b =>
                {
                    b.HasOne("projetemsiarch.Models.Semestre", "Semestre")
                        .WithMany("Modules")
                        .HasForeignKey("SemestreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Semestre");
                });

            modelBuilder.Entity("projetemsiarch.Models.Semestre", b =>
                {
                    b.HasOne("projetemsiarch.Models.Filiere", "Filiere")
                        .WithMany("Semestres")
                        .HasForeignKey("FiliereId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filiere");
                });

            modelBuilder.Entity("projetemsiarch.Models.Filiere", b =>
                {
                    b.Navigation("Semestres");
                });

            modelBuilder.Entity("projetemsiarch.Models.Module", b =>
                {
                    b.Navigation("Archives");
                });

            modelBuilder.Entity("projetemsiarch.Models.Semestre", b =>
                {
                    b.Navigation("Examens");

                    b.Navigation("Modules");
                });
#pragma warning restore 612, 618
        }
    }
}
