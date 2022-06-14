using Microsoft.EntityFrameworkCore;
using System;

namespace TestApp2
{
    internal class Program
    {
        //private static masterContext dbContext = new masterContext();
        private static int GetStats(int potrosacId)
        {
            //return dbContext.Database.ExecuteSqlRaw($"select * from [dbo].[StatistikaPotrosaca]({potrosacId})");
            return 0;
        }
        static void Main(string[] args)
        {
            //var retVAl = GetStats(1);
            //Console.WriteLine(dbContext.StatistikaPotrosaca(1).FirstAsync().Result);
            /*
            var radnik1 = new Radnik()
            {
                Jmbg = 1,
                Ime = "Nikola",
                Plata = 11230,
                DatumRodj = DateTime.Now,
                RadnoMesto = "Elektricar"
            };
            var elektricar1 = new Elektricar()
            {
                Jmbg = radnik1.Jmbg,
            };
            var radnik2 = new Radnik()
            {
                Jmbg = 2,
                Ime = "Nemanja",
                Plata = 24212,
                DatumRodj = DateTime.Now,
                RadnoMesto = "Elektricar"
            };
            var elektricar2 = new Elektricar()
            {
                Jmbg = radnik2.Jmbg,
            };
            var radnik3 = new Radnik()
            {
                Jmbg = 3,
                Ime = "Bogdan",
                Plata = 11230,
                DatumRodj = DateTime.Now,
                RadnoMesto = "Elektricar"
            };
            var elektricar3 = new Elektricar()
            {
                Jmbg = radnik3.Jmbg,
            };
            var radnik4 = new Radnik()
            {
                Jmbg = 4,
                Ime = "Jordan",
                Plata = 34543,
                DatumRodj = DateTime.Now,
                RadnoMesto = "Elektricar"
            };
            var elektricar4 = new Elektricar()
            {
                Jmbg = radnik4.Jmbg,
            };
            var radnik5 = new Radnik()
            {
                Jmbg = 5,
                Ime = "Nikola",
                Plata = 12321,
                DatumRodj = DateTime.Now,
                RadnoMesto = "Elektricar"
            };
            var elektricar5 = new Elektricar()
            {
                Jmbg = radnik5.Jmbg,
            };

            var radnik6 = new Radnik()
            {
                Jmbg = 23423426,
                Ime = "Radisa",
                Plata = 12321,
                DatumRodj = DateTime.Now,
                RadnoMesto = "Magacioner"
            };
            var radnik7 = new Radnik()
            {
                Jmbg = 342342364,
                Ime = "Vasilije",
                Plata = 23423,
                DatumRodj = DateTime.Now,
                RadnoMesto = "Vozac"
            };
            var radnik8 = new Radnik()
            {
                Jmbg = 3454,
                Ime = "Marko",
                Plata = 32432,
                DatumRodj = DateTime.Now,
                RadnoMesto = "Direktor"
            };
            var radnik9 = new Radnik()
            {
                Jmbg = 345,
                Ime = "Milica",
                Plata = 23342,
                DatumRodj = DateTime.Now,
                RadnoMesto = "Sekretarica"
            };

            //dbContext.Radniks.Add(radnik1);
            //dbContext.Elektricars.Add(elektricar);
            dbContext.Radniks.Add(radnik1);
            dbContext.Elektricars.Add(elektricar1);
            dbContext.Radniks.Add(radnik2);
            dbContext.Elektricars.Add(elektricar2);
            dbContext.Radniks.Add(radnik3);
            dbContext.Elektricars.Add(elektricar3);
            dbContext.Radniks.Add(radnik4);
            dbContext.Elektricars.Add(elektricar4);
            dbContext.Radniks.Add(radnik5);
            dbContext.Elektricars.Add(elektricar5);
            dbContext.Radniks.Add(radnik6);
            dbContext.Radniks.Add(radnik7);
            dbContext.Radniks.Add(radnik8);
            dbContext.Radniks.Add(radnik9);


            var potrosac1 = new Potrosac()
            {
                PotId = 1,
                Naziv = "Magrrko",
                Sifra = "marko1111"
            };
            var potrosac2 = new Potrosac()
            {
                PotId = 2,
                Naziv = "Nesfikola",
                Sifra = "nikola22222"
            };
            var potrosac3 = new Potrosac()
            {
                PotId = 3,
                Naziv = "Nenfesad",
                Sifra = "nenad3333"
            };
            var potrosac4 = new Potrosac()
            {
                PotId = 4,
                Naziv = "JKP Sfestandard",
                Sifra = "standard"
            };
            var potrosac5 = new Potrosac()
            {
                PotId = 5,
                Naziv = "TC Merfsefkator",
                Sifra = "tc1234567"
            };
            dbContext.Potrosacs.Add(potrosac1);
            dbContext.Potrosacs.Add(potrosac2);
            dbContext.Potrosacs.Add(potrosac3);
            dbContext.Potrosacs.Add(potrosac4);
            dbContext.Potrosacs.Add(potrosac5);

            dbContext.SaveChanges();

            var strujomer1 = new Strujomer()
            {
                Broj = 1,
                Potrosac = 1,
                Snaga = 20,
                Tip = 0,
                TrKwh = 12,
                UkupnoKwh = 0
            };
            var strujomer2= new Strujomer()
            {
                Broj = 1231,
                Potrosac = 1,
                Snaga = 20,
                Tip = 0,
                TrKwh = 12,
                UkupnoKwh = 0
            };
            var strujomer3 = new Strujomer()
            {
                Broj = 1423,
                Potrosac = 1,
                Snaga = 20,
                Tip = 0,
                TrKwh = 12,
                UkupnoKwh = 0
            };
            var strujomer4 = new Strujomer()
            {
                Broj = 1234,
                Potrosac = 2,
                Snaga = 20,
                Tip = 0,
                TrKwh = 12,
                UkupnoKwh = 1200
            };
            var strujomer5 = new Strujomer()
            {
                Broj = 122,
                Potrosac = 3,
                Snaga = 15,
                Tip = 1,
                UkupnoKwh = 22222
            };
            var strujomer6 = new Strujomer()
            {
                Broj = 123123,
                Potrosac = 5,
                Snaga = 10,
                Tip = 1,
                UkupnoKwh = 2312
            };

            dbContext.Add(strujomer1);
            dbContext.Add(strujomer2);
            dbContext.Add(strujomer3);
            dbContext.Add(strujomer4);
            dbContext.Add(strujomer5);
            dbContext.Add(strujomer6);

            var oprema1 = new Oprema()
            {
                OprId = 1,
                Naziv = "Kljuc 12",
                Opis = "",
            };
            var oprema2 = new Oprema()
            {
                OprId = 2,
                Naziv = "Lada niva",
                Opis = "",
            };
            var oprema3 = new Oprema()
            {
                OprId = 3,
                Naziv = "Kombinezon",
                Opis = "",
            };
            var oprema4 = new Oprema()
            {
                OprId = 4,
                Naziv = "Radni prsluk",
                Opis = "",
            };
            var oprema5 = new Oprema()
            {
                OprId = 5,
                Naziv = "Kljesta",
                Opis = "",
            };

            dbContext.Opremas.Add(oprema1);
            dbContext.Opremas.Add(oprema2);
            dbContext.Opremas.Add(oprema3);
            dbContext.Opremas.Add(oprema4);
            dbContext.Opremas.Add(oprema5);



            dbContext.SaveChanges();*/
        }
    }
}
