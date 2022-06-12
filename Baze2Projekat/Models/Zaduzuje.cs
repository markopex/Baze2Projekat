using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class Zaduzuje
    {
        public DateTime Datum { get; set; }
        public int ElektricarId { get; set; }
        public int OprId { get; set; }

        public virtual Elektricar Elektricar { get; set; }
        public virtual Oprema Opr { get; set; }
    }
}
