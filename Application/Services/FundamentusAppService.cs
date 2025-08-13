using BeckAcoesApp.Application.Dtos;
using BeckAcoesApp.Application.Interfaces.Http;
using BeckAcoesApp.Application.Interfaces.Services;
using BeckAcoesApp.Application.Mappers;
using HtmlAgilityPack;
using System.Globalization;

namespace BeckAcoesApp.Application.Services;

public sealed class FundamentusAppService(IFundamentusHttpClient fundamentusHttpClient) : IFundamentusAppService
{
    // Example method to get data from Fundamentus
    public async Task<FundamentusDto?> GetFundamentusDataAsync(string ticket)
    {
        //I'm getting the HTML because the API doesn't allow me to get the data directly in JSON format.
        var resultHTML = await fundamentusHttpClient.GetFundamentusDataAsync(ticket);

        HtmlDocument page = new();
        page.LoadHtml(resultHTML);

        //Here i'll manipulate the html response
        var table = GetFundamentusTableAsync(page, ticket);

        if (table.Count < 0)
            return null;

        var result = table.MapToFundamentusDto();

        return result;
    }

    private static Dictionary<string, string> GetFundamentusTableAsync(HtmlDocument page, string ticket)
    {
        if (page == null)
            throw new ArgumentNullException(nameof(page), "HTML document cannot be null.");

        // Find the table by id
        var tableNode = page.DocumentNode.SelectSingleNode("//table[@id='resultado']");
        if (tableNode == null)
            return [];

        // Get headers
        var headerNodes = tableNode.SelectNodes(".//thead/tr/th");
        var headers = headerNodes?.Select(h => h.InnerText.Trim()).ToList() ?? [];

        // Get rows
        var rowNodes = tableNode.SelectNodes(".//tbody/tr");
        var tableData = new List<Dictionary<string, string>>();

        if (rowNodes != null)
        {
            foreach (var row in rowNodes)
            {
                var cellNodes = row.SelectNodes("td");
                if (cellNodes == null || cellNodes.Count == 0) continue;

                // Check if the first cell contains an <a> tag with the ticket text
                var aTag = cellNodes[0].SelectSingleNode(".//a");
                if (aTag != null && aTag.InnerText.Trim().Equals(ticket, StringComparison.OrdinalIgnoreCase))
                {
                    var rowDict = new Dictionary<string, string>();
                    for (int i = 0; i < cellNodes.Count && i < headers.Count; i++)
                    {
                        rowDict[headers[i]] = cellNodes[i].InnerText.Trim();
                    }
                    return rowDict;
                }
            }
        }

        return [];
    }

    public decimal CalcularPrecoTeto(string cotacao, string dividendYield)
    {
        if (!decimal.TryParse(dividendYield, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal decimalDividendYield))
            return 0;

        if (!decimal.TryParse(cotacao, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal decimalCotacao))
            return 0;

        decimal dividendoPorAcao = decimalCotacao * decimalDividendYield;

        if (dividendoPorAcao <= 0)
            return 0.0m;

        return dividendoPorAcao / 0.06m; //Preço teto de Bazin é o dividendo por ação dividido por 6% (0.06)
    }

    public decimal CalcularPrecoJusto(string precoSobreLucro, string crescimentoReceitaUltimosCincoAnos, string cotacao)
    {
        if (!decimal.TryParse(precoSobreLucro, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal decimalPrecoSobreLucro))
            return 0;

        if (!decimal.TryParse(crescimentoReceitaUltimosCincoAnos, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal decimalCrescimentoReceitaUltimosCincoAnos))
            return 0;

        if (!decimal.TryParse(cotacao, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal decimalCotacao))
            return 0;

        // O preço sobre o lucro (P/L) não pode ser zero
        if (decimalPrecoSobreLucro == 0)
            return 0.0m;

        // Calcula o Lucro por Ação (LPA)
        decimal lucroPorAcao = decimalCotacao / decimalPrecoSobreLucro;

        // A fórmula de Graham usa a taxa de crescimento anual. O seu objeto tem o crescimento da receita.
        // Aqui, usamos essa propriedade como a "taxa de crescimento".
        // A fórmula usa um multiplicador de 7 e um fator de segurança de 1.5.
        decimal precoJusto = lucroPorAcao * (7m + (decimalCrescimentoReceitaUltimosCincoAnos * 100m)) * 1.5m;

        return precoJusto;
    }
}