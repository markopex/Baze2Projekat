using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestApp2;

namespace RadnikApp.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        private CollectionViewSource potrosaciViewSource;
        private CollectionViewSource strujomeriViewSource;
        private CollectionViewSource tipoviStrujomeraViewSource;
        private CollectionViewSource radniciViewSource;
        private CollectionViewSource odsustvaViewSource;
        private CollectionViewSource opremaViewSource;
        private CollectionViewSource kvaroviViewSource;
        private CollectionViewSource ocitavanjaViewSource;
        private CollectionViewSource racuniViewSource;
        private StatistikaPotrosaca StatistikaPotrosaca { get; set; }


        private masterContext dbContext;
        public Dashboard(masterContext context)
        {
            InitializeComponent();
            dbContext = context;
            potrosaciViewSource = (CollectionViewSource)FindResource(nameof(potrosaciViewSource));
            strujomeriViewSource = (CollectionViewSource)FindResource(nameof(strujomeriViewSource));
            tipoviStrujomeraViewSource = (CollectionViewSource)FindResource(nameof(tipoviStrujomeraViewSource));
            radniciViewSource = (CollectionViewSource)FindResource(nameof(radniciViewSource));
            odsustvaViewSource = (CollectionViewSource)FindResource(nameof(odsustvaViewSource));
            opremaViewSource = (CollectionViewSource)FindResource(nameof(opremaViewSource));
            kvaroviViewSource = (CollectionViewSource)FindResource(nameof(kvaroviViewSource));
            ocitavanjaViewSource = (CollectionViewSource)FindResource(nameof(ocitavanjaViewSource));
            racuniViewSource = (CollectionViewSource)FindResource(nameof(racuniViewSource));

            LoadData();
        }

        private void LoadData()
        {
            dbContext.Potrosacs.Load();
            potrosaciViewSource.Source = dbContext.Potrosacs.Local.ToObservableCollection();

            tipoviStrujomeraViewSource.Source = new ObservableCollection<TipStrujomera>(
                new List<TipStrujomera>()
                {
                    new TipStrujomera()
                    {
                        Tip = (int)ETipStujomera.SMART,
                        Naziv = "Pametni"
                    },
                    new TipStrujomera()
                    {
                        Tip = (int)ETipStujomera.ANALOG,
                        Naziv = "Analogni"
                    }
                });

            dbContext.Strujomers.Load();
            strujomeriViewSource.Source = dbContext.Strujomers.Local.ToObservableCollection();

            dbContext.Radniks.Load();
            radniciViewSource.Source = dbContext.Radniks.Local.ToObservableCollection();

            dbContext.Odsustvos.Load();
            odsustvaViewSource.Source = dbContext.Odsustvos.Local.ToObservableCollection();

            dbContext.Opremas.Load();
            opremaViewSource.Source = dbContext.Opremas.Local.ToObservableCollection();

            dbContext.Kvars.Load();
            kvaroviViewSource.Source = dbContext.Kvars.Local.ToObservableCollection();

            dbContext.Ocitavanjes.Load();
            ocitavanjaViewSource.Source = dbContext.Ocitavanjes.Local.ToObservableCollection();

            dbContext.Racuns.Load();
            racuniViewSource.Source = dbContext.Racuns.Local.ToObservableCollection();

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            dbContext = new masterContext();
            LoadData();
        }

        private StatistikaPotrosaca GetStats(int potrosacId)
        {
            return dbContext.StatistikaPotrosaca(potrosacId).FirstAsync().Result;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dbContext.SaveChanges();
                RefreshData();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbBoxStatistikaPotrosaca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbBoxStatistikaPotrosaca.SelectedValue != null)
            {
                try
                {
                    var stats = dbContext.StatistikaPotrosaca((cmbBoxStatistikaPotrosaca.SelectedItem as Potrosac).PotId).FirstAsync().Result;
                    lblPot_Id.Content = stats.Pot_Id;
                    lblBrojStrujomera.Content = stats.BrojStrujomera;
                    lblNazivPotrosaca.Content = stats.Naziv;
                    lblUkupnaPotrosnja.Content = stats.Ukupno;
                }catch(Exception ex)
                {
                    lblPot_Id.Content = String.Empty;
                    lblBrojStrujomera.Content = String.Empty;
                    lblNazivPotrosaca.Content = String.Empty;
                    lblUkupnaPotrosnja.Content = String.Empty;
                }
                
            }

        }

        private void btnGenerisiOcitavanja_Click(object sender, RoutedEventArgs e)
        {
            var datum = DateTime.Now;
            Random rnd = new Random();
            try
            {
                datum = new DateTime(int.Parse(txtBlockGodina.Text), int.Parse(txtBlockMesec.Text), 1);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            var strujomeri = dbContext.Strujomers.ToList();
            foreach (var strujomer in strujomeri)
            {

                var ocitavanje = new Ocitavanje()
                {
                    Strujomer = strujomer.Broj,
                    Datum = datum,
                    Period = datum.Year * 100 + datum.Month,
                    Kwh = strujomer.UkupnoKwh + (decimal)(rnd.NextDouble() * 400 + 100)
                };
                // ako je strujomer analogni
                if(strujomer.Tip == 1)
                {
                    ocitavanje.Elektricar = dbContext.Elektricars.First().Jmbg;
                }
                dbContext.Ocitavanjes.Add(ocitavanje);
            }
            dbContext.SaveChanges();
            RefreshData();
        }

        private void GenerisiRacune(int period)
        {
            dbContext.Database.ExecuteSqlRaw($"DECLARE @RC int; EXECUTE @RC = [dbo].[GenerisiRacune] @Period={period}");
            RefreshData();
        }

        private void btnGenerisiRacune_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var period = int.Parse(txtBlGodina.Text) * 100 + int.Parse(txtBlMesec.Text);
                GenerisiRacune(period);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
