namespace IdeaTecAPI.Models
{
    public class CheckinBemEstar
    {
        public int IdCheckin { get; set; }
        public int IdUsuario { get; set; }
        public int VlHumor { get; set; }
        public int VlEnergia { get; set; }
        public int VlEstresse { get; set; }
        public DateTime DtCheckin { get; set; }
        public string DsObservacao { get; set; } = string.Empty;
    }
}
