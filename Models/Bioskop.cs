using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Models{
    public class Bioskop{
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Naziv{get; set;}


        public List<Sala> Sale { get; set; }

        public List<BioskopFilm> Filmovi { get; set; }
        public List<Projekcija> Projekcije { get; set; }
    }
}