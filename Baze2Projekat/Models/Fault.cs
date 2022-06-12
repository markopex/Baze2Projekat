using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Fault
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime ReportDate { get; set; }
        [Required]
        public Boolean Status { get; set; }
        [Required]
        public string Description { get; set; }

    }
}
