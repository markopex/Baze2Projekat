using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Fix
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public Fault Fault { get; set; }
        [Required]
        public Worker Worker { get; set; }
    }
}
