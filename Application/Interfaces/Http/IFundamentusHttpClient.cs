namespace BeckAcoesApp.Application.Interfaces.Http;

public interface IFundamentusHttpClient
{
    Task<string> GetFundamentusDataAsync(string ticket);
}