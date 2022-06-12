using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UsingMeter
    {
        [Required]
        public Consumer Consumer { get; set; }
        [Required]
        public Meter Meter { get; set; }
    }
}
