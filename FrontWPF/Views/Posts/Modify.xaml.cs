using DataGrid.Models;
using DataGrid.ViewModels.PostViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DataGrid.Views.Posts
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Modify : UserControl
    {
        public ApiHelper<Post> apiHelper = new ApiHelper<Post>();

        public Post post;
        public Modify()
        {
            InitializeComponent();

        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbTitle.Text == "")
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
                Topic topic = (Topic)cbTopics.SelectedItem;
                post.TopicId = topic.Id;
                post.Title = tbTitle.Text;
                post.Metadesc = tbMetadesc.Text;
                post.Metakey = tbMetakey.Text;
                var status = ((TextBlock)cbStatus.SelectedItem).Tag.ToString();
                post.Status = Int32.Parse(status);
                post.Slug = tbSlug.Text;
                post.Detail = tbDetail.Text;
                post.Updated_At = DateTime.Now;
                bool isupdate = await apiHelper.putMethod(StringUtil.StringUtil.HOST + "/api/posts/" + post.Id, post);
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
                ApiHelper<List<Topic>> apiTopic = new ApiHelper<List<Topic>>();
                List<Topic> listTopics = await apiTopic.getMethod("http://localhost:5000/api/topics");
                cbTopics.ItemsSource = listTopics;
                
                var viewModel = (Update)DataContext;
                idItem.Text = viewModel.id;
                
                post = await apiHelper.getMethod(StringUtil.StringUtil.HOST + "/api/posts/" + idItem.Text);
                foreach(Topic topic in listTopics)
                {
                    if(topic.Id == post.TopicId)
                    {
                        cbTopics.SelectedItem = topic;
                        break;
                    }
                }
                cbStatus.SelectedIndex =post.Status;
                tbTitle.Text = post.Title;
                tbMetadesc.Text = post.Metadesc;
                tbMetakey.Text = post.Metakey;
                tbSlug.Text = post.Slug;
                tbDetail.Text = post.Detail;
            }
            catch (Exception ex)
            {
                bool? Result = new MessageBoxCustom(ex.Message, MessageType.Warning, MessageButtons.Warning).ShowDialog();
            }
        }
    }
}
