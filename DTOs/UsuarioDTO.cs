namespace IdeaTecAPI.DTOs
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string NmUsuario { get; set; } = string.Empty;
        public string DsEmail { get; set; } = string.Empty;
        public char TpUsuario { get; set; } 
        public char StAtivo { get; set; }
        public int IdEmpresa { get; set; }
        public DateTime DtCadastro { get; set; }
    }
}
