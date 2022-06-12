using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class Potrosac
    {
        public Potrosac()
        {
            Kvars = new HashSet<Kvar>();
        }

        public int PotId { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }

        public virtual ICollection<Kvar> Kvars { get; set; }
    }
}
