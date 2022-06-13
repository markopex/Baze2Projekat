using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp2
{
    public partial class Odsustvo
    {
        public int OdsId { get; set; }
        public int RadnikJmbg { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public int Placeno { get; set; }
        public string Razlog { get; set; }

        public virtual Radnik RadnikJmbgNavigation { get; set; }
    }
}
