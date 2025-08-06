using BeckAcoesApp.Application.Dtos;

namespace BeckAcoesApp.Application.Interfaces.Http;

public interface IBeckAcoesApiClient
{
    Task<FundamentusDto> GetFundamentusDataAsync(string ticket, string bearerToken);

    Task<TokenResponseDto> GetBearerToken(string userName, string password);
}