using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BioskopController : ControllerBase
    {
        public BioskopContext Context { get; set; }

        public BioskopController(BioskopContext context)
        {
            Context = context;
        }

        [Route("Bioskopi")]
        [HttpGet]
        public async Task<ActionResult> VratiBioskope()
        {
            try
            {
                return Ok(
                    await Context.Bioskopi.Include(bioskop => bioskop.Filmovi).ThenInclude(bf => bf.Film).ToListAsync());
                      
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}