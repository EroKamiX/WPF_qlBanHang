using DataGrid.Commands;
using DataGrid.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DataGrid.ViewModels.OrderViewModel
{
    public class Add : ViewModelBase
    {
        public ICommand NavigateViewCommand { get; }

        public Add(NavigationStore navigationStore)
        {
            NavigateViewCommand = new NavigateCommand<View>(navigationStore, () => new View(navigationStore));
        }
    }
}
