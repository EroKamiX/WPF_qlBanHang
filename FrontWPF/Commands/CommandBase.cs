using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DataGrid.Commands
{
    public abstract class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter) => true;

        public abstract void Execute(object parameter);
        protected void OnChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
