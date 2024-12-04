using GestorFinanzas.Views;

namespace GestorFinanzas
{
    public partial class MainPage : ContentPage
    {
        public Command Cerrar { get; }

        public MainPage()
        {
            InitializeComponent();
            //Cerrar = new Command(async () =>
            //{
            //    await Navigation.PushAsync(new Login());
            //});
        }

      
    }

}
