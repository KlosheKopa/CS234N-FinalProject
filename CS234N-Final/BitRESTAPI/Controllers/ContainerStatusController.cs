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
    public class ContainerStatusController : Controller
    {
        private readonly BitContext _context;

        public ContainerStatusController(BitContext context)
        {
            _context = context;
        }

        //Get: api/ContainerStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContainerStatus>>> GetContainerStatuses()
        {
            return await _context.ContainerStatus.ToListAsync();
        }
    }
}
