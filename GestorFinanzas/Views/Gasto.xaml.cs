using GestorFinanzas.ViewModel;

namespace GestorFinanzas.Views;

public partial class Gasto : ContentPage
{
	public Gasto()
	{
		InitializeComponent();
        BindingContext = App.MovimientosViewModel;
		//BindingContext = new GastoViewModel();
    }
}