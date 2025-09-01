using BeckAcoesApp.Application.Dtos;

namespace BeckAcoesApp.Application.Interfaces.Services;

public interface IFundamentusAppService
{
    decimal CalculateFairPrice(string netIncome, string shareholdersEquity, string numberOfShares);

    decimal CalculateMaximumPrice(string dividendYield, string currentPrice);

    Task<FundamentusDto?> GetFundamentusDataAsync(string ticket);
}