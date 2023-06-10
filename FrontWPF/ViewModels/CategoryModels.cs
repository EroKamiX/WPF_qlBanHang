using DataGrid.Commands;
using DataGrid.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DataGrid.ViewModels
{
    public class CategoryModels : ViewModelBase
    {
        private string _id;
        public string id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnChanged(nameof(id));
            }
        }
        public ICommand NavigateAddCategoryCommand { get; }
        public ICommand NavigateUpdateCategoryCommand { get; }
        public CategoryModels(NavigationStore navigationStore)
        {
            NavigateAddCategoryCommand = new NavigateCommand<AddCategoryModels>(navigationStore, () => new AddCategoryModels(navigationStore));
            NavigateUpdateCategoryCommand = new NavigateCommand<UpdateCategoryModels>(navigationStore, () => new UpdateCategoryModels(navigationStore, id));
        }
    }
}
