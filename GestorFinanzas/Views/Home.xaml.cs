using GestorFinanzas.Model;
using GestorFinanzas.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace GestorFinanzas.Views;


public partial class Home : ContentPage
{
	public Home()
	{
		InitializeComponent();
        //var dbContext = new Data();
        BindingContext = App.MovimientosViewModel;
        //BindingContext = new HomeViewModel();

    }


}