namespace IdeaTecAPI.DTOs
{
    public class RecomendacaoDTO
    {
        public int IdRecomendacao { get; set; }
        public int IdUsuario { get; set; }
        public string DsRecomendacao { get; set; } = string.Empty;
        public string TpRecomendacao { get; set; } = string.Empty;
        public DateTime DtRecomendacao { get; set; }
    }
}
