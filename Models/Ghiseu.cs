namespace ServiciiPubliceBackend.Models
{
    public class Ghiseu
    {
        public int Id { get; set; }
        public string Cod { get; set; } = string.Empty;
        public string Denumire { get; set; } = string.Empty;
        public string Descriere { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public bool Activ {  get; set; } = true;
    }
}
