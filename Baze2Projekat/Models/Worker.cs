using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Worker
    {
        // JMBG
        public int Id { get; set; }
        public DateTime Birthday { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string WorkPlace { get; set; }
        public List<Vacation> Vacations { get; set; }
    }
}
