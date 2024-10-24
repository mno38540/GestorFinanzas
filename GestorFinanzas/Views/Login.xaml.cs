namespace GestorFinanzas.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}
    private async void OnButtonClicked(object sender, EventArgs e)
    {
        
        await Navigation.PushAsync(new Home());
    }
    private async void AgregarIngreso()
    {
        // Navegar a la página de agregar ingreso
        await Application.Current.MainPage.Navigation.PushAsync(new Ingreso());
    }
}