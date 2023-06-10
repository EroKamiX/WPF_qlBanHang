using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataGrid.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnChanged(string propertyName = null)
        {
             PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void Dispose() { }
    }
}
