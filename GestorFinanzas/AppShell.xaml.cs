using GestorFinanzas.Views;

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
