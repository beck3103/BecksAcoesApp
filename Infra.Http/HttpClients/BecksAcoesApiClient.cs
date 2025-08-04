using Infra.Http.Dtos;
using Infra.Http.HttpClients.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Infra.Http.HttpClients;

public sealed class BecksAcoesApiClient(HttpClient httpClient) : IBeckAcoesApiClient
{
    public async Task<FundamentusDto> GetFundamentusDataAsync(string ticket, string bearerToken)
    {
        if (string.IsNullOrWhiteSpace(ticket))
            throw new ArgumentException("URL cannot be null or empty.", nameof(ticket));

        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

        string path = string.Concat("Fundamentus/fundamentus/", ticket);

        var response = await httpClient.GetAsync(path);
        response.EnsureSuccessStatusCode();

        var dataResponse = await response.Content.ReadAsStringAsync();
        var dataResponse1 = await response.Content.ReadFromJsonAsync<FundamentusDto>();

        return dataResponse1 ?? throw new InvalidOperationException("Failed to deserialize the response.");
    }

    public async Task<TokenResponseDto> GetBearerToken(string userName, string password)
    {
        if (string.IsNullOrWhiteSpace(userName))
            throw new ArgumentException("UserName cannot be null or empty.", nameof(userName));

        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password cannot be null or empty.", nameof(password));

        string path = string.Concat("auth/login");

        var body = new
        {
            UserName = userName,
            Password = password
        };

        var response = await httpClient.PostAsJsonAsync(path, body);
        response.EnsureSuccessStatusCode();

        var dataResponse = await response.Content.ReadFromJsonAsync<TokenResponseDto>();

        return dataResponse ?? throw new InvalidOperationException("Failed to deserialize the response.");
    }
}