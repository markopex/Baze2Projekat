using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        Func<bool> _onSuccessLogin;
        public Login(Func<bool> onSuccessfullLogin)
        {
            InitializeComponent();
            _onSuccessLogin = onSuccessfullLogin;
        }

        private void LoginConsumer(int id, string password)
        {
            var consumer = MainWindow.ConsumerDbContext.Consumers.Find(id);
            if(consumer == null)
            {
                throw new Exception("User doesn't exist.");
            }
            if(consumer.Password != password)
            {
                throw new Exception("Wrong consumer password.");
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
                _onSuccessLogin.Invoke();
            try
            {
                LoginConsumer(int.Parse(TxtBoxId.Text), TxtBoxPassword.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
