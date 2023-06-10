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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataGrid.Models;
using DataGrid.ViewModels.ProductViewModel;

namespace DataGrid.Views.Orders
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : UserControl
    {
        public Create()
        {
            InitializeComponent();

        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text == ""
                || tbMetadesc.Text == ""
                || tbMetakey.Text == ""
                || tbNumber.Text == ""
                || tbPrice.Text == ""
                || tbPricesale.Text == ""
                || tbSlug.Text == ""
                || tbDetail.Text == "")
            {
                bool? Result = new MessageBoxCustom("Kiểm tra lại các trường nhập", MessageType.Warning, MessageButtons.Warning).ShowDialog();
                return;
            }
            try
            {
                Category category = (Category)cbCategories.SelectedItem;
                Product product = new Product();

                product.CategoryId = category.Id;
                product.Name = tbName.Text;
                product.Metadesc = tbMetadesc.Text;
                product.Metakey = tbMetakey.Text;
                product.Number = Int32.Parse(tbNumber.Text);
                product.Price = Double.Parse(tbPrice.Text);
                product.Pricesale = Double.Parse(tbPricesale.Text);
                product.Slug = tbSlug.Text;
                var status = ((TextBlock)cbStatus.SelectedItem).Tag.ToString();
                product.Status = Int32.Parse(status);
                product.Detail = tbDetail.Text;
                product.Created_At = DateTime.Now;
                product.Updated_At = DateTime.Now;
                ApiHelper<Product> apiHelper = new ApiHelper<Product>();
                Product product2 = await apiHelper.postMethod(StringUtil.StringUtil.HOST + "/api/products/", product);
                if (product2 != null)
                {
                    bool? Result = new MessageBoxCustom("Add Success", MessageType.Success, MessageButtons.Ok).ShowDialog();
                    var viewModel = (AddProductModels)DataContext;
                    if (viewModel.CommandProductIndex.CanExecute(null))
                        viewModel.CommandProductIndex.Execute(null);
                }
                else
                {
                    bool? Result = new MessageBoxCustom("Add Fail", MessageType.Warning, MessageButtons.Warning).ShowDialog();
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
                ApiHelper<List<Category>> apiCategory = new ApiHelper<List<Category>>();
                List<Category> listCategories = await apiCategory.getMethod("http://localhost:5000/api/categories");
                cbCategories.ItemsSource = listCategories;
                cbCategories.SelectedIndex = 0;
                cbCategories.SelectionChanged += CbCategories_SelectionChanged;

            }
            catch (Exception ex)
            {
                bool? Result = new MessageBoxCustom(ex.Message, MessageType.Warning, MessageButtons.Warning).ShowDialog();
            }

        }

        private void CbCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Category category = (Category)cbCategories.SelectedItem;

            //MessageBox.Show(category.Id.ToString());
        }
    }
}
