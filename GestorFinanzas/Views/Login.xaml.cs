namespace GestorFinanzas.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // L�gica de validaci�n b�sica
        if (usuario.Text == "admin" && clave.Text == "1234")
        {
            // Navegar a HomePage
            await Navigation.PushAsync(new Home());
        }
        else
        {
            await DisplayAlert("Error", "Usuario o contrase�a incorrectos", "OK");
        }
    }
}