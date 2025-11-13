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
    public class TarefasController : ControllerBase
    {
        private readonly IdeaTecContext _context;
        private readonly IMapper _mapper;

        public TarefasController(IdeaTecContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarefaDTO>>> GetAll()
        {
            var list = await _context.TB_TAREFA.ToListAsync();
            return _mapper.Map<List<TarefaDTO>>(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaDTO>> Get(int id)
        {
            var tarefa = await _context.TB_TAREFA.FindAsync(id);
            if (tarefa == null) return NotFound();
            return _mapper.Map<TarefaDTO>(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<TarefaDTO>> Create(TarefaCreateDTO dto)
        {
            var t = _mapper.Map<Tarefa>(dto);
            t.DtCriacao = DateTime.Now;
            _context.TB_TAREFA.Add(t);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = t.IdTarefa }, _mapper.Map<TarefaDTO>(t));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TarefaDTO dto)
        {
            if (id != dto.IdTarefa) return BadRequest();
            var existing = await _context.TB_TAREFA.FindAsync(id);
            if (existing == null) return NotFound();
            _mapper.Map(dto, existing);
            _context.Entry(existing).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var t = await _context.TB_TAREFA.FindAsync(id);
            if (t == null) return NotFound();
            _context.TB_TAREFA.Remove(t);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
