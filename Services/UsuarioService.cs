using IdeaTecAPI.Data;
using IdeaTecAPI.Models;

namespace IdeaTecAPI.Services
{
    public class UsuarioService
    {
        private readonly IdeaTecContext _ctx;
        public UsuarioService(IdeaTecContext ctx) { _ctx = ctx; }
    }
}