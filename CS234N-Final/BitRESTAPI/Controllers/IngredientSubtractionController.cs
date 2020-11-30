using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BitEFClasses.Models;

namespace BitRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientSubtractionController : Controller
    {
        private readonly BitContext _context;

        public IngredientSubtractionController(BitContext context)
        {
            _context = context;
        }

        //Get: api/IngredientSubtraction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientInventorySubtraction>>> GetSubtractions()
        {
            return await _context.IngredientInventorySubtraction.ToListAsync();
        }

        //Post: api/IngredientSubtraction
        [HttpPost]
        public async Task<ActionResult<IngredientInventorySubtraction>> PostSubtraction(IngredientInventorySubtraction subtraction)
        {
            _context.IngredientInventorySubtraction.Add(subtraction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubtractions", new { id = subtraction.IngredientInventorySubtractionId }, subtraction);
        }

        private bool IngredientSubtractionExists(int id)
        {
            return _context.IngredientInventorySubtraction.Any(e => e.IngredientInventorySubtractionId == id);
        }
    }
}
