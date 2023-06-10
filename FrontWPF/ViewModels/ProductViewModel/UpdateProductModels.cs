using DataGrid.Commands;
using DataGrid.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using DataGrid.ViewModels.ProductViewModel;

namespace DataGrid.ViewModels.ProductViewModel
{
    public class UpdateProductModels : ViewModelBase
    {
        public ICommand NavigateProductsCommand { get; }

        public string IdProduct { get; set; }

        public UpdateProductModels(NavigationStore navigationStore, string _id)
        {
            NavigateProductsCommand = new NavigateCommand<ProductModels>(navigationStore, () => new ProductModels(navigationStore));
            IdProduct = _id;
        }
    }
}
