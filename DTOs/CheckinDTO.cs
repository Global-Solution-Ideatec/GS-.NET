namespace IdeaTecAPI.DTOs
{
    public class CheckinDTO
    {
        public int IdCheckin { get; set; }
        public int IdUsuario { get; set; }
        public int VlHumor { get; set; }
        public int VlEnergia { get; set; }
        public int VlEstresse { get; set; }
        public string DsObservacao { get; set; } = string.Empty;
        public DateTime DtCheckin { get; set; }
    }
}
