using GestorFinanzas.Model;
using GestorFinanzas.ViewModel;
using System.Collections.ObjectModel;

namespace GestorFinanzas.Views;

public partial class MovimientoDetalle : ContentPage, IQueryAttributable
{
	public MovimientoDetalle()
	{
		InitializeComponent();
       BindingContext = new MovimientoDetalleViewModel();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var us = $"Movimiento: {query["id"]}";
    }
}
