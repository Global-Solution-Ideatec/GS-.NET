namespace IdeaTecAPI.Models
{
    public class RecomendacaoIA
    {
        public int IdRecomendacao { get; set; }
        public int IdUsuario { get; set; }
        public string DsRecomendacao { get; set; } = string.Empty;
        public DateTime DtRecomendacao { get; set; }
        public string TpRecomendacao { get; set; } = string.Empty;
    }
}
