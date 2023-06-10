using DataGrid.Store;
using DataGrid.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DataGrid
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            //MainWindow = new MainWindow()
            //{
            //    DataContext = new MainViewModel(navigationStore)
            //};
            MainWindow = new Login();
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
