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
    public class rendelesController : ControllerBase
    {
        private readonly webaruhazContext _context;

        public rendelesController(webaruhazContext context)
        {
            _context = context;
        }

        // GET: api/rendeles
        [HttpGet]
        [EnableCors("CorsPolicy")]
        [Route("")]//api/rendeles
        public async Task<ActionResult<IEnumerable<rendeles>>> Getrendeles()
        {
            return await _context.rendeles.ToListAsync();
        }

        // GET: api/rendeles/5
        [HttpGet("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<RendelesDTO>> Getrendeles(int id)
        {
            var q = _context.rendeles.Where(r => r.Rendeles_id == id)
                .Include(x => x.rendelesi_tetelek)
                .ThenInclude(t => t.Termek)
                .Include(x => x.Vasarlo);

            var l = q.ToList();

            return RendelesDTO.ConvertToDTO(l.FirstOrDefault());
        }

        // PUT: api/rendeles/
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> Putrendeles(rendeles rendeles)
        {
            var rendelesid = await _context.rendeles.AnyAsync(x => x.Rendeles_id == rendeles.Rendeles_id);
            if (rendelesid)
            {
                return BadRequest("Van már ilyen azonosítóval rendelés");
            }
            else
            {
                return BadRequest("Nincs még ilyen azonosítóval rendelés");
            }

            
        }

        // POST: api/rendeles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<rendeles>> Postrendeles(rendeles rendeles)
        {
            // ha nincs megadva dátum akkor a mai dátum fog megjelenni
            rendeles.Rendeles_datuma = DateTime.Now;

            var r_Tetelek = new List<rendelesi_tetelek>();
            rendeles.rendelesi_tetelek.ForEach(t => r_Tetelek.Add(t));
            rendeles.rendelesi_tetelek.Clear();

            _context.rendeles.Add(rendeles);
            await _context.SaveChangesAsync();

            foreach (var tetel in r_Tetelek)
            {
                tetel.Rendeles_id = rendeles.Rendeles_id;
                _context.rendelesi_tetelek.Add(tetel);
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getrendeles", new { id = rendeles.Rendeles_id }, rendeles);
        }

        // DELETE: api/rendeles/5
        [HttpDelete("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> Deleterendeles(int id)
        {
            var rendeles = await _context.rendeles.FindAsync(id);
            if (rendeles == null)
            {
                return NotFound();
            }

            _context.rendeles.Remove(rendeles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool rendelesExists(int id)
        {
            return _context.rendeles.Any(e => e.Rendeles_id == id);
        }
    }
}
