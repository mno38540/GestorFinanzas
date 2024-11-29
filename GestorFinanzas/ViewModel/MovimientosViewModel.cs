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
        public decimal Balance => TotalIngresos - TotalEgresos;
        public decimal TotalIngresos { get; set; }
        public decimal TotalEgresos { get; set; }
        public DateTime FechaActual { get; set; } = DateTime.Now;

            public event PropertyChangedEventHandler PropertyChanged;

            public ObservableCollection<Data> Movimientos { get; set; }
        
        public MovimientosViewModel()
            {
                Movimientos = new ObservableCollection<Data>
                {
                    new Data { Fecha = "5/10/2024", Descripcion = "Arriendo", Monto = -850000 },
                    new Data { Fecha = "1/10/2024", Descripcion = "Comida", Monto = -55500 },
                    new Data { Fecha = "2/10/2024", Descripcion = "Sueldo", Monto = 1500000 }
                };
            }

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
}
