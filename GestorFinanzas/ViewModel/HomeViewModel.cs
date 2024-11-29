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
        public DateTime FechaActual { get; set; } = DateTime.Now;
        public decimal Balance => TotalIngresos - TotalEgresos;
        public decimal TotalIngresos { get; set; }
        public decimal TotalEgresos { get; set; }

        public ObservableCollection<Data> Movimientos { get; set; }

        public HomeViewModel()
        {
            // Inicializar con datos de ejemplo
            TotalIngresos = 1000;
            TotalEgresos = 500;
            Movimientos = new ObservableCollection<Data>
        {
            new Data { Descripcion = "Salario", Monto = 1000 },
            new Data { Descripcion = "Renta", Monto = -500 }
        };
        }

        public event PropertyChangedEventHandler PropertyChanged;


    }
}
