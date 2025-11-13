namespace IdeaTecAPI.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NmUsuario { get; set; } = string.Empty;
        public string DsEmail { get; set; } = string.Empty;
        public string DsSenha { get; set; } = string.Empty;
        public char TpUsuario { get; set; } // 'C' colaborador, 'G' gestor
        public char StAtivo { get; set; }
        public DateTime DtCadastro { get; set; }
        public int IdEmpresa { get; set; }
    }
}
