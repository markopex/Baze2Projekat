using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class Odsustvo
    {
        public int OdsId { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public bool Placeno { get; set; }
        public string Razlog { get; set; }
        public int Radnik { get; set; }

        public virtual Radnik RadnikNavigation { get; set; }
    }
}
