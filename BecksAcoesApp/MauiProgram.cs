using BeckAcoesApp.Application.Interfaces.Http;
using Infra;
using Infra.Http.HttpClients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BecksAcoesApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.Services.RegisterServices();

            builder.Services.AddHttpClient<IFundamentusHttpClient, FundamentusHttpClient>("FundamentusClient", client =>
            {
                client.BaseAddress = new Uri("https://www.fundamentus.com.br");
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