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
using DataGrid.ViewModels.PostViewModel;

namespace DataGrid.Views.Posts
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
            if (tbTitle.Text == ""
                || tbMetadesc.Text == ""
                || tbMetakey.Text == ""
                || tbSlug.Text == ""
                || tbDetail.Text == "")
            {
                bool? Result = new MessageBoxCustom("Kiểm tra lại các trường nhập", MessageType.Warning, MessageButtons.Warning).ShowDialog();
                return;
            }
            try
            {
                Topic topic = (Topic)cbTopics.SelectedItem;
                Post post = new Post();

                post.TopicId = topic.Id;
                post.Title = tbTitle.Text;
                post.Metadesc = tbMetadesc.Text;
                post.Metakey = tbMetakey.Text;
                post.Slug = tbSlug.Text;
                var status = ((TextBlock)cbStatus.SelectedItem).Tag.ToString();
                post.Status = Int32.Parse(status);
                post.Detail = tbDetail.Text;
                post.Created_At = DateTime.Now;
                post.Updated_At = DateTime.Now;
                ApiHelper<Post> apiHelper = new ApiHelper<Post>();
                Post post2 = await apiHelper.postMethod(StringUtil.StringUtil.HOST + "/api/posts/", post);
                if (post2 != null)
                {
                    bool? Result = new MessageBoxCustom("Add Success", MessageType.Success, MessageButtons.Ok).ShowDialog();
                    var viewModel = (Add)DataContext;
                    if (viewModel.NavigateViewCommand.CanExecute(null))
                        viewModel.NavigateViewCommand.Execute(null);
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
                ApiHelper<List<Topic>> apiTopic = new ApiHelper<List<Topic>>();
                List<Topic> listTopics = await apiTopic.getMethod("http://localhost:5000/api/topics");
                cbTopics.ItemsSource = listTopics;
                cbTopics.SelectedIndex = 0;
                cbTopics.SelectionChanged += CbCategories_SelectionChanged;

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
