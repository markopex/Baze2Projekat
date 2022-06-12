using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AnalogMeterReading
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double ReadingPower { get; set; }
        [Required]
        public Electrician Electrician { get; set; }
        [Required]
        public AnalogMeter AnalogMeter { get; set; }
    }
}
