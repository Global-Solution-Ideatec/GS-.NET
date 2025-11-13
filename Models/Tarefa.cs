namespace IdeaTecAPI.Models
{
    public class Tarefa
    {
        public int IdTarefa { get; set; }
        public string DsTarefa { get; set; } = string.Empty;
        public string DsArea { get; set; } = string.Empty;
        public DateTime DtCriacao { get; set; }
        public int IdGestor { get; set; }
        public int? IdColaborador { get; set; }
        public string StTarefa { get; set; } = string.Empty;
    }
}
