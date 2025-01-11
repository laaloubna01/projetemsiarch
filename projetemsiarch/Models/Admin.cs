using System.ComponentModel.DataAnnotations;

namespace projetemsiarch.Models
{
    public class Admin
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

}
