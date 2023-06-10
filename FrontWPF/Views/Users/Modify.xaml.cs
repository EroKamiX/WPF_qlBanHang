using System;
using System.Windows;
using System.Windows.Controls;
using DataGrid.Models;
using DataGrid.ViewModels.TopicViewModel;

namespace DataGrid.Views.Users
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Modify : UserControl
    {
        public ApiHelper<Topic> apiHelper = new ApiHelper<Topic>();

        public Topic topic;
        public Modify()
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
                if (tbParentId.Text == "")
                {
                    bool? Result = new MessageBoxCustom("Kiểm tra lại các trường nhập", MessageType.Warning, MessageButtons.Warning).ShowDialog();
                    return;
                }
                if (tbSlug.Text == "")
                {
                    bool? Result = new MessageBoxCustom("Kiểm tra lại các trường nhập", MessageType.Warning, MessageButtons.Warning).ShowDialog();
                    return;
                }

                topic.Name = tbName.Text;
                topic.Slug = tbSlug.Text;
                topic.Metadesc = tbMetadesc.Text;
                topic.Metakey = tbMetakey.Text;
                topic.ParentId = Int32.Parse(tbParentId.Text);
                topic.Updated_At = DateTime.Now;

                var status = ((TextBlock)cbStatus.SelectedItem).Tag.ToString();
                topic.Status = Int32.Parse(status);
                bool isupdate = await apiHelper.putMethod(StringUtil.StringUtil.HOST + "/api/topics/"+ topic.Id, topic);
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
                idTopic.Text = viewModel.id;
                
                topic = await apiHelper.getMethod(StringUtil.StringUtil.HOST + "/api/topics/" + idTopic.Text);
                tbName.Text = topic.Name;
                tbSlug.Text = topic.Slug;
                tbMetadesc.Text = topic.Metadesc;
                tbMetakey.Text = topic.Metakey;
                tbParentId.Text = topic.ParentId.ToString();
                tbCreatedAt.Text = topic.Created_At.ToString();

            }
            catch (Exception ex)
            {
                bool? Result = new MessageBoxCustom(ex.Message, MessageType.Warning, MessageButtons.Warning).ShowDialog();
            }
        }
    }
}
