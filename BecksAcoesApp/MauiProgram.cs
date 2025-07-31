using Infra.Http.HttpClients;
using Infra.Http.HttpClients.Interfaces;
using Microsoft.Extensions.Logging;

namespace BecksAcoesApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.Services.AddHttpClient<IBeckAcoesApiClient, BecksAcoesApiClient>("BecksApi", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7240/");
            });

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}