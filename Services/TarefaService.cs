using IdeaTecAPI.Data;
using IdeaTecAPI.Models;

namespace IdeaTecAPI.Services
{
    public class TarefaService
    {
        private readonly IdeaTecContext _ctx;
        public TarefaService(IdeaTecContext ctx) { _ctx = ctx; }
    }
}