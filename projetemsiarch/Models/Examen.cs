namespace projetemsiarch.Models
{
    public class Examen
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public int SemestreId { get; set; }
        public Semestre Semestre { get; set; } = null!;
    }
}
