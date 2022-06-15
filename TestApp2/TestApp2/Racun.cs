using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp2
{
    public partial class Racun
    {
        public int BrojRacuna { get; set; }
        public int StrujomerBroj { get; set; }
        public int Potrosac { get; set; }
        public DateTime Datum { get; set; }
        public decimal Iznos { get; set; }
        public decimal Kwh { get; set; }
        public int Period { get; set; }

        public virtual Potrosac PotrosacNavigation { get; set; }
        public virtual Strujomer StrujomerBrojNavigation { get; set; }
    }
}
