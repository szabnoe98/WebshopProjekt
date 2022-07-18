using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.DTO;
using WebShopAPI.Models;

namespace WebShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class vasarloController : ControllerBase
    {
        private readonly webaruhazContext _context;

        public vasarloController(webaruhazContext context)
        {
            _context = context;
        }

        // GET: api/vasarlo
        [HttpGet]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<IEnumerable<vasarlo>>> Getvasarlo()
        {
            return await _context.vasarlo.ToListAsync();
        }

        // GET: api/vasarlo/5
        [HttpGet("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<vasarlo>> Getvasarlo(int id)
        {
            var vasarlo = await _context.vasarlo.FindAsync(id);

            if (vasarlo == null)
            {
                return NotFound();
            }

            return vasarlo;
        }

        // PUT: api/vasarlo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> Putvasarlo(int id, vasarlo vasarlo)
        {
            if (id != vasarlo.Vasarlo_id)
            {
                return BadRequest();
            }

            _context.Entry(vasarlo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vasarloExists(id))
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

        // POST: api/vasarlo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [EnableCors("CorsPolicy")]

      
    public async Task<ActionResult<RendelesiTetelDTO>> Postvasarlo(vasarlo vasarlo)
        {
            var van_e = await _context.vasarlo.AnyAsync(x => x.Felhasznalonev == vasarlo.Felhasznalonev);

            if (van_e)
            {
                return Conflict("Ezzel a felhasználónévvel már van regisztrált vásárló");
            }
            else
            {
                return Conflict("Ezzel a felhasználónévvel még nem regisztrált senki, használható");
            }

          
        }

        // DELETE: api/vasarlo/5
        [HttpDelete("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> Deletevasarlo(int id)
        {
            var vasarlo = await _context.vasarlo.FindAsync(id);
            if (vasarlo == null)
            {
                return NotFound();
            }

            _context.vasarlo.Remove(vasarlo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool vasarloExists(int id)
        {
            return _context.vasarlo.Any(e => e.Vasarlo_id == id);
        }

       
        
    }
}
