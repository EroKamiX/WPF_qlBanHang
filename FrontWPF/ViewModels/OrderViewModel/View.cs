using DataGrid.Commands;
using DataGrid.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DataGrid.ViewModels.OrderViewModel
{
    public class View : ViewModelBase
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
        public ICommand NavigateAddCommand { get; }
        public ICommand NavigateUpdateCommand { get; }
        public View(NavigationStore navigationStore)
        {
            NavigateAddCommand = new NavigateCommand<Add>(navigationStore, () => new Add(navigationStore));
            NavigateUpdateCommand = new NavigateCommand<Update>(navigationStore, () => new Update(navigationStore, id));
        }
    }
}
