using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp2
{
    public class StatistikaPotrosaca
    {
        public int Pot_Id { get; set; }
        public string Naziv { get; set; }
        public int BrojStrujomera { get; set; }
        public decimal Ukupno { get; set; }
    }
}
