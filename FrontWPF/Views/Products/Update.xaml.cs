using DataGrid.Models;
using DataGrid.ViewModels.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DataGrid.Views.Products
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Update : UserControl
    {
        public ApiHelper<Product> apiHelper = new ApiHelper<Product>();

        public Product product;
        public Update()
        {
            InitializeComponent();

        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbName.Text == "")
                {
                    bool? Result = new MessageBoxCustom("Kiểm tra lại các trường nhập", MessageType.Warning, MessageButtons.Warning).ShowDialog();
                    return;
                }
                if (tbMetadesc.Text == "")
                {
                    bool? Result = new MessageBoxCustom("Kiểm tra lại các trường nhập", MessageType.Warning, MessageButtons.Warning).ShowDialog();
                    return;
                }
                if (tbMetakey.Text == "")
                {
                    bool? Result = new MessageBoxCustom("Kiểm tra lại các trường nhập", MessageType.Warning, MessageButtons.Warning).ShowDialog();
                    return;
                }
                if (tbSlug.Text == "")
                {
                    bool? Result = new MessageBoxCustom("Kiểm tra lại các trường nhập", MessageType.Warning, MessageButtons.Warning).ShowDialog();
                    return;
                }
                Category category = (Category)cbCategories.SelectedItem;
                product.CategoryId = category.Id;
                product.Name = tbName.Text;
                product.Metadesc = tbMetadesc.Text;
                product.Metakey = tbMetakey.Text;
                var status = ((TextBlock)cbStatus.SelectedItem).Tag.ToString();
                product.Status = Int32.Parse(status);
                product.Number = Int32.Parse(tbNumber.Text);
                product.Price = Double.Parse(tbPrice.Text);
                product.Pricesale = Double.Parse(tbPricesale.Text);
                product.Slug = tbSlug.Text;
                product.Detail = tbDetail.Text;
                product.Updated_At = DateTime.Now;
                bool isupdate = await apiHelper.putMethod(StringUtil.StringUtil.HOST + "/api/products/" + product.Id, product);
                if (isupdate)
                {
                    bool? Result = new MessageBoxCustom("Update Success", MessageType.Success, MessageButtons.Ok).ShowDialog();
                    var viewModel = (UpdateProductModels)DataContext;
                    if (viewModel.NavigateProductsCommand.CanExecute(null))
                        viewModel.NavigateProductsCommand.Execute(null);
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
                ApiHelper<List<Category>> apiCategory = new ApiHelper<List<Category>>();
                List<Category> listCategories = await apiCategory.getMethod("http://localhost:5000/api/categories");
                cbCategories.ItemsSource = listCategories;
                
                var viewModel = (UpdateProductModels)DataContext;
                idItem.Text = viewModel.IdProduct;
                
                product = await apiHelper.getMethod(StringUtil.StringUtil.HOST + "/api/products/" + idItem.Text);
                foreach(Category category in listCategories)
                {
                    if(category.Id == product.CategoryId)
                    {
                        cbCategories.SelectedItem = category;
                        break;
                    }
                }
                cbStatus.SelectedIndex =product.Status;
                tbName.Text = product.Name;
                tbMetadesc.Text = product.Metadesc;
                tbMetakey.Text = product.Metakey;
                tbNumber.Text = product.Number.ToString();
                tbPrice.Text = product.Price.ToString();
                tbPricesale.Text = product.Pricesale.ToString();
                tbSlug.Text = product.Slug;
                tbDetail.Text = product.Detail;
            }
            catch (Exception ex)
            {
                bool? Result = new MessageBoxCustom(ex.Message, MessageType.Warning, MessageButtons.Warning).ShowDialog();
            }
        }
    }
}
