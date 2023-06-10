using DataGrid.Models;
using DataGrid.ViewModels.OrderViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DataGrid.Views.Orders
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Modify : UserControl
    {
        public ApiHelper<OrderDetail> apiHelper = new ApiHelper<OrderDetail>();

        public OrderDetail order;
        public Modify()
        {
            InitializeComponent();

        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var status = ((TextBlock)cbStatus.SelectedItem).Tag.ToString();
                order.Order.Status = Int32.Parse(status);
                ApiHelper<Order> apiOrder = new ApiHelper<Order>();
                bool isupdate = await apiOrder.putMethod(StringUtil.StringUtil.HOST + "/api/orders/" + order.Order.Id, order.Order);
                if (isupdate)
                {
                    bool? Result = new MessageBoxCustom("Update Success", MessageType.Success, MessageButtons.Ok).ShowDialog();
                    var viewModel = (Update)DataContext;
                    if (viewModel.NavigateViewCommand.CanExecute(null))
                        viewModel.NavigateViewCommand.Execute(null);
                }
                else
                {
                    bool? Result = new MessageBoxCustom("Update Fail", MessageType.Warning, MessageButtons.Warning).ShowDialog();
                }
            }
            catch (Exception ex)
            {
                bool? Result = new MessageBoxCustom(ex.Message, MessageType.Warning, MessageButtons.Warning).ShowDialog();
            }
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var viewModel = (Update)DataContext;
                idItem.Text = viewModel.id;

                order = await apiHelper.getMethod(StringUtil.StringUtil.HOST + "/api/orderdetails/" + viewModel.id);
                tblCustomer.Text = order.Order.Name;
                tblProduct.Text = order.Product.Name;
                tlbPrice.Text = order.Product.Price.ToString();
                TblDetail.Text = order.Product.Detail;
                tblPhone.Text = order.Order.Phone;
                tblTotal.Text = order.Price.ToString();
                tblQty.Text = order.Qty.ToString() ;
                tblAmout.Text = order.Amount.ToString() ;
                cbStatus.SelectedIndex = order.Order.Status;
            }
            catch (Exception ex)
            {
                bool? Result = new MessageBoxCustom(ex.Message, MessageType.Warning, MessageButtons.Warning).ShowDialog();
            }
        }
    }
}
