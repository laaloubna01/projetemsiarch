namespace projetemsiarch.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;

        public int SemestreId { get; set; }
        public Semestre Semestre { get; set; } = null!;

        public ICollection<Archive> Archives { get; set; } = new List<Archive>();
    }
}
