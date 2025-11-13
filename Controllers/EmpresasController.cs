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
    public class EmpresasController : ControllerBase
    {
        private readonly IdeaTecContext _context;
        private readonly IMapper _mapper;

        public EmpresasController(IdeaTecContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaDTO>>> GetAll()
        {
            var list = await _context.TB_EMPRESA.ToListAsync();
            return _mapper.Map<List<EmpresaDTO>>(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresaDTO>> Get(int id)
        {
            var e = await _context.TB_EMPRESA.FindAsync(id);
            if (e == null) return NotFound();
            return _mapper.Map<EmpresaDTO>(e);
        }

        [HttpPost]
        public async Task<ActionResult<EmpresaDTO>> Create(EmpresaCreateDTO dto)
        {
            var e = _mapper.Map<Empresa>(dto);
            e.DtCadastro = DateTime.Now;
            _context.TB_EMPRESA.Add(e);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = e.IdEmpresa }, _mapper.Map<EmpresaDTO>(e));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EmpresaDTO dto)
        {
            if (id != dto.IdEmpresa) return BadRequest();
            var existing = await _context.TB_EMPRESA.FindAsync(id);
            if (existing == null) return NotFound();
            _mapper.Map(dto, existing);
            _context.Entry(existing).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var e = await _context.TB_EMPRESA.FindAsync(id);
            if (e == null) return NotFound();
            _context.TB_EMPRESA.Remove(e);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
