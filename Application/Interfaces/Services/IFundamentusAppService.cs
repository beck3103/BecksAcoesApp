using BeckAcoesApp.Application.Dtos;

namespace BeckAcoesApp.Application.Interfaces.Services;

public interface IFundamentusAppService
{
    Task<FundamentusDto?> GetFundamentusDataAsync(string ticket);

    decimal CalcularPrecoJusto(string precoSobreLucro, string crescimentoReceitaUltimosCincoAnos, string cotacao);

    decimal CalcularPrecoTeto(string cotacao, string dividendYield);
}