namespace IdeaTecAPI.DTOs
{
    public class RecomendacaoCreateDTO
    {
        public int IdUsuario { get; set; }
        public string DsRecomendacao { get; set; } = string.Empty;
        public string TpRecomendacao { get; set; } = string.Empty;
    }
}
