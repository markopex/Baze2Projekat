using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Vacation
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Worker Worker { get; set; }
        public DateTime From { get; set; }
        [Required]
        public DateTime To { get; set; }
        [Required]
        public Boolean IsPaid { get; set; }
        [Required]
        public string Reason { get; set; }
    }
}
