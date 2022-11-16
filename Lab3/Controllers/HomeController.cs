
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab3.Models;
using System;

namespace Lab3.Controllers
{
    [Route("api/Reception")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly RecContext _context;

        public HomeController(RecContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reception>>> GGetReceptions()
        {
            return await _context.Receptions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reception>> GetReception(int Id)
        {
            var reception  = await _context.Receptions.FindAsync(Id);

            if (reception == null)
            {
                return NotFound();
            }

            return reception;
        }

 

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReception(int Id, Reception reception)
        {
            if (Id != reception.Id)
            {
                return BadRequest();
            }

            _context.Entry(reception).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceptionExists(Id))
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


        [HttpPost]
        public async Task<ActionResult<Reception>> PostReception(Reception reception)
        {
            _context.Receptions.Add(reception);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetReception), new { Id = reception.Id }, reception);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReception(int Id)
        {
            var reception = await _context.Receptions.FindAsync(Id);
            if (reception == null)
            {
                return NotFound();
            }

            _context.Receptions.Remove(reception);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReceptionExists(int Id)
        {
            return _context.Receptions.Any(e => e.Id == Id);
        }
    }
}
