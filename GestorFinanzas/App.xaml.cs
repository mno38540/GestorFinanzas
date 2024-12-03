using GestorFinanzas.Views;
using GestorFinanzas.ViewModel;
using GestorFinanzas.Service;

namespace GestorFinanzas
{
    public partial class App : Application
    {
        public static MovimientoService MovimientoService { get; } = new MovimientoService();
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
