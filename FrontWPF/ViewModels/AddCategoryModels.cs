using DataGrid.Commands;
using DataGrid.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DataGrid.ViewModels
{
    public class AddCategoryModels : ViewModelBase
    {
        public ICommand CommandCategoryIndex { get; }

        public AddCategoryModels(NavigationStore navigationStore)
        {
            CommandCategoryIndex = new NavigateCommand<CategoryModels>(navigationStore, () => new CategoryModels(navigationStore));
        }
    }
}
