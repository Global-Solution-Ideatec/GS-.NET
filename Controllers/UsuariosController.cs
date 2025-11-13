using IdeaTecAPI.Data;
using IdeaTecAPI.Models;
using IdeaTecAPI.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdeaTecAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IdeaTecContext _context;
        private readonly IMapper _mapper;

        public UsuariosController(IdeaTecContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetAll()
        {
            var users = await _context.TB_USUARIO.ToListAsync();
            return _mapper.Map<List<UsuarioDTO>>(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> Get(int id)
        {
            var usuario = await _context.TB_USUARIO.FindAsync(id);
            if (usuario == null) return NotFound();
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDTO>> Create(UsuarioCreateDTO dto)
        {
            var u = _mapper.Map<Usuario>(dto);
            u.DtCadastro = DateTime.Now;
            _context.TB_USUARIO.Add(u);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<UsuarioDTO>(u);
            return CreatedAtAction(nameof(Get), new { id = u.IdUsuario }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UsuarioDTO dto)
        {
            if (id != dto.IdUsuario) return BadRequest();
            var existing = await _context.TB_USUARIO.FindAsync(id);
            if (existing == null) return NotFound();
            _mapper.Map(dto, existing);
            _context.Entry(existing).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var u = await _context.TB_USUARIO.FindAsync(id);
            if (u == null) return NotFound();
            _context.TB_USUARIO.Remove(u);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
