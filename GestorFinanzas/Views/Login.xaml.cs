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
        var user = database.Usuarios.FirstOrDefault();
        // Lógica de validación básica
        if (usuario.Text == user.usuario && clave.Text == user.Clave)
        {
            // Navegar a HomePage
            await Navigation.PushAsync(new Home());
        }
        else
        {
            await DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
        }
    }
}