using DoradoB2BCoreContext.Data;
using DoradoB2BCoreContext.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCoreWebCon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditApiController : ControllerBase
    {
        private readonly Doradob2bContext _context;

        public AuditApiController(Doradob2bContext context)
        {
            _context = context;
        }

        // GET: api/AuditApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Audit>>> GetAudit()
        {
            return await _context.Audit.ToListAsync();
        }

        // GET: api/AuditApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Audit>> GetAudit(int id)
        {
            Audit audit = await _context.Audit.FindAsync(id);

            if (audit == null)
            {
                return NotFound();
            }

            return audit;
        }

        // PUT: api/AuditApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAudit(int id, Audit audit)
        {
            if (id != audit.Id)
            {
                return BadRequest();
            }

            _context.Entry(audit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditExists(id))
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

        // POST: api/AuditApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Audit>> PostAudit(Audit audit)
        {
            _context.Audit.Add(audit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAudit", new { id = audit.Id }, audit);
        }

        // DELETE: api/AuditApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Audit>> DeleteAudit(int id)
        {
            Audit audit = await _context.Audit.FindAsync(id);
            if (audit == null)
            {
                return NotFound();
            }

            _context.Audit.Remove(audit);
            await _context.SaveChangesAsync();

            return audit;
        }

        private bool AuditExists(int id)
        {
            return _context.Audit.Any(e => e.Id == id);
        }
    }
}
