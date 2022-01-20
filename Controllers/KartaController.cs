using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace bioskop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KartaController : ControllerBase
    {
        public BioskopContext Context { get; set; }

        public KartaController(BioskopContext context)
        {
            Context = context;
        }

        [Route("KupiKartu/{idProjekcija}/{Red}/{BrojURedu}/{korisnickoIme}")]
        [HttpPost]
        public async Task<ActionResult> DodajKartu(int idProjekcija, int Red, int BrojURedu, string korisnickoIme)
        {

            if (idProjekcija < 0)
            {
                return BadRequest("Nije unet bioskop");

            }

            if (Red == 0)
            {
                return BadRequest("Zaboravili ste da unesete red");
            }
            if (BrojURedu == 0)
            {
                return BadRequest("Zaboravili ste da unesete broj sedista");
            }
            if (string.IsNullOrEmpty(korisnickoIme))
            {
                return BadRequest("Nema email!");

            }


            try
            {


                
                var projekcija = await Context.Projkecije.Where(p => p.Id == idProjekcija).Include(p=>p.Film).FirstOrDefaultAsync();

                if (projekcija == null)
                    return BadRequest("Projekcija ne postoji");

                double cena = projekcija.Film.Cena;

                Korisnik k;

                k = await Context.Korisnici.Where(p => p.email == korisnickoIme).FirstOrDefaultAsync();

                if (k == null)
                {
                    return BadRequest("Ne postoji korisnik sa korisnickim imenom");
                }

                Karta karta = new Karta
                {
                    Projekcija = projekcija,
                    sediste = new Sediste
                    {
                        sala = projekcija.sala,
                        BrReda = Red,
                        BrSedistaURedu = BrojURedu

                    },
                    korisnik = k

                };

                Context.Karte.Add(karta);

                await Context.SaveChangesAsync();

                return Ok($"Rezervisana je karta za film {projekcija.Film.naziv}, sediste u redu {Red},broj mesta {BrojURedu}, po ceni {cena}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}
