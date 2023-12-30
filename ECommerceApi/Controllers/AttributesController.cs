using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApi.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ECommerceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttributesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AttributesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Attribute>>> GetAttributes()
        {
            return await _context.Attributes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Attribute>> GetAttribute(int id)
        {
            var attribute = await _context.Attributes.FindAsync(id);

            if (attribute == null)
            {
                return NotFound();
            }

            return attribute;
        }

        [HttpPost]
        public async Task<ActionResult<Models.Attribute>> PostAttribute(Models.Attribute attribute)
        {
            _context.Attributes.Add(attribute);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAttribute), new { id = attribute.Id }, attribute);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttribute(int id, Models.Attribute attribute)
        {
            if (id != attribute.Id)
            {
                return BadRequest();
            }

            _context.Entry(attribute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttributeExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttribute(int id)
        {
            var attribute = await _context.Attributes.FindAsync(id);

            if (attribute == null)
            {
                return NotFound();
            }

            _context.Attributes.Remove(attribute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttributeExists(int id)
        {
            return _context.Attributes.Any(e => e.Id == id);
        }
    }

}

