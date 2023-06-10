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
using DataGrid.ViewModels;

namespace DataGrid.Views.Categories
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
                    bool? Result = new MessageBoxCustom("Không được để rỗng trường Name", MessageType.Warning, MessageButtons.Warning).ShowDialog();
                    return;
                }
                if (tbMetadesc.Text == "")
                {
                    bool? Result = new MessageBoxCustom("Không được để rỗng trường Name", MessageType.Warning, MessageButtons.Warning).ShowDialog();
                    return;
                }
                if (tbMetakey.Text == "")
                {
                    bool? Result = new MessageBoxCustom("Không được để rỗng trường Name", MessageType.Warning, MessageButtons.Warning).ShowDialog();
                    return;
                }
                if (tbParentId.Text == "")
                {
                    bool? Result = new MessageBoxCustom("Không được để rỗng trường Name", MessageType.Warning, MessageButtons.Warning).ShowDialog();
                    return;
                }
                if (tbSlug.Text == "")
                {
                    bool? Result = new MessageBoxCustom("Không được để rỗng trường Name", MessageType.Warning, MessageButtons.Warning).ShowDialog();
                    return;
                }

                Category category = new Category();
                category.Name = tbName.Text;
                category.Slug = tbSlug.Text;
                category.Metadesc = tbMetadesc.Text;
                category.Metakey = tbMetakey.Text;
                category.ParentId = Int32.Parse(tbParentId.Text);
                var status = ((TextBlock)cbStatus.SelectedItem).Tag.ToString();
                category.Status = Int32.Parse(status);
                category.Created_At = DateTime.Now;
                category.Updated_At = DateTime.Now;
                ApiHelper<Category> apiHelper = new ApiHelper<Category>();
                Category categories = await apiHelper.postMethod(StringUtil.StringUtil.HOST + "/api/categories/",category);
                if(categories != null)
                {
                    bool? Result = new MessageBoxCustom("Add Successed", MessageType.Success, MessageButtons.Ok).ShowDialog();
                    var viewModel = (AddCategoryModels)DataContext;
                    if (viewModel.CommandCategoryIndex.CanExecute(null))
                        viewModel.CommandCategoryIndex.Execute(null);
                }
                else
                {
                    bool? Result = new MessageBoxCustom("Add Faild", MessageType.Warning, MessageButtons.Warning).ShowDialog();
                }
            }
            catch (Exception ex)
            {
                bool? Result = new MessageBoxCustom(ex.Message, MessageType.Warning, MessageButtons.Warning).ShowDialog();
            }
        }
    }
}
