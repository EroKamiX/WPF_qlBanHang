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
using DataGrid.ViewModels.TopicViewModel;

namespace DataGrid.Views.Users
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

                Topic topic = new Topic();
                topic.Name = tbName.Text;
                topic.Slug = tbSlug.Text;
                topic.Metadesc = tbMetadesc.Text;
                topic.Metakey = tbMetakey.Text;
                topic.ParentId = Int32.Parse(tbParentId.Text);
                topic.Created_At = DateTime.Now;
                topic.Updated_At = DateTime.Now;
                var status = ((TextBlock)cbStatus.SelectedItem).Tag.ToString();
                topic.Status = Int32.Parse(status);
                ApiHelper<Topic> apiHelper = new ApiHelper<Topic>();
                Topic topics = await apiHelper.postMethod(StringUtil.StringUtil.HOST + "/api/topics/",topic);
                if(topics != null)
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
    }
}
