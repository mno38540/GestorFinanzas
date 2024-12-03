using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorFinanzas.Model;
using Microsoft.EntityFrameworkCore.Storage;

namespace GestorFinanzas.ViewModel
{
    public class MovimientoDetalleViewModel: BindingUtilObject
    {
        public Category Category => Movimiento.Category;
        public Command VolverCommand { get; }

        public MovimientoDetalleViewModel()
        {
            var database = new Data();
            //MovimientoSeleccionado = new ObservableCollection<Movimiento>(database.Movimientos);
            Movimiento = App.MovimientoService.MovimientoSeleccionado;

            VolverCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            });
        }
        private Movimiento _movimiento;
        public Movimiento Movimiento
        {
            get => _movimiento;
            set
            {
                _movimiento = value;
                RaisePropertyChanged();
            }
        }

        //public string Descripcion => Movimiento.Descripcion;
        //public decimal Monto => Movimiento.Monto;
        //public string Fecha => Movimiento.Fecha;
    }
}
