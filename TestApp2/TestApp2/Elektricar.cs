using System;
using System.Collections.Generic;

#nullable disable

namespace TestApp2
{
    public partial class Elektricar
    {
        public Elektricar()
        {
            Kvars = new HashSet<Kvar>();
            Ocitavanjes = new HashSet<Ocitavanje>();
        }

        public int Jmbg { get; set; }

        public virtual Radnik JmbgNavigation { get; set; }
        public virtual ICollection<Kvar> Kvars { get; set; }
        public virtual ICollection<Ocitavanje> Ocitavanjes { get; set; }
    }
}
