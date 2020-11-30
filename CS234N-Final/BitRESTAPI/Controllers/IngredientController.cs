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
    public class IngredientController : Controller
    {
        private readonly BitContext _context;

        public IngredientController(BitContext context)
        {
            _context = context;
        }

        //Get: api/Ingredient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredients()
        {
            return await _context.Ingredient.ToListAsync();
        }

        //Get: api/Ingredient/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredient>> GetSpecificIngredient(int id)
        {
            var ingredient = await _context.Ingredient.FindAsync(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return ingredient;
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredient.Any(e => e.IngredientId == id);
        }
    }
}
