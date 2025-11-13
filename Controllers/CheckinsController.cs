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
    public class CheckinsController : ControllerBase
    {
        private readonly IdeaTecContext _context;
        private readonly IMapper _mapper;

        public CheckinsController(IdeaTecContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CheckinDTO>>> GetAll()
        {
            var list = await _context.TB_CHECKIN_BEMESTAR.ToListAsync();
            return _mapper.Map<List<CheckinDTO>>(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CheckinDTO>> Get(int id)
        {
            var checkin = await _context.TB_CHECKIN_BEMESTAR.FindAsync(id);
            if (checkin == null) return NotFound();
            return _mapper.Map<CheckinDTO>(checkin);
        }

        [HttpPost]
        public async Task<ActionResult<CheckinDTO>> Create(CheckinCreateDTO dto)
        {
            var c = _mapper.Map<CheckinBemEstar>(dto);
            c.DtCheckin = DateTime.Now;
            _context.TB_CHECKIN_BEMESTAR.Add(c);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = c.IdCheckin }, _mapper.Map<CheckinDTO>(c));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CheckinDTO dto)
        {
            if (id != dto.IdCheckin) return BadRequest();
            var existing = await _context.TB_CHECKIN_BEMESTAR.FindAsync(id);
            if (existing == null) return NotFound();
            _mapper.Map(dto, existing);
            _context.Entry(existing).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var c = await _context.TB_CHECKIN_BEMESTAR.FindAsync(id);
            if (c == null) return NotFound();
            _context.TB_CHECKIN_BEMESTAR.Remove(c);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
