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

namespace ConsumerApp.Views
{
    /// <summary>
    /// Interaction logic for ConsumerDashboardControl.xaml
    /// </summary>
    public partial class ConsumerDashboardControl : UserControl
    {
        private CollectionViewSource equipmentViewSource;
        private CollectionViewSource borrowsEquipmentViewSource;
        private CollectionViewSource billsViewSource;
        private CollectionViewSource metersViewSource;
        public ConsumerDashboardControl()
        {
            InitializeComponent();
            equipmentViewSource = (CollectionViewSource)FindResource(nameof(equipmentViewSource));
            //borrowsEquipmentViewSource = (CollectionViewSource)FindResource(nameof(borrowsEquipmentViewSource));
            billsViewSource = (CollectionViewSource)(FindResource(nameof(billsViewSource)));
            metersViewSource = (CollectionViewSource)FindResource(nameof(metersViewSource));

            LoadData();
        }

        private void LoadData()
        {
            MainWindow.ConsumerDbContext.Equipment.Load();
            equipmentViewSource.Source = MainWindow.ConsumerDbContext.Equipment.Local.ToObservableCollection();
            //borrowsEquipmentViewSource.Source = MainWindow.ConsumerDbContext.BorrowsEquipments.Local.ToObservableCollection();
            billsViewSource.Source = MainWindow.ConsumerDbContext.Bills.Local.ToObservableCollection();
            metersViewSource.Source = MainWindow.ConsumerDbContext.Meters.Local.ToObservableCollection();
            metersViewSource.Filter += new FilterEventHandler(MyMeterFilter);
        }

        private void MyMeterFilter(object sender, FilterEventArgs e)
        {
            var meter = e.Item as Meter;
            if (meter != null)
            {
                // Filter out products with price 25 or above
                if (meter.Consumer.Id == MainWindow.Consumer.Id)
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
}
