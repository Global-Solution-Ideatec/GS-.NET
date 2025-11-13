namespace IdeaTecAPI.DTOs
{
    public class EmpresaDTO
    {
        public int IdEmpresa { get; set; }
        public string NmEmpresa { get; set; } = string.Empty;
        public string DsCnpj { get; set; } = string.Empty;
        public string DsPoliticaHibrida { get; set; } = string.Empty;
        public DateTime DtCadastro { get; set; }
    }
}
