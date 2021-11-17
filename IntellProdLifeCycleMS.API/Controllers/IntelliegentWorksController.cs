using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IntellProdLifeCycleMS.Domain.Models;
using IntellProdLifeCycleMS.Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace IntellProdLifeCycleMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntelliegentWorksController : ControllerBase
    {

        private readonly ILogger<IntelliegentWorksController> _logger;

        public IntelliegentWorksController(ILogger<IntelliegentWorksController> logger)
        {
            _logger = logger;
        }

        public AppDbContext _context;

        public IntelliegentWorksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/IntelliegentWorks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IntelliegentWork>>> GetIntelliegentWorks()
        {
            return await _context.IntelliegentWorks.ToListAsync();
        }

        // GET: api/IntelliegentWorks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IntelliegentWork>> GetIntelliegentWork(int id)
        {
            var intelliegentWork = await _context.IntelliegentWorks.FindAsync(id);

            if (intelliegentWork == null)
            {
                return NotFound();
            }

            return intelliegentWork;
        }

        // PUT: api/IntelliegentWorks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIntelliegentWork(int id, IntelliegentWork intelliegentWork)
        {
            if (id != intelliegentWork.Id)
            {
                return BadRequest();
            }

            _context.Entry(intelliegentWork).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntelliegentWorkExists(id))
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

        // POST: api/IntelliegentWorks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IntelliegentWork>> PostIntelliegentWork(IntelliegentWork intelliegentWork)
        {
            _context.IntelliegentWorks.Add(intelliegentWork);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIntelliegentWork", new { id = intelliegentWork.Id }, intelliegentWork);
        }

        // DELETE: api/IntelliegentWorks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IntelliegentWork>> DeleteIntelliegentWork(int id)
        {
            var intelliegentWork = await _context.IntelliegentWorks.FindAsync(id);
            if (intelliegentWork == null)
            {
                return NotFound();
            }

            _context.IntelliegentWorks.Remove(intelliegentWork);
            await _context.SaveChangesAsync();

            return intelliegentWork;
        }

        private bool IntelliegentWorkExists(int id)
        {
            return _context.IntelliegentWorks.Any(e => e.Id == id);
        }
    }
}
