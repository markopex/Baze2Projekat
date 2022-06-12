using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class Radnik
    {
        public Radnik()
        {
            Odsustvos = new HashSet<Odsustvo>();
        }

        public int Jmbg { get; set; }
        public DateTime DatumRodj { get; set; }
        public string Ime { get; set; }
        public int Plata { get; set; }
        public string RadnoMesto { get; set; }

        public virtual Elektricar Elektricar { get; set; }
        public virtual ICollection<Odsustvo> Odsustvos { get; set; }
    }
}
