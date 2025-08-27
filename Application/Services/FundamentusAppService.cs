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

        var details = GetTableByLabel(page, ticket);//where i can get the name...
        var marketValue = GetTableByLabel(page, "Valor de mercado");//i can get the market value...
        var valuation = GetTableByLabel(page, "Indicadores fundamentalistas");//i can get the valuation...
        var patrimony = GetTableByLabel(page, "Dados Balanço Patrimonial");//i can get the patrimonial values...
        var profits = GetTableByLabel(page, "Lucro Líquido");//i can get the patrimonial values...

        var allData = details
            .Concat(marketValue)
            .Concat(valuation)
            .Concat(patrimony)
            .Concat(profits)
            .ToDictionary(k => k.Key, v => v.Value);

        var dto = allData.MapToFundamentusDto();

        return dto;
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

    private static Dictionary<string, string> GetTableByLabel(HtmlDocument page, string labelToFind)
    {
        if (page == null)
            throw new ArgumentNullException(nameof(page), "HTML document cannot be null.");

        // Select all table nodes with the class "w728"
        var tableNodes = page.DocumentNode.SelectNodes("//table[@class='w728']");

        if (tableNodes != null)
        {
            // Iterate through each table to find the one containing the specified label
            foreach (var tableNode in tableNodes)
            {
                // Look for a <span> tag with the class 'txt' that contains our target label.
                var labelNode = tableNode.SelectSingleNode($".//span[@class='txt' and text()='{labelToFind}']");

                // If the label is found in this table, we've found our target table.
                if (labelNode != null)
                {
                    var tableData = new Dictionary<string, string>();

                    // Get all the rows within this specific table
                    var rowNodes = tableNode.SelectNodes(".//tr");
                    if (rowNodes != null)
                    {
                        foreach (var row in rowNodes)
                        {
                            // Get all the 'label' and 'data' cells in the row.
                            // The XPath expression 'td' is safe as it's the only type of cell.
                            var cells = row.SelectNodes("td");

                            if (cells != null && cells.Count >= 4)
                            {
                                // The layout is label/data/label/data.
                                // We extract the text from the <span> inside each cell.

                                var key1 = cells[0].SelectSingleNode(".//span[@class='txt']")?.InnerText.Trim();
                                var value1 = cells[1].SelectSingleNode(".//span[@class='txt']")?.InnerText.Trim();
                                var key2 = cells[2].SelectSingleNode(".//span[@class='txt']")?.InnerText.Trim();
                                var value2 = cells[3].SelectSingleNode(".//span[@class='txt']")?.InnerText.Trim();

                                // Add the key-value pairs to the dictionary if they exist
                                if (!string.IsNullOrEmpty(key1) && !string.IsNullOrEmpty(value1))
                                {
                                    tableData[key1] = value1;
                                }
                                if (!string.IsNullOrEmpty(key2) && !string.IsNullOrEmpty(value2))
                                {
                                    tableData[key2] = value2;
                                }
                            }
                        }
                    }
                    return tableData;
                }
            }
        }

        // If no table with the specified label was found, return an empty dictionary.
        return new Dictionary<string, string>();
    }

    public decimal CalcularPrecoTeto(string cotacao, string dividendYield)
    {
        string dividendYieldSemPorcentagem = dividendYield.Replace("%", string.Empty).Replace(",", ".").Trim();
        string cotacaoSemVirgula = cotacao.Replace(',', '.').Trim();

        if (!decimal.TryParse(dividendYieldSemPorcentagem, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal decimalDividendYield))
            return 0;

        if (!decimal.TryParse(cotacaoSemVirgula, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal decimalCotacao))
            return 0;

        decimal dividendoPorAcao = decimalCotacao * (decimalDividendYield / 100m);

        if (dividendoPorAcao <= 0)
            return 0.0m;

        return Math.Round(dividendoPorAcao / 0.06m, 2); //Preço teto de Bazin é o dividendo por ação dividido por 6% (0.06)
    }

    public decimal CalcularPrecoJusto(string precoSobreLucro, string crescimentoReceitaUltimosCincoAnos, string cotacao)
    {
        string precoSobreLucroSemPorcentagem = precoSobreLucro.Replace("%", string.Empty).Replace(",", ".").Trim();
        string crescimentoReceitaUltimosCincoAnosSemPorcentagem = crescimentoReceitaUltimosCincoAnos.Replace("%", string.Empty).Replace(",", ".").Trim();
        string cotacaoSemVirgula = cotacao.Replace(',', '.').Trim();

        if (!decimal.TryParse(precoSobreLucroSemPorcentagem, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal decimalPrecoSobreLucro))
            return 0;

        if (!decimal.TryParse(crescimentoReceitaUltimosCincoAnosSemPorcentagem, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal decimalCrescimentoReceitaUltimosCincoAnos))
            return 0;

        if (!decimal.TryParse(cotacaoSemVirgula, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal decimalCotacao))
            return 0;

        // O preço sobre o lucro (P/L) não pode ser zero
        if (decimalPrecoSobreLucro == 0)
            return 0.0m;

        // Calcula o Lucro por Ação (LPA)
        decimal lucroPorAcao = decimalCotacao / decimalPrecoSobreLucro;

        // A fórmula de Graham usa a taxa de crescimento anual. O seu objeto tem o crescimento da receita.
        // Aqui, usamos essa propriedade como a "taxa de crescimento".
        // A fórmula usa um multiplicador de 7 e um fator de segurança de 1.5.
        decimal precoJusto = lucroPorAcao * (7m + decimalCrescimentoReceitaUltimosCincoAnos) * 1.5m;

        return Math.Round(precoJusto, 2);
    }
}