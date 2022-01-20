using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;

namespace Models{
    public class Projekcija{
        [Key]
        public int Id { get; set; }
        
        [Required]
 
        public DateTime vreme{get; set;}
        [Required]
 
        public Sala sala{get; set;}

        public List<Karta> Karte { get; set; }
        
        public Film Film { get; set; }

        [JsonIgnore]
        public Bioskop Bioskop { get; set; }
    }
}