using GestorFinanzas.ViewModel;
namespace GestorFinanzas.Views;


public partial class Home : ContentPage
{
	public Home()
	{
		InitializeComponent();
        BindingContext = new MovimientosViewModel();
    }



}