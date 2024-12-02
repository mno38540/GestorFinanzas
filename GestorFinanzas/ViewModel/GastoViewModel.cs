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
        private Category categoriaSeleccionada;
        public GastoViewModel()
        {
            // Cargar las categorías desde la base de datos
            var db = new Data();
            Categories = new ObservableCollection<Category>(db.Categories);
            Fecha = DateTime.Now;
            GuardarGastoCommand = new Command(async () =>
            {
                var categoriaSeleccionada = Categories.FirstOrDefault(c => c.Id == CategoriaSeleccionada.Id);
                if(categoriaSeleccionada!= null) 
                {
                    var nuevoMovimiento = new Movimiento
                    (
                        new Random().Next(20, 100),
                        Descripcion,
                        -Monto,
                        Fecha.ToString("dd/mm/yyyy"),
                        CategoriaSeleccionada.Id,
                        1
                    )
                    {
                        Category = CategoriaSeleccionada
                    };
                    // Actualizar el HomeViewModel
                    App.MovimientosViewModel.Movimientos.Add(nuevoMovimiento);
                    // Navegar de regreso al Home
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                else 
                {
                    Console.WriteLine("Categoría seleccionada no válida.");
                }                     
            });
        }
        private ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set
            {
                if (_categories != value)
                {
                    _categories = value;
                    RaisePropertyChanged();
                }

            }
        }

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

        public Category CategoriaSeleccionada
        {
            get => categoriaSeleccionada;
            set
            {
                categoriaSeleccionada = value;
                RaisePropertyChanged();
            }
        }


    }
}
