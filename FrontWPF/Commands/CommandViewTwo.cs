using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using DataGrid.Store;
using DataGrid.ViewModels;


namespace DataGrid.Commands
{
    public class CommandViewTwo : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public ICommand _CommandCategoryIndex;
        public override void Execute(object parameter)
        {
            //_navigationStore.CurrentViewModel = new ViewTwoModels();
        }

        public CommandViewTwo(NavigationStore navigationStore)
        {
            _CommandCategoryIndex = new CommandCategoryIndex(navigationStore);
        }
    }
}
