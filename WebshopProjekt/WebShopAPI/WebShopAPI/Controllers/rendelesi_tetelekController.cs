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
    public class rendelesi_tetelekController : ControllerBase
    {
        private readonly webaruhazContext _context;

        public rendelesi_tetelekController(webaruhazContext context)
        {
            _context = context;
        }

        // GET: api/rendelesi_tetelek
        [HttpGet]
        [EnableCors("CorsPolicy")]
        public async Task<IEnumerable<RendelesiTetelDTO>> Getrendelesi_tetelek()
        {
            var query = from p1 in _context.rendelesi_tetelek
                        join m1 in _context.termek on p1.Cikkszam equals m1.Cikkszam
                        join r1 in _context.rendeles on p1.Rendeles_id equals r1.Rendeles_id
                        join v1 in _context.vasarlo on r1.Vasarlo_id equals v1.Vasarlo_id
                        select new { id = p1.Cikkszam, Mennyiseg = p1.Mennyiseg, TermekNev = m1.Cikknev, Vasarlo = v1.TeljesNev };

            return await query
                .Select(p => new RendelesiTetelDTO() { id = p.id, Mennyiseg = p.Mennyiseg, TermekNev = p.TermekNev, VasarloNev = p.Vasarlo })
                .ToListAsync();
        }

        // GET: api/rendelesi_tetelek/5
        [HttpGet("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<RendelesiTetelDTO>> Getrendelesi_tetelek(int id)
        {
           
            var query = from p1 in _context.rendelesi_tetelek
                        join m1 in _context.termek on p1.Cikkszam equals m1.Cikkszam
                        join r1 in _context.rendeles on p1.Rendeles_id equals r1.Rendeles_id
                        join v1 in _context.vasarlo on r1.Vasarlo_id equals v1.Vasarlo_id
                        where p1.Rendelesi_tetelek_id == id
                        select new { id = p1.Cikkszam, Mennyiseg = p1.Mennyiseg, TermekNev = m1.Cikknev, Vasarlo = v1.TeljesNev };

            return query
                .Select(p => new RendelesiTetelDTO() { id = p.id, Mennyiseg = p.Mennyiseg, TermekNev = p.TermekNev, VasarloNev = p.Vasarlo })
                .SingleOrDefault();
        }

        // PUT: api/rendelesi_tetelek/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> Putrendelesi_tetelek(int id, rendelesi_tetelek rendelesi_tetelek)
        {
            if (id != rendelesi_tetelek.Rendelesi_tetelek_id)
            {
                return BadRequest();
            }

            _context.Entry(rendelesi_tetelek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!rendelesi_tetelekExists(id))
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

        // POST: api/rendelesi_tetelek
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<rendelesi_tetelek>> Postrendelesi_tetelek(rendelesi_tetelek rendelesi_tetelek)
        {
            _context.rendelesi_tetelek.Add(rendelesi_tetelek);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (rendelesi_tetelekExists(rendelesi_tetelek.Rendelesi_tetelek_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getrendelesi_tetelek", new { id = rendelesi_tetelek.Rendelesi_tetelek_id }, rendelesi_tetelek);
        }

        // DELETE: api/rendelesi_tetelek/5
        [HttpDelete("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> Deleterendelesi_tetelek(int id)
        {
            var rendelesi_tetelek = await _context.rendelesi_tetelek.FindAsync(id);
            if (rendelesi_tetelek == null)
            {
                return NotFound();
            }

            _context.rendelesi_tetelek.Remove(rendelesi_tetelek);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool rendelesi_tetelekExists(int id)
        {
            return _context.rendelesi_tetelek.Any(e => e.Rendelesi_tetelek_id == id);
        }
    }
}
