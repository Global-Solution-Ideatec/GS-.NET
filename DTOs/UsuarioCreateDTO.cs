namespace IdeaTecAPI.DTOs
{
    public class UsuarioCreateDTO
    {
        public string NmUsuario { get; set; } = string.Empty;
        public string DsEmail { get; set; } = string.Empty;
        public string DsSenha { get; set; } = string.Empty;
        public char TpUsuario { get; set; }
        public int IdEmpresa { get; set; }
    }
}
