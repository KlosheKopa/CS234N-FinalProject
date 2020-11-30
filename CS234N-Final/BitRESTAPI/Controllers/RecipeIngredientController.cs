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
    public class RecipeIngredientController : Controller
    {
        private readonly BitContext _context;

        public RecipeIngredientController(BitContext context)
        {
            _context = context;
        }

        //Get: api/RecipeIngredient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeIngredient>>> GetRecipeIngredients()
        {
            return await _context.RecipeIngredient.ToListAsync();
        }

    }
}
