namespace ServiciiPubliceBackend.Models
{
    public class Bon
    {
        public int Id { get; set; }
        public int IdGhiseu { get; set; }
        public string Stare { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int UserId { get; set; }
    }
}
