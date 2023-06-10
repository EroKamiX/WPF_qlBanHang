using DataGrid.Models;
using DataGrid.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DataGrid.Views.Categories
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : UserControl
    {
        public List<Category> categories;
        public static string id;

        public Index()
        {
            InitializeComponent();
        }

        public async Task displayData()
        {
            ApiHelper<List<Category>> apiHelper = new ApiHelper<List<Category>>();
            List<Category> categories = await apiHelper.getMethod("http://localhost:5000/api/categories");
            categoriesDataGrid.ItemsSource = categories;
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

        private async void Remove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool? Result = new MessageBoxCustom("Are u sure delete this?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
                if (Result == true)
                {
                    string id = ((Button)sender).Tag.ToString();
                    ApiHelper<Category> apiHelper = new ApiHelper<Category>();
                    Category categories = await apiHelper.deleteMethod(StringUtil.StringUtil.HOST + "/api/categories/" + id);
                    await displayData();
                }
                else
                {
                    // Do not close the window  
                }

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
                var viewModel = (CategoryModels)DataContext;
                viewModel.id  = id;
                if (viewModel.NavigateUpdateCategoryCommand.CanExecute(id))
                    viewModel.NavigateUpdateCategoryCommand.Execute(id);
            }
            catch (Exception ex)
            {
                bool? Result = new MessageBoxCustom(ex.Message, MessageType.Warning, MessageButtons.Warning).ShowDialog();
            }
        }

    }
}
