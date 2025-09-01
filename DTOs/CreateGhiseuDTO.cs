namespace ServiciiPubliceBackend.DTOs
{
    public class CreateGhiseuDTO
    {
        public string Cod { get; set; } = string.Empty;
        public string Denumire { get; set; } = string.Empty;
        public string Descriere { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public bool Activ { get; set; }
    }
}
