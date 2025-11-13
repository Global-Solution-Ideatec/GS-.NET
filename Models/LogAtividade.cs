namespace IdeaTecAPI.Models
{
    public class LogAtividade
    {
        public int IdLog { get; set; }
        public int IdUsuario { get; set; }
        public string DsAcao { get; set; } = string.Empty;
        public DateTime DtAcao { get; set; }
        public string Origem { get; set; } = string.Empty;
    }
}
