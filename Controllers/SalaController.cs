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
    public class SalaController : ControllerBase
    {
        public BioskopContext Context { get; set; }

        public SalaController(BioskopContext context)
        {
            Context = context;
        }

        [Route("Sala/{idProjekcije}")]
        [HttpGet]
        public async Task<ActionResult> VratiSalu(int idProjekcije)
        {
            try
            {
                return Ok(await Context.Projkecije.Where(p => p.Id == idProjekcije).Include(p => p.Karte ).ThenInclude(f=>f.sediste)
                .Include( p => p.sala).Select(s=> new {s.sala.BrRedova, s.sala.BrSedistaPoRedu, s.Karte}).ToListAsync());
                        
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}