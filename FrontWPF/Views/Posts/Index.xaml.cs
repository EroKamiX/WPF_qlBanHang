using DataGrid.Models;
using DataGrid.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DataGrid.ViewModels.PostViewModel;

namespace DataGrid.Views.Posts
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : UserControl
    {
        public List<Post> posts;
        public static string id;

        public Index()
        {
            InitializeComponent();
        }

        public async Task displayData()
        {

            ApiHelper<List<Post>> apiHelper = new ApiHelper<List<Post>>();
            posts = await apiHelper.getMethod(StringUtil.StringUtil.HOST + "/api/posts");
            postsDataGrid.ItemsSource = posts;
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
                    ApiHelper<Post> apiHelper = new ApiHelper<Post>();
                    Post post = await apiHelper.deleteMethod(StringUtil.StringUtil.HOST + "/api/posts/" + id);
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
