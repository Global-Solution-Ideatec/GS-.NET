namespace IdeaTecAPI.Models
{
    public class Habilidade
    {
        public int IdHabilidade { get; set; }
        public string NmHabilidade { get; set; } = string.Empty;
        public int DsNivel { get; set; } // nível 1 a 5
        public int IdUsuario { get; set; }
    }
}
