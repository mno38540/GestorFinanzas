using GestorFinanzas.ViewModel;
namespace GestorFinanzas.Views;


public partial class Home : ContentPage
{
	public Home()
	{
		InitializeComponent();
        BindingContext = new MovimientosViewModel();
    }

    private async void OnIngresosClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Ingreso());
    }

    private async void OnGastosClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Gasto());
    }
}