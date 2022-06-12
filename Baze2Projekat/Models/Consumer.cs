using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Consumer
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
