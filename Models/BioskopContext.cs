using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class BioskopContext : DbContext
    {
        public DbSet<Film> Filmovi { get; set; }
        public DbSet<Projekcija> Projkecije { get; set; }
     
        public DbSet<Karta> Karte { get; set; }

        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Sala> Sale{get; set;}
        public DbSet<Sediste> Sedista{get;set;}
        public DbSet<Bioskop> Bioskopi{get; set;}
        public DbSet<BioskopFilm> BioskopiFilmovi{get; set;}
        public BioskopContext(DbContextOptions options) : base(options)
        {

        }

        
    }
}