using System.Collections.Generic;

namespace projetemsiarch.Models
{
    public class Semestre
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;

        public int FiliereId { get; set; }
        public Filiere Filiere { get; set; } = null!;

        public ICollection<Module> Modules { get; set; } = new List<Module>();
        public ICollection<Examen> Examens { get; set; } = new List<Examen>();
    }
}
