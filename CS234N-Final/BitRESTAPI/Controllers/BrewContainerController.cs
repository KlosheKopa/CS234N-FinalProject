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
    public class BrewContainerController : Controller
    {
        private readonly BitContext _context;

        public BrewContainerController(BitContext context)
        {
            _context = context;
        }

        //Get: api/BrewContainer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrewContainer>>> GetBrewContainers()
        {
            return await _context.BrewContainer.ToListAsync();
        }




    }
}
