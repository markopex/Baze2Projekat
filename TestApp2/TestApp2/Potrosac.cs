using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp2
{
    public partial class Potrosac
    {
        public Potrosac()
        {
            Kvars = new HashSet<Kvar>();
            Racuns = new HashSet<Racun>();
            Strujomers = new HashSet<Strujomer>();
        }

        public int PotId { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }

        public virtual ICollection<Kvar> Kvars { get; set; }
        public virtual ICollection<Racun> Racuns { get; set; }
        public virtual ICollection<Strujomer> Strujomers { get; set; }
    }
}
