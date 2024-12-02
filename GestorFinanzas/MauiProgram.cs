using GestorFinanzas.Model;
using GestorFinanzas.Views;
using Microsoft.Extensions.Logging;

namespace GestorFinanzas
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            var dbcontext = new Data();
            dbcontext.Database.EnsureCreated();
            dbcontext.Dispose();

            Routing.RegisterRoute(nameof(MovimientoDetalle), typeof(MovimientoDetalle));


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
