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
    public class FilmController : ControllerBase
    {
        public BioskopContext Context { get; set; }

        public FilmController(BioskopContext context)
        {
            Context = context;
        }



        [Route("Projekcije/{idFilm}/{idBioskop}")]
        [HttpGet]
        public async Task<ActionResult> VratiProjekcije(int idFilm, int idBioskop)
        {
            try
            {
             
                var ret = await Context.Projkecije.Where(p => p.Film.Id==idFilm && p.Bioskop.Id == idBioskop).Include(p => p.Film).Include(p => p.sala).ToListAsync();
                return Ok(ret);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("IzbrisiFilm/{IdBioskopa}/{idFilma}")]
        [HttpDelete]
        public async Task<ActionResult> izbrisiFilm(int IdBioskopa, int idFilma)
        {
            if (IdBioskopa == 0)
                return BadRequest("Nije odabran bioskop");
            if (idFilma == 0)
                return BadRequest("Nije odabran film");

            try
            {

                var film = await Context.BioskopiFilmovi.Where(b => b.Film.Id == idFilma && b.Bioskop.Id == IdBioskopa).FirstOrDefaultAsync();

                if (film == null)
                    return BadRequest("Ne postoji film u bioskopu.");

                List<Projekcija> projekcije = await Context.Projkecije.Where(p => p.Film.Id == idFilma && p.Bioskop.Id == IdBioskopa).ToListAsync();



                if (projekcije != null)
                {
                    foreach (var pr in projekcije)
                    {
                        List<Karta> karte = await Context.Karte.Where(p => p.Projekcija.Id == pr.Id).ToListAsync();

                        if (karte != null)
                            Context.Karte.RemoveRange(karte);
                    }
                    Context.Projkecije.RemoveRange(projekcije);

                }

                Context.BioskopiFilmovi.Remove(film);

                await Context.SaveChangesAsync();


                return Ok("Uspesno izbrisan film!");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }

}