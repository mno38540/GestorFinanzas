using GestorFinanzas.ViewModel;
using GestorFinanzas.Views;
using GestorFinanzas.Service;

namespace GestorFinanzas
{
    public partial class AppShell : Shell
    {
       
        public AppShell()
        {
            InitializeComponent();

            FlyoutBehavior = FlyoutBehavior.Flyout;

        }
    }
}
