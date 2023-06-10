using DataGrid.Commands;
using DataGrid.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using DataGrid.ViewModels.ProductViewModel;

namespace DataGrid.ViewModels.ProductViewModel
{
    public class AddProductModels : ViewModelBase
    {
        public ICommand CommandProductIndex { get; }

        public AddProductModels(NavigationStore navigationStore)
        {
            CommandProductIndex = new NavigateCommand<ProductModels>(navigationStore, () => new ProductModels(navigationStore));
        }
    }
}
