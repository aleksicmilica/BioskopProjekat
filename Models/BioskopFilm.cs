using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Models{


    public class BioskopFilm{

        [JsonIgnore]

        [Key]
        public int Id { get; set; }

        [JsonIgnore]
        public  Bioskop Bioskop { get; set; }
        
        public Film Film { get; set; }

        
    }
}