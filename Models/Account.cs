using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Account
    {
        [Key]
        public string username { get; set; }
        public int number_of_characters { get; set; }
        public bool violations { get; set; }
    }
}
