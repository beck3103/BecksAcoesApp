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


        // Add the bearer token to the Authorization header
        // It's generally better to set this once if the token is long-lived
        // or before each request if tokens are refreshed frequently.
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);


        string path = string.Concat("/Fundamentus/fundamentus", ticket);
            
        var response = await httpClient.GetAsync(path);
        response.EnsureSuccessStatusCode();

        var dataResponse = await response.Content.ReadFromJsonAsync<FundamentusDto>();

        if (dataResponse == null)
            throw new InvalidOperationException("Failed to deserialize the response.");

        return dataResponse;
    }

    public async Task<string> GetBearerToken(string userName, string password)
    {
        if (string.IsNullOrWhiteSpace(userName))
            throw new ArgumentException("UserName cannot be null or empty.", nameof(userName));

        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password cannot be null or empty.", nameof(password));

        string path = string.Concat("/Auth/login");

        var body = new
        {
            UserName = userName,
            Password = password
        };

        var response = await httpClient.PostAsJsonAsync(path, body);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}