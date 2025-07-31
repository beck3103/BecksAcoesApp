using Infra.Http.Dtos;

namespace Infra.Http.HttpClients.Interfaces;

public interface IBeckAcoesApiClient
{
    Task<FundamentusDto> GetFundamentusDataAsync(string ticket, string bearerToken);

    Task<string> GetBearerToken(string userName, string password);
}