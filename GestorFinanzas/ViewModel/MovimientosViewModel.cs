using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorFinanzas.Model;

namespace GestorFinanzas.ViewModel
{
        public class MovimientosViewModel : INotifyPropertyChanged
        {

            public event PropertyChangedEventHandler PropertyChanged;

          
        
       

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
}
