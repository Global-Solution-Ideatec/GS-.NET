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
    public class HabilidadesController : ControllerBase
    {
        private readonly IdeaTecContext _context;
        private readonly IMapper _mapper;

        public HabilidadesController(IdeaTecContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HabilidadeDTO>>> GetAll()
        {
            var list = await _context.TB_HABILIDADE.ToListAsync();
            return _mapper.Map<List<HabilidadeDTO>>(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HabilidadeDTO>> Get(int id)
        {
            var h = await _context.TB_HABILIDADE.FindAsync(id);
            if (h == null) return NotFound();
            return _mapper.Map<HabilidadeDTO>(h);
        }

        [HttpPost]
        public async Task<ActionResult<HabilidadeDTO>> Create(HabilidadeCreateDTO dto)
        {
            var h = _mapper.Map<Habilidade>(dto);
            _context.TB_HABILIDADE.Add(h);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = h.IdHabilidade }, _mapper.Map<HabilidadeDTO>(h));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, HabilidadeDTO dto)
        {
            if (id != dto.IdHabilidade) return BadRequest();
            var existing = await _context.TB_HABILIDADE.FindAsync(id);
            if (existing == null) return NotFound();
            _mapper.Map(dto, existing);
            _context.Entry(existing).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var h = await _context.TB_HABILIDADE.FindAsync(id);
            if (h == null) return NotFound();
            _context.TB_HABILIDADE.Remove(h);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
