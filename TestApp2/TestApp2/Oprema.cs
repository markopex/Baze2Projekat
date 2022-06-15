﻿using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp2
{
    public partial class Oprema
    {
        public int OprId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime? DatumZaduzivanja { get; set; }
        public int? Zaduzio { get; set; }

        public virtual Radnik ZaduzioNavigation { get; set; }
    }
}
