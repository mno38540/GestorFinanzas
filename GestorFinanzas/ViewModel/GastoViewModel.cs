using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GestorFinanzas.Model;
using GestorFinanzas.Views;

namespace GestorFinanzas.ViewModel
{
    internal class GastoViewModel: BindingUtilObject
    {
        public ICommand GuardarGastoCommand { get; }
        private string descripcion;
        private decimal monto;
        private DateTime fecha;
        private int categoriaSeleccionada;

        public string Descripcion
        {
            get => descripcion;
            set
            {
                descripcion = value;
                RaisePropertyChanged();
            }
        }

        public decimal Monto
        {
            get => monto;
            set
            {
                monto = value;
                RaisePropertyChanged();
            }
        }

        public DateTime Fecha
        {
            get => fecha;
            set
            {
                fecha = value;
                RaisePropertyChanged();
            }
        }

        public int CategoriaSeleccionada
        {
            get => categoriaSeleccionada;
            set
            {
                categoriaSeleccionada = value;
                RaisePropertyChanged();
            }
        }



        public ObservableCollection<Category> Categorias { get; set; }
        public GastoViewModel()
        {
            // Cargar las categorías desde la base de datos
            var db = new Data();
            Categorias = new ObservableCollection<Category>(db.Categories);
            Fecha = DateTime.Now;

            GuardarGastoCommand = new Command(async () =>
            {
                // Crear el nuevo movimiento
                var nuevoMovimiento = new Movimiento
                (
                    new Random().Next(20, 100),
                Descripcion,
                -Monto,
                Fecha.ToString("dd/mm/yyyy"),
                CategoriaSeleccionada,
                1
                );
                // Actualizar el HomeViewModel
                var homeViewModel = Application.Current.MainPage.BindingContext as MovimientosViewModel;
                homeViewModel?.Movimientos.Add(nuevoMovimiento);

                // Navegar de regreso al Home
                await Application.Current.MainPage.Navigation.PopAsync();
            });
        }
    }
}
