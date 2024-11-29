namespace GestorFinanzas.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // Lógica de validación básica
        if (usuario.Text == "admin" && clave.Text == "1234")
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