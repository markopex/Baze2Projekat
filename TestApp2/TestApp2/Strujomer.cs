using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp2
{
    public partial class Strujomer
    {
        public Strujomer()
        {
            Ocitavanjes = new HashSet<Ocitavanje>();
        }

        public int Broj { get; set; }
        public decimal Snaga { get; set; }
        public decimal UkupnoKwh { get; set; }
        public int Tip { get; set; }
        public decimal? TrKwh { get; set; }
        public int Potrosac { get; set; }

        public virtual Potrosac PotrosacNavigation { get; set; }
        public virtual ICollection<Ocitavanje> Ocitavanjes { get; set; }
    }
}
