namespace IdeaTecAPI.DTOs
{
    public class LogAtividadeCreateDTO
    {
        public int IdUsuario { get; set; }
        public string DsAcao { get; set; } = string.Empty;
        public string Origem { get; set; } = string.Empty;
    }
}
