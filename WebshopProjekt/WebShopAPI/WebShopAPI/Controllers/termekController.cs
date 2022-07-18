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
    public class termekController : ControllerBase
    {
        private readonly webaruhazContext _context;

        public termekController(webaruhazContext context)
        {
            _context = context;
        }

        // GET: api/termek
        [HttpGet]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<IEnumerable<termek>>> Gettermek()
        {
            return await _context.termek.ToListAsync();
        }

        // GET: api/termek/5
        [HttpGet("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<termek>> Gettermek(int id)
        {
            var termek = await _context.termek.FindAsync(id);

            if (termek == null)
            {
                return NotFound();
            }

            return termek;
        }

        // PUT: api/termek/cikkszam
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{cikkszam}")]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> Puttermek(int id, termek termek)
        {
            var t = await _context.termek.AnyAsync(x => x.Cikkszam == termek.Cikkszam);
            if (t == false)
            {
                return Conflict("Nincs még ilyen cikkszám a listában");
            }

            return NoContent();
            

          
        }

        // POST: api/termek
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [EnableCors("CorsPolicy")]

       
        public async Task<ActionResult<termek>> Posttermek(termek termek)
        {
            var t = await _context.termek.AnyAsync(x => x.Cikkszam == termek.Cikkszam);

            if (t)
            {
                return Conflict("Van már ilyen cikkszám a listában");
            }

            else
            {
                return Conflict("Nincs ilyen cikkszám a listában");
            }

       
        }

        // DELETE: api/termek/5
        [HttpDelete("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> Deletetermek(int id)
        {
            var termek = await _context.termek.FindAsync(id);
            if (termek == null)
            {
                return NotFound();
            }

            _context.termek.Remove(termek);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool termekExists(int id)
        {
            return _context.termek.Any(e => e.Cikkszam == id);
        }

        [HttpGet("db")]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<IEnumerable<termek>>> GetNumberOfProduct()
        {
            int count = await _context.termek.Where(x => x.Cikkszam!=0 && x.Akcios_e==true).CountAsync();
            return Ok(count);
        }
    }
}
