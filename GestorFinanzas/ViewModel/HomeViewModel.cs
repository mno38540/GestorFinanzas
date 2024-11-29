using GestorFinanzas.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorFinanzas.ViewModel
{
    internal class HomeViewModel : INotifyPropertyChanged
    {
       

        public ObservableCollection<Data> Movimientos { get; set; }

       

        public event PropertyChangedEventHandler PropertyChanged;


    }
}
