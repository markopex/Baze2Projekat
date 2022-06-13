using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp2
{
    public partial class Kvar
    {
        public int PotId { get; set; }
        public int BrojKv { get; set; }
        public DateTime DatumPr { get; set; }
        public string Opis { get; set; }

        public virtual Potrosac Pot { get; set; }
    }
}
