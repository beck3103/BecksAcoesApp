using BeckAcoesApp.Application.Interfaces.Http;
using BeckAcoesApp.Application.Interfaces.Services;
using BeckAcoesApp.Application.Services;

namespace Infra;

// All the code in this file is included in all platforms.
public static class ServicesRegister
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.RegisterAppServices();
    }

    private static void RegisterAppServices(this IServiceCollection services) =>
            services.AddScoped<IFundamentusAppService, FundamentusAppService>();
}