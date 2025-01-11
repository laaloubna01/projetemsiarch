namespace projetemsiarch.Models
{
    public class Filiere
    {
        public int Id { get; set; } 
        public string Nom { get; set; }
        public string Description { get; set; }
       
        public string? ImageUrl { get; set; }
        public ICollection<Semestre> Semestres { get; set; }
       
          
            
            
        }

    }

