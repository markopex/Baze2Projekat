using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
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

namespace WorkerApp.Views
{
    /// <summary>
    /// Interaction logic for ElectricianDashboardControl.xaml
    /// </summary>
    public partial class ElectricianDashboardControl : UserControl
    {
        private CollectionViewSource consumerViewSource;
        private CollectionViewSource metersViewSource;
        public ElectricianDashboardControl()
        {
            InitializeComponent();
            consumerViewSource = (CollectionViewSource)FindResource(nameof(consumerViewSource));
            metersViewSource = (CollectionViewSource)FindResource(nameof(metersViewSource));

            LoadData();
        }

        public void LoadData()
        {
            MainWindow.ConsumerDbContext.Consumers.Load();
            MainWindow.ConsumerDbContext.Meters.Load();
            consumerViewSource.Source = MainWindow.ConsumerDbContext.Consumers.Local.ToObservableCollection();
            metersViewSource.Source = MainWindow.ConsumerDbContext.Meters.Local.ToObservableCollection();
            //metersViewSource.Filter += new FilterEventHandler(MyMeterFilter);
        }

        #region Filters
        private void MyMeterFilter(object sender, FilterEventArgs e)
        {
            var meter = e.Item as Meter;
            if (meter != null)
            {
                if(cmbBoxTypeFilter.SelectedIndex >= 0)
                {
                    // Filter out products with price 25 or above
                    var selectedType = (cmbBoxTypeFilter.SelectedIndex == 1) ? MeterType.SMART : MeterType.ANALOG;
                    if (meter.Type == selectedType)
                    {
                        e.Accepted = true;
                    }
                    else
                    {
                        e.Accepted = false;
                    }
                }
            }
        }
        #endregion

        private void BtnAddConsumer_Click(object sender, RoutedEventArgs e)
        {
            if (TxtBoxName.Text.Length > 0 && TxtBoxPassword.Text.Length > 0)
            {
                var newConsumer = new Consumer()
                {
                    Name = TxtBoxName.Text,
                    Password = TxtBoxPassword.Text,
                };
                MainWindow.ConsumerDbContext.Consumers.Add(newConsumer);
                MainWindow.ConsumerDbContext.SaveChanges();
            }
        }

        private void cmbBoxTypeFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(metersViewSource != null)
                metersViewSource.Source = MainWindow.ConsumerDbContext.Meters.Local.ToObservableCollection();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.ConsumerDbContext.SaveChanges();
        }
    }
}
