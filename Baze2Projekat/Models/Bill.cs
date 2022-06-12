using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Bill
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double ConsumedPower { get; set; }
        [Required]
        public int Month { get; set; }
        [Required]
        public UsingMeter ConsumerMeter { get; set; }
    }
}
