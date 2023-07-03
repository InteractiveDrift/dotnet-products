using System;
using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Producer {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Country { get; set; } 
    }
}