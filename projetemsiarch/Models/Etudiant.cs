using System.ComponentModel.DataAnnotations;

namespace projetemsiarch.Models
{
    public class Etudiant
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nom { get; set; }

        [Required]
        [StringLength(100)]
        public string Prenom { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; } // Ajout du champ Password

        
    }
}
