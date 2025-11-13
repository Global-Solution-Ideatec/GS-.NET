namespace IdeaTecAPI.DTOs
{
    public class TarefaCreateDTO
    {
        public string DsTarefa { get; set; } = string.Empty;
        public string DsArea { get; set; } = string.Empty;
        public int IdGestor { get; set; }
        public int? IdColaborador { get; set; }
        public string StTarefa { get; set; } = string.Empty;
    }
}
