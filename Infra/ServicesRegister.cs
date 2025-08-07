using BeckAcoesApp.Application.Interfaces.Http;
using BeckAcoesApp.Application.Interfaces.Services;
using BeckAcoesApp.Application.Services;
using Infra.Http.HttpClients;

namespace Infra;

// All the code in this file is included in all platforms.
public static class ServicesRegister
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddBeckAcoesApiClient();
        services.RegisterAppServices();
    }

    private static void AddBeckAcoesApiClient(this IServiceCollection services) =>
        services.AddHttpClient<IBeckAcoesApiClient, BecksAcoesApiClient>("BecksApi", client =>
        {
            client.BaseAddress = new Uri("https://localhost:20121/api/");
        });

    private static void RegisterAppServices(this IServiceCollection services) =>
            services.AddScoped<IFundamentusAppService, FundamentusAppService>();
}