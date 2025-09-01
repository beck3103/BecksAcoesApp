using BeckAcoesApp.Application.Dtos;
using BeckAcoesApp.Application.Interfaces.Http;
using BeckAcoesApp.Application.Interfaces.Services;
using BeckAcoesApp.Application.Mappers;
using HtmlAgilityPack;
using System.Globalization;

namespace BeckAcoesApp.Application.Services;

public sealed class FundamentusAppService(IFundamentusHttpClient fundamentusHttpClient) : IFundamentusAppService
{
    public decimal CalculateFairPrice(string netIncome, string shareholdersEquity, string numberOfShares)
    {
        string netIncomeConverted = netIncome.Replace("%", string.Empty).Replace(",", ".").Trim();
        string shareholdersEquityConverted = shareholdersEquity.Replace("%", string.Empty).Replace(",", ".").Trim();
        string numberOfSharesConverted = numberOfShares.Replace(',', '.').Trim();

        CultureInfo culture = new CultureInfo("pt-BR");

        if (decimal.TryParse(netIncomeConverted, NumberStyles.Number, culture, out decimal decimalNetIncome) &&
        decimal.TryParse(shareholdersEquityConverted, NumberStyles.Number, culture, out decimal decimalShareholdersEquity) &&
        decimal.TryParse(numberOfSharesConverted, NumberStyles.Number, culture, out decimal decimalNumberOfShares) && decimalNumberOfShares > 0)
        {
            decimal lpa = decimalNetIncome / decimalNumberOfShares;
            decimal vpa = decimalShareholdersEquity / decimalNumberOfShares;

            // Graham's formula: Sqrt(22.5 * LPA * VPA)
            double result = Math.Sqrt(22.5 * (double)lpa * (double)vpa);
            return (decimal)result;
        }
        return 0; // Or throw an exception for invalid data
    }

    public decimal CalculateMaximumPrice(string dividendYield, string currentPrice)
    {
        CultureInfo culture = new CultureInfo("pt-BR");

        string convertedDividendYield = dividendYield.Replace("%", string.Empty).Trim();
        string convertedCotacao = currentPrice.Replace("%", string.Empty).Trim();

        if (decimal.TryParse(convertedDividendYield, NumberStyles.Number, culture, out decimal decimalDividendYield) &&
            decimal.TryParse(convertedCotacao, NumberStyles.Number, culture, out decimal decimalCurrentPrice))
        {
            // Convert the percentage to its decimal equivalent.
            decimal dividendYieldDecimal = decimalDividendYield / 100M;
            decimal valuePerShare = decimalCurrentPrice * dividendYieldDecimal;
            // Bazin's method uses a minimum expected return of 6% (0.06).
            return valuePerShare / 0.06M;
        }
        return 0;
    }

    // Example method to get data from Fundamentus
    public async Task<FundamentusDto?> GetFundamentusDataAsync(string ticket)
    {
        //I'm getting the HTML because the API doesn't allow me to get the data directly in JSON format.
        //It is a paid API and I don't want to pay for it now.
        var resultHTML = await fundamentusHttpClient.GetFundamentusDataAsync(ticket);

        HtmlDocument page = new();
        page.LoadHtml(resultHTML);

        var details = GetTableByLabel(page, ticket);//where i can get the name...
        var marketValue = GetTableByLabel(page, "Valor de mercado");//It is fixed because i get it from the html label...
        var valuation = GetTableByLabel(page, "Indicadores fundamentalistas");//It is fixed because i get it from the html label...
        var patrimony = GetTableByLabel(page, "Dados Balanço Patrimonial");//It is fixed because i get it from the html label...
        var profits = GetTableByLabel(page, "Lucro Líquido");//It is fixed because i get it from the html label...

        var allData = details
            .Concat(marketValue)
            .Concat(valuation)
            .Concat(patrimony)
            .Concat(profits)
            .ToDictionary(k => k.Key, v => v.Value);

        if (allData.Count == 0)
            return null;

        var dto = allData.MapToFundamentusDto();

        return dto;
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
        return [];
    }
}