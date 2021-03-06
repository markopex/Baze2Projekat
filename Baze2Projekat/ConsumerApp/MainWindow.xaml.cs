using Models.Infrastructure;
using ConsumerApp.Views;
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
using Models;

namespace ConsumerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ConsumerDbContext ConsumerDbContext { set; get; } = new ConsumerDbContext();
        public static Consumer Consumer { set; get; } = null;
        public MainWindow()
        {
            InitializeComponent();
            this.MainGrid.Children.Clear();
            var login = new Login(OnSuccessfullLoggedIn);
            this.MainGrid.Children.Add(login);
        }

        public bool OnSuccessfullLoggedIn()
        {
            this.MainGrid.Children.Clear();
            this.MainGrid.Children.Add(new ConsumerDashboardControl());
            return true;
        }
    }
}
