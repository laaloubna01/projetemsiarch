using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projetemsiarch.Models
{
    public class Archive
    {
        [Key]
        public int ArchiveId { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Type { get; set; } // PDF, Image, etc.

        public string Url { get; set; } // Chemin du fichier PDF ou lien

        [Required]
        public int ModuleId { get; set; }

        [ForeignKey("ModuleId")]
        public Module Module { get; set; }
    }
}
