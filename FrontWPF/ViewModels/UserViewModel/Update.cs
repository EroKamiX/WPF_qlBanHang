using DataGrid.Commands;
using DataGrid.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DataGrid.ViewModels.UserViewModel
{
    public class Update : ViewModelBase
    {
        public ICommand NavigateViewCommand { get; }

        public string id { get; set; }

        public Update(NavigationStore navigationStore, string _id)
        {
            NavigateViewCommand = new NavigateCommand<View>(navigationStore, () => new View(navigationStore));
            id = _id;
        }
    }
}
