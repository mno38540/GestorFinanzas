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
    public class MovimientoDetalleViewModel
    {
        public Movimiento Movimiento { get; }

        public Command VolverCommand { get; }

        public MovimientoDetalleViewModel()
        {
            var database = new Data();
            VolverCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            });
        }

        public string Descripcion => Movimiento.Descripcion;
        public decimal Monto => Movimiento.Monto;
        public string Fecha => Movimiento.Fecha;
        public Category Category => Movimiento.Category;
    }
}
