using GestorFinanzas.Views;

namespace GestorFinanzas
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new GestorFinanzas.Views.Login();
            MainPage = new NavigationPage(new Login());
        }
    }
}
