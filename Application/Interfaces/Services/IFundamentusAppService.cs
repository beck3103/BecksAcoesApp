using BeckAcoesApp.Application.Dtos;

namespace BeckAcoesApp.Application.Interfaces.Services;

public interface IFundamentusAppService
{
    Task<TokenResponseDto?> GetBearerToken(string userName, string password);

    Task<FundamentusDto?> GetFundamentusDataAsync(string ticket, string bearerToken);
}