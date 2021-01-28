using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using crudPessoaFisica.Models;
using Microsoft.AspNetCore.Cors;

namespace crudPessoaFisica.Controllers
{
    [Route("api/PessoaFisicas")]
    [ApiController]
    public class PessoaFisicasController : ControllerBase
    {
        private readonly ContextDb _context;

        public PessoaFisicasController(ContextDb context)
        {
            _context = context;
        }

        // GET: api/PessoaFisicas
        [EnableCors("PolicyAccess")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaFisica>>> GetPessoas()
        {
            return await _context.PessoaFisica.ToListAsync();
        }

        // GET: api/PessoaFisicas/5
        [EnableCors("PolicyAccess")]
        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaFisica>> GetPessoaFisica(int id)
        {
            var pessoaFisica = await _context.PessoaFisica.FindAsync(id);

            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return pessoaFisica;
        }

        // PUT: api/PessoaFisicas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("PolicyAccess")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoaFisica(int id, PessoaFisica pessoaFisica)
        {
            if (id != pessoaFisica.Id)
            {
                return BadRequest();
            }

            _context.Entry(pessoaFisica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaFisicaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PessoaFisicas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("PolicyAccess")]
        [HttpPost]
        public async Task<ActionResult<PessoaFisica>> PostPessoaFisica(PessoaFisica pessoaFisica)
        {
            _context.PessoaFisica.Add(pessoaFisica);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPessoaFisica), new { id = pessoaFisica.Id }, pessoaFisica);
        }

        // DELETE: api/PessoaFisicas/5
        [EnableCors("PolicyAccess")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoaFisica(int id)
        {
            var pessoaFisica = await _context.PessoaFisica.FindAsync(id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }

            _context.PessoaFisica.Remove(pessoaFisica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PessoaFisicaExists(int id)
        {
            return _context.PessoaFisica.Any(e => e.Id == id);
        }
    }
}
