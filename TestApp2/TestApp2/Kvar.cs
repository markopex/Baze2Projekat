using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp2
{
    public partial class Kvar
    {
        public int BrojKv { get; set; }
        public DateTime DatumPr { get; set; }
        public int PotId { get; set; }
        public string Opis { get; set; }
        public DateTime? DatumPopravke { get; set; }
        public int? Popravio { get; set; }

        public virtual Elektricar PopravioNavigation { get; set; }
        public virtual Potrosac Pot { get; set; }
    }
}
