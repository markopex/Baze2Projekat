using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BorrowsEquipment
    {
        [Required]
        public Electrician Electrician { get; set; }
        [Required]
        public Equipment Equipment { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
