using BeckAcoesApp.Application.Dtos;
using BeckAcoesApp.Application.Interfaces.Http;
using BeckAcoesApp.Application.Interfaces.Services;

namespace BeckAcoesApp.Application.Services;

public sealed class FundamentusAppService(IBeckAcoesApiClient beckAcoesApiClient) : IFundamentusAppService
{
    public async Task<FundamentusDto?> GetFundamentusDataAsync(string ticket, string bearerToken)
    {
        var result = await beckAcoesApiClient.GetFundamentusDataAsync(ticket, bearerToken);

        if (result == null)
        {
            return null;//Mensagem de erro
        }

        return result;
    }

    public async Task<TokenResponseDto?> GetBearerToken(string userName, string password)
    {
        var result = await beckAcoesApiClient.GetBearerToken(userName, password);
        if (result == null)
        {
            return null; //Mensagem de erro
        }
        return result;
    }
}