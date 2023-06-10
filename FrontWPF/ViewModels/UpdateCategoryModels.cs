using DataGrid.Commands;
using DataGrid.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DataGrid.ViewModels
{
    public class UpdateCategoryModels : ViewModelBase
    {
        public ICommand CommandCategoryIndex { get; }

        public string IdCategory { get; set; }

        public UpdateCategoryModels(NavigationStore navigationStore, string _id)
        {
            CommandCategoryIndex = new NavigateCommand<CategoryModels>(navigationStore, () => new CategoryModels(navigationStore));
            IdCategory = _id;
        }
    }
}
