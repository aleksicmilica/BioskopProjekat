using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProjekcijaController : ControllerBase
    {
        public BioskopContext Context { get; set; }

        public ProjekcijaController(BioskopContext context)
        {
            Context = context;
        }



       

        [Route("PromenitiProjekciju/{idProjekcije}/{Datum2}")]
        [HttpPut]
        public async Task<ActionResult> PromenitiProjekciju(int idProjekcije, string Datum2)
        {

            if (string.IsNullOrEmpty(Datum2))
            {
                return BadRequest("Nije unet korigovani datum projekcije");

            }
            if (idProjekcije < 0)
            {
                return BadRequest("Nije unet dobar id bioskopa");
            }

            try
            {
                var v2 = DateTime.ParseExact(Datum2, "yyyy-MM-dd HH:mm", null);
                
                

                var projekcija = await Context.Projkecije.Where( p => p.Id == idProjekcije).Include(p => p.Film).FirstOrDefaultAsync();
                if (projekcija == null)
                    return BadRequest("Ne postoji ta projekcija");

                var film = projekcija.Film;
                if (film == null) {
                    return BadRequest("Film ne postoji");
                }
                                                   
                var vreme = Datum2.Split(" ");
                if (film.datumKraja.ToString("yyyy-MM-dd").CompareTo(vreme[0]) < 0 || film.datumPocetka.ToString("yyyy-MM-dd").CompareTo(vreme[0]) > 0)
                {
                    return BadRequest("Film nije dostupan tog datuma");
                }



                projekcija.vreme = v2;

                Context.Projkecije.Update(projekcija);

                await Context.SaveChangesAsync();
                return Ok("Uspešno izmenjena projekcija filma ");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

}