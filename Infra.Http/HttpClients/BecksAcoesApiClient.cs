namespace Infra.Http.HttpClients;

public sealed class BecksAcoesApiClient(HttpClient httpClient)
{
    public async Task<string> GetFundamentusDataAsync(string ticket)
    {
        if (string.IsNullOrWhiteSpace(ticket))
            throw new ArgumentException("URL cannot be null or empty.", nameof(ticket));

        string path = string.Concat("/Fundamentus/fundamentus", ticket);
            
        var response = await httpClient.GetAsync(path);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}