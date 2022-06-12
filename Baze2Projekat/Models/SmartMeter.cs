using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SmartMeter: Meter
    {
        public SmartMeter()
        {
            Type = MeterType.SMART;
        }

        [Required]
        public double CurrentPower { get; set; }

    }
}
