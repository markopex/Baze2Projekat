using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp2
{
    public class TipStrujomera
    {
        public int Tip { get; set; }
        public string Naziv { get; set; }
    }

    public enum ETipStujomera
    {
        SMART,
        ANALOG
    }
}
