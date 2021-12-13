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
        private readonly IPRepository _repository;

        public RegistrationCertificatesController(AppDbContext context)
        {
            _repository = new IPRepository(context);
        }

        // GET: api/RegistrationCertificates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistrationCertificate>>> GetRegistrationCertificate()
        {
            var certificates = await _repository.GetByIdAll<RegistrationCertificate>();

            if (certificates == null)
            {
                return NotFound();
            }
            return certificates;
        }

        // GET: api/RegistrationCertificates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistrationCertificate>> GetRegistrationCertificate(int id)
        {
            var certificate = await _repository.GetById<RegistrationCertificate>(id);

            if (certificate == null)
            {
                return NotFound();
            }

            return certificate;
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

            try
            {
                _repository.Update<RegistrationCertificate>(registrationCertificate);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repository.EntityExist<RegistrationCertificate>(id))
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
            await _repository.Add<RegistrationCertificate>(registrationCertificate);

            return CreatedAtAction("GetArticle", new { id = registrationCertificate.Id }, registrationCertificate);
        }

        // DELETE: api/RegistrationCertificates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RegistrationCertificate>> DeleteRegistrationCertificate(int id)
        {
            var certificate = await _repository.GetById<RegistrationCertificate>(id);
            if (certificate == null)
            {
                return NotFound();
            }

            await _repository.Delete<RegistrationCertificate>(certificate);

            return certificate;
        }
    }
}
