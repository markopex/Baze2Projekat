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
        private CollectionViewSource zaduzenjeViewSource;
        private CollectionViewSource kvaroviViewSource;


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
            zaduzenjeViewSource = (CollectionViewSource)FindResource(nameof(zaduzenjeViewSource));
            kvaroviViewSource = (CollectionViewSource)FindResource(nameof(kvaroviViewSource));

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
                        Naziv = "Glupi"
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

            //dbContext.Zaduzujes.Load();
            //zaduzenjeViewSource.Source = dbContext.Zaduzujes.Local.ToObservableCollection();

            dbContext.Kvars.Load();
            kvaroviViewSource.Source = dbContext.Kvars.Local.ToObservableCollection();

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
    }
}
