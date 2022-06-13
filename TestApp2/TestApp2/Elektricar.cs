using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp2
{
    public partial class Elektricar
    {
        public Elektricar()
        {
            Ocitavanjes = new HashSet<Ocitavanje>();
        }

        public int Jmbg { get; set; }

        public virtual Radnik JmbgNavigation { get; set; }
        public virtual ICollection<Ocitavanje> Ocitavanjes { get; set; }
    }
}
