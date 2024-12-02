using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GestorFinanzas.Model;
using GestorFinanzas.Views;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GestorFinanzas.ViewModel
{
    public class MovimientosViewModel : BindingUtilObject
    {
        public Command AgregarIngresoCommand { get; }
        public Command AgregarGastoCommand { get; }


        //Propiedades para el calculo de los totales
        public decimal TotalIngresos { get; private set; }
        public decimal TotalEgresos { get; private set; }
        public decimal Balance => TotalIngresos + TotalEgresos;




        public DateTime FechaActual { get; set; } = DateTime.Now;
        public MovimientosViewModel()
        {
            var database = new Data();
            Movimientos = new ObservableCollection<Movimiento>(database.Movimientos);
            TotalIngresos = ObtenerTotalIngresos();
            TotalEgresos = ObtenerTotalEgresos();
            PropertyChanged += HelpSupportData_PropertyChanged;

            AgregarIngresoCommand = new Command(async () =>
       {
           var ingresoPage = new Ingreso
           {
               BindingContext = new IngresoViewModel()
           };
           await Application.Current.MainPage.Navigation.PushAsync(ingresoPage);
       });

            AgregarGastoCommand = new Command(async () =>
            {
                var gastoPage = new Gasto
                {
                    BindingContext = new GastoViewModel()
                };
                await Application.Current.MainPage.Navigation.PushAsync(gastoPage);
            });


        }

        private async void HelpSupportData_PropertyChanged(Object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MovimientoSeleccionado))
            {
                var uri = $"{nameof(MovimientoDetalle)}?id={MovimientoSeleccionado.Id}";
                await Shell.Current.GoToAsync(uri);
            }
        }

        private ObservableCollection<Movimiento> _movimientos;
        public ObservableCollection<Movimiento> Movimientos
        {
            get { return _movimientos; }
            set
            {
                if (_movimientos != value)
                {
                    _movimientos = value;
                    RaisePropertyChanged();
                }
            }
        }


        private Movimiento _movimientoSeleccionado;
        public Movimiento MovimientoSeleccionado
        {
            get { return _movimientoSeleccionado; }
            set
            {
                if (_movimientoSeleccionado != value)
                {
                    _movimientoSeleccionado = value;
                    RaisePropertyChanged();
                }
            }
        }
        public decimal ObtenerTotalIngresos()
        {
            return _movimientos.Where(m => m.Monto > 0).Sum(m => m.Monto);
        }

        public decimal ObtenerTotalEgresos()
        {
            return _movimientos.Where(m => m.Monto < 0).Sum(m => m.Monto);
        }
        public void AgregarMovimiento(Movimiento movimiento)
        {
            Movimientos.Add(movimiento);
        }

    }

}
