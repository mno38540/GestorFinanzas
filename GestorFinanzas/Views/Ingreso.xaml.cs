namespace GestorFinanzas.Views;

public partial class Ingreso : ContentPage
{
	public Ingreso()
	{
		InitializeComponent();
        BindingContext = App.MovimientosViewModel;
    }
}