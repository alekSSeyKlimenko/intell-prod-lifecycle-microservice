using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IntellProdLifeCycleMS.Domain.Models;
using IntellProdLifeCycleMS.Infrastructure.Data;

namespace IntellProdLifeCycleMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationCertificatesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegistrationCertificatesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/RegistrationCertificates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistrationCertificate>>> GetRegistrationCertificate()
        {
            return await _context.RegistrationCertificate.ToListAsync();
        }

        // GET: api/RegistrationCertificates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistrationCertificate>> GetRegistrationCertificate(int id)
        {
            var registrationCertificate = await _context.RegistrationCertificate.FindAsync(id);

            if (registrationCertificate == null)
            {
                return NotFound();
            }

            return registrationCertificate;
        }

        // PUT: api/RegistrationCertificates/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistrationCertificate(int id, RegistrationCertificate registrationCertificate)
        {
            if (id != registrationCertificate.Id)
            {
                return BadRequest();
            }

            _context.Entry(registrationCertificate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistrationCertificateExists(id))
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

        // POST: api/RegistrationCertificates
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RegistrationCertificate>> PostRegistrationCertificate(RegistrationCertificate registrationCertificate)
        {
            _context.RegistrationCertificate.Add(registrationCertificate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistrationCertificate", new { id = registrationCertificate.Id }, registrationCertificate);
        }

        // DELETE: api/RegistrationCertificates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RegistrationCertificate>> DeleteRegistrationCertificate(int id)
        {
            var registrationCertificate = await _context.RegistrationCertificate.FindAsync(id);
            if (registrationCertificate == null)
            {
                return NotFound();
            }

            _context.RegistrationCertificate.Remove(registrationCertificate);
            await _context.SaveChangesAsync();

            return registrationCertificate;
        }

        private bool RegistrationCertificateExists(int id)
        {
            return _context.RegistrationCertificate.Any(e => e.Id == id);
        }
    }
}
