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
    public class RecomendacoesController : ControllerBase
    {
        private readonly IdeaTecContext _context;
        private readonly IMapper _mapper;

        public RecomendacoesController(IdeaTecContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecomendacaoDTO>>> GetAll()
        {
            var list = await _context.TB_RECOMENDACAO_IA.ToListAsync();
            return _mapper.Map<List<RecomendacaoDTO>>(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecomendacaoDTO>> Get(int id)
        {
            var rec = await _context.TB_RECOMENDACAO_IA.FindAsync(id);
            if (rec == null) return NotFound();
            return _mapper.Map<RecomendacaoDTO>(rec);
        }

        [HttpPost]
        public async Task<ActionResult<RecomendacaoDTO>> Create(RecomendacaoCreateDTO dto)
        {
            var r = _mapper.Map<RecomendacaoIA>(dto);
            r.DtRecomendacao = DateTime.Now;
            _context.TB_RECOMENDACAO_IA.Add(r);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = r.IdRecomendacao }, _mapper.Map<RecomendacaoDTO>(r));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RecomendacaoDTO dto)
        {
            if (id != dto.IdRecomendacao) return BadRequest();
            var existing = await _context.TB_RECOMENDACAO_IA.FindAsync(id);
            if (existing == null) return NotFound();
            _mapper.Map(dto, existing);
            _context.Entry(existing).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var r = await _context.TB_RECOMENDACAO_IA.FindAsync(id);
            if (r == null) return NotFound();
            _context.TB_RECOMENDACAO_IA.Remove(r);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
