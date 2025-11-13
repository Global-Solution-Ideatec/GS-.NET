namespace IdeaTecAPI.DTOs
{
    public class HabilidadeDTO
    {
        public int IdHabilidade { get; set; }
        public string NmHabilidade { get; set; } = string.Empty;
        public int DsNivel { get; set; }
        public int IdUsuario { get; set; }
    }
}
