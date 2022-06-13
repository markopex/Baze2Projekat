using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp2
{
    public partial class Popravlja
    {
        public DateTime Datum { get; set; }
        public int BrojKv { get; set; }
        public int Radnik { get; set; }

        public virtual Kvar BrojKvNavigation { get; set; }
        public virtual Elektricar RadnikNavigation { get; set; }
    }
}
