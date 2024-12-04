using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GestorFinanzas.Service;
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
        public DateTime FechaActual { get; set; } = DateTime.Now;
        public MovimientosViewModel()
        {
            var database = new Data();
            
            
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

            Movimientos = new ObservableCollection<Movimiento>(database.Movimientos);
            Movimientos.CollectionChanged += Movimientos_CollectionChanged;
            ActualizarTotales();
            PropertyChanged += OnMovimientoSeleccionado;
        }
        private async void OnMovimientoSeleccionado(Object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MovimientoSeleccionado))
            {
                App.MovimientoService.MovimientoSeleccionado = MovimientoSeleccionado;
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
        private decimal _totalIngresos;
        public decimal TotalIngresos
        {
            get => _totalIngresos;
            private set
            {
                if (_totalIngresos != value)
                {
                    _totalIngresos = value;
                    RaisePropertyChanged();
                }
            }
        }

        private decimal _totalEgresos;
        public decimal TotalEgresos
        {
            get => _totalEgresos;
            private set
            {
                if (_totalEgresos != value)
                {
                    _totalEgresos = value;
                    RaisePropertyChanged();
                }
            }
        }
        public decimal Balance => TotalIngresos + TotalEgresos;


        private void Movimientos_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Recalcula los totales al cambiar la colección
            ActualizarTotales();
        }

        private void ActualizarTotales()
        {
            TotalIngresos = Movimientos.Where(m => m.Monto > 0).Sum(m => m.Monto);
            TotalEgresos = Movimientos.Where(m => m.Monto < 0).Sum(m => m.Monto);
            RaisePropertyChanged(nameof(Balance)); // Notifica cambios en el balance.
        }


    }

}
