using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Player
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; } 
        public string username { get; set; } 
        public string last_location { get; set; }
        public int player_level { get; set; }   
    }
}
