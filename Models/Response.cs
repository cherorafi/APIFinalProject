using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Models
{
    public class Response
    {
        public int statusCode { get; set; } 
        public string statusDescription { get; set; }
        public object? recieved { get; set; }
        
    }
}
