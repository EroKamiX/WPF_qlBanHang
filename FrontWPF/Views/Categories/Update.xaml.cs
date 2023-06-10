using DataGrid.Models;
using DataGrid.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DataGrid.Views.Categories
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Update : UserControl
    {
        public ApiHelper<Category> apiHelper = new ApiHelper<Category>();

        public Category category;
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

                category.Name = tbName.Text;
                category.Slug = tbSlug.Text;
                category.Metadesc = tbMetadesc.Text;
                category.Metakey = tbMetakey.Text;
                category.ParentId = Int32.Parse(tbParentId.Text);
                category.Updated_At = DateTime.Now;
                var status = ((TextBlock)cbStatus.SelectedItem).Tag.ToString();
                category.Status = Int32.Parse(status);
                bool isupdate = await apiHelper.putMethod(StringUtil.StringUtil.HOST + "/api/categories/"+category.Id, category);
                if (isupdate)
                {
                    bool? Result = new MessageBoxCustom("Update Success", MessageType.Success, MessageButtons.Ok).ShowDialog();
                    var viewModel = (UpdateCategoryModels)DataContext;
                    if (viewModel.CommandCategoryIndex.CanExecute(null))
                        viewModel.CommandCategoryIndex.Execute(null);
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
                var viewModel = (UpdateCategoryModels)DataContext;
                idCategory.Text = viewModel.IdCategory;
                
                category = await apiHelper.getMethod(StringUtil.StringUtil.HOST + "/api/categories/" + idCategory.Text);
                cbStatus.SelectedIndex = category.Status;
                tbName.Text = category.Name;
                tbSlug.Text = category.Slug;
                tbMetadesc.Text = category.Metadesc;
                tbMetakey.Text = category.Metakey;
                tbParentId.Text = category.ParentId.ToString();
                tbCreatedAt.Text = category.Created_At.ToString();

            }
            catch (Exception ex)
            {
                bool? Result = new MessageBoxCustom(ex.Message, MessageType.Warning, MessageButtons.Warning).ShowDialog();
            }
        }
    }
}
