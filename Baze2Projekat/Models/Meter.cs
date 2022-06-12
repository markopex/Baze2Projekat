using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Meter
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public double Power { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public MeterType Type { get; set; }
        [Required]
        public double PowerCount { get; set; }
        public Consumer Consumer { get; set; }
    }
}
