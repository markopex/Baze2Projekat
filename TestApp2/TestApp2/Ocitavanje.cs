using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp2
{
    public partial class Ocitavanje
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public decimal Kwh { get; set; }
        public int Strujomer { get; set; }
        public int? Elektricar { get; set; }
        public int Period { get; set; }

        public virtual Elektricar ElektricarNavigation { get; set; }
        public virtual Strujomer StrujomerNavigation { get; set; }
    }
}
