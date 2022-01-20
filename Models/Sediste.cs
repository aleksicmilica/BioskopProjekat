using System.ComponentModel.DataAnnotations;
namespace Models{
    public class Sediste{
        [Key]
        public int Id { get; set; }
        
        [Required]
 
        public Sala sala{get; set;}
        
        [Required]
 
        public int BrReda { get; set; }
        
        [Required]
 
        public int BrSedistaURedu { get; set; }

    
    }
}