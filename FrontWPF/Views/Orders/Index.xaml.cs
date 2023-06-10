using DataGrid.Models;
using DataGrid.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DataGrid.ViewModels.OrderViewModel;

namespace DataGrid.Views.Orders
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : UserControl
    {
        public List<OrderDetail> orderdetails;



        public Index()
        {
            InitializeComponent();
        }

        public async Task displayData()
        {
            ApiHelper<List<OrderDetail>> apiHelper = new ApiHelper<List<OrderDetail>>();
            orderdetails = await apiHelper.getMethod(StringUtil.StringUtil.HOST + "/api/orderdetails");
            productsDataGrid.ItemsSource = orderdetails;
        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await displayData();
            }
            catch (Exception ex)
            {
                bool? Result = new MessageBoxCustom(ex.Message, MessageType.Warning, MessageButtons.Warning).ShowDialog();
            }
        }

       
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string id = ((Button)sender).Tag.ToString();
                var viewModel = (View)DataContext;
                viewModel.id  = id;
                if (viewModel.NavigateUpdateCommand.CanExecute(id))
                    viewModel.NavigateUpdateCommand.Execute(id);
            }
            catch (Exception ex)
            {
                bool? Result = new MessageBoxCustom(ex.Message, MessageType.Warning, MessageButtons.Warning).ShowDialog();
            }
        }

    }
}
