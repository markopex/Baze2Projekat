using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp2
{
    public partial class Kvar
    {
        public Kvar()
        {
            Popravljas = new HashSet<Popravlja>();
        }

        public int BrojKv { get; set; }
        public DateTime DatumPr { get; set; }
        public int PotId { get; set; }
        public string Opis { get; set; }

        public virtual Potrosac Pot { get; set; }
        public virtual ICollection<Popravlja> Popravljas { get; set; }
    }
}
