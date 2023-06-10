using DataGrid.Models;
using DataGrid.Store;
using DataGrid.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DataGrid
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            if (tbName.Text == "")
            {
                bool? Result = new MessageBoxCustom("Username Cannot Empty", MessageType.Warning, MessageButtons.Warning).ShowDialog();
                return;
            }
            if (tbPassword.Password == "")
            {
                bool? Result = new MessageBoxCustom("PassWord Cannot Empty", MessageType.Warning, MessageButtons.Warning).ShowDialog();
                return;
            }
            try
            {

            ApiHelper<User> apiHelper = new ApiHelper<User>();
            Account acccount = new Account();
            acccount.Username = tbName.Text;
            acccount.Password = tbPassword.Password;
            User user = await apiHelper.postMethod(StringUtil.StringUtil.HOST + "/api/users/login", acccount);
            if (user != null)
            {
                NavigationStore navigationStore = new NavigationStore();

                navigationStore.CurrentViewModel = new ViewTwoModels(navigationStore);
                MainWindow main = new MainWindow()
                {
                    DataContext = new MainViewModel(navigationStore)
                };
                main.Show();
                this.Close();
            }
            else
            {
                bool? Result = new MessageBoxCustom("Username or Password not correct !", MessageType.Warning, MessageButtons.Warning).ShowDialog();
            }
            }
            catch (Exception ex)
            {
                bool? Result = new MessageBoxCustom("Username or Password not correct !", MessageType.Warning, MessageButtons.Warning).ShowDialog();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    
}
