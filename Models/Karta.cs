using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Models{
    public class Karta{
        [Key]
        public int Id { get; set; }
      
        [Required]
 
        public Sediste sediste{get; set;}

        
        public Korisnik korisnik{get; set;}
        
        [JsonIgnore]
        public Projekcija Projekcija { get; set; }
    }
}