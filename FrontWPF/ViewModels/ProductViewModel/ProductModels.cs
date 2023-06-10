using DataGrid.Commands;
using DataGrid.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DataGrid.ViewModels.ProductViewModel
{
    public class ProductModels : ViewModelBase
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
        public ICommand NavigateAddProductCommand { get; }
        public ICommand NavigateUpdateProductCommand { get; }
        public ProductModels(NavigationStore navigationStore)
        {
            NavigateAddProductCommand = new NavigateCommand<AddProductModels>(navigationStore, () => new AddProductModels(navigationStore));
            NavigateUpdateProductCommand = new NavigateCommand<UpdateProductModels>(navigationStore, () => new UpdateProductModels(navigationStore, id));
        }
    }
}
