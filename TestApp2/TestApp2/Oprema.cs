using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp2
{
    public partial class Oprema
    {
        public Oprema()
        {
            Zaduzujes = new HashSet<Zaduzuje>();
        }

        public int OprId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public virtual ICollection<Zaduzuje> Zaduzujes { get; set; }
    }
}
