namespace ServiciiPubliceBackend.Models
{
    public class Bon
    {
        public int Id { get; set; }
        public int IdGhiseu { get; set; }
        public string Stare { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
