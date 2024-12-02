using GestorFinanzas.Views;
using GestorFinanzas.ViewModel;

namespace GestorFinanzas
{
    public partial class App : Application
    {
        public static MovimientosViewModel MovimientosViewModel { get; private set; }
        public App()
        {
            InitializeComponent();

            MainPage = new GestorFinanzas.Views.Login();
            MainPage = new NavigationPage(new Login());
            MovimientosViewModel = new MovimientosViewModel();
        }
    }
}
