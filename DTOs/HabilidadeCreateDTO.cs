namespace IdeaTecAPI.DTOs
{
    public class HabilidadeCreateDTO
    {
        public string NmHabilidade { get; set; } = string.Empty;
        public int DsNivel { get; set; }
        public int IdUsuario { get; set; }
    }
}
