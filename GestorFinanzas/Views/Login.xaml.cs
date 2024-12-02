using GestorFinanzas.Model;

namespace GestorFinanzas.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var database = new Data();
        var u = database.Usuarios.FirstOrDefault();
        // L�gica de validaci�n b�sica
        if (usuario.Text == u.user && clave.Text == u.Clave)
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