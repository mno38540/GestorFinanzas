using GestorFinanzas.ViewModel;

namespace GestorFinanzas.Views;

public partial class MovimientoDetalle : ContentPage, IQueryAttributable
{
	public MovimientoDetalle()
	{
		InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Title = $"Movimiento: {query["id"]}";
    }
}