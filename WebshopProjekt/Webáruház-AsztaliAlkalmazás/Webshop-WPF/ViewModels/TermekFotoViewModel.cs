using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Webshop_WPF.ViewModels
{
    public class TermekFotoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; 

        protected virtual void OnPropertyChanged([CallerMemberName] string proprertyName = null) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(proprertyName));
        }

        protected virtual bool SetProperty<T>(ref T storage, T value,
            [CallerMemberName] string proprertyName = null)
        {
            if (object.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            this.OnPropertyChanged(proprertyName);
            return true;
        }
    }
    
        
    
}
