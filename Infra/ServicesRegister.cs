using BeckAcoesApp.Application.Interfaces.Http;
using Infra.Http.HttpClients;

namespace Infra;

// All the code in this file is included in all platforms.
public static class ServicesRegister
{
    public static void AddBeckAcoesApiClient(this IServiceCollection services)
    {
        services.AddHttpClient<IBeckAcoesApiClient, BecksAcoesApiClient>("BecksApi", client =>
        {
            client.BaseAddress = new Uri("https://localhost:20121/api/");
        });
    }
}
