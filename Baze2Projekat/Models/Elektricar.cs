using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class Elektricar
    {
        public int Jmbg { get; set; }

        public virtual Radnik JmbgNavigation { get; set; }
    }
}
