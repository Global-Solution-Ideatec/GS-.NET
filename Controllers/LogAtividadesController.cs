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
    public class LogAtividadesController : ControllerBase
    {
        private readonly IdeaTecContext _context;
        private readonly IMapper _mapper;

        public LogAtividadesController(IdeaTecContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogAtividadeDTO>>> GetAll()
        {
            var list = await _context.TB_LOG_ATIVIDADE.ToListAsync();
            return _mapper.Map<List<LogAtividadeDTO>>(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LogAtividadeDTO>> Get(int id)
        {
            var l = await _context.TB_LOG_ATIVIDADE.FindAsync(id);
            if (l == null) return NotFound();
            return _mapper.Map<LogAtividadeDTO>(l);
        }

        [HttpPost]
        public async Task<ActionResult<LogAtividadeDTO>> Create(LogAtividadeCreateDTO dto)
        {
            var l = _mapper.Map<LogAtividade>(dto);
            l.DtAcao = DateTime.Now;
            _context.TB_LOG_ATIVIDADE.Add(l);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = l.IdLog }, _mapper.Map<LogAtividadeDTO>(l));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, LogAtividadeDTO dto)
        {
            if (id != dto.IdLog) return BadRequest();
            var existing = await _context.TB_LOG_ATIVIDADE.FindAsync(id);
            if (existing == null) return NotFound();
            _mapper.Map(dto, existing);
            _context.Entry(existing).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var l = await _context.TB_LOG_ATIVIDADE.FindAsync(id);
            if (l == null) return NotFound();
            _context.TB_LOG_ATIVIDADE.Remove(l);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
