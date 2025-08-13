using BeckAcoesApp.Application.Dtos;

namespace BeckAcoesApp.Application.Interfaces.Services;

public interface IFundamentusAppService
{
    Task<FundamentusDto?> GetFundamentusDataAsync(string ticket);
}