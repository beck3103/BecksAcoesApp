using BeckAcoesApp.Application.Dtos;

namespace BeckAcoesApp.Application.Mappers;

internal static class FundamentusMapper
{
    internal static FundamentusDto? MapToFundamentusDto(this Dictionary<string, string> data)
    {
        if (data == null || data.Count == 0) return null;

        return new FundamentusDto
        {
            StockSymbol = data.GetValueOrDefault("Papel") ?? string.Empty,
            CurrentPrice = data.GetValueOrDefault("Cotação") ?? string.Empty,
            StockType = data.GetValueOrDefault("Tipo") ?? string.Empty,
            LastUpdatedDate = data.GetValueOrDefault("Data últ cot") ?? string.Empty,
            CompanyName = data.GetValueOrDefault("Empresa") ?? string.Empty,
            Min52Week = data.GetValueOrDefault("Min 52 sem") ?? string.Empty,
            Sector = data.GetValueOrDefault("Setor") ?? string.Empty,
            Max52Week = data.GetValueOrDefault("Max 52 sem") ?? string.Empty,
            Subsector = data.GetValueOrDefault("Subsetor") ?? string.Empty,
            Average2MonthsVolume = data.GetValueOrDefault("Vol $ méd (2m)") ?? string.Empty,
            MarketCapitalization = data.GetValueOrDefault("Valor de mercado") ?? string.Empty,
            LastProcessedBalanceSheetDate = data.GetValueOrDefault("Últ balanço processado") ?? string.Empty,
            EnterpriseValue = data.GetValueOrDefault("Valor da firma") ?? string.Empty,
            NumberOfShares = data.GetValueOrDefault("Nro. Ações") ?? string.Empty,
            PriceToEarnings = data.GetValueOrDefault("P/L") ?? string.Empty,
            PriceToBook = data.GetValueOrDefault("P/VP") ?? string.Empty,
            PriceToEBIT = data.GetValueOrDefault("P/EBIT") ?? string.Empty,
            PriceToSales = data.GetValueOrDefault("PSR") ?? string.Empty,
            PriceToAssets = data.GetValueOrDefault("P/Ativos") ?? string.Empty,
            PriceToWorkingCapital = data.GetValueOrDefault("P/Cap. Giro") ?? string.Empty,
            PriceToNetTangibleAssets = data.GetValueOrDefault("P/Ativ Circ Liq") ?? string.Empty,
            DividendYield = data.GetValueOrDefault("Div. Yield") ?? string.Empty,
            EVToEBITDA = data.GetValueOrDefault("EV / EBITDA") ?? string.Empty,
            EVToEBIT = data.GetValueOrDefault("EV / EBIT") ?? string.Empty,
            RevenueGrowth5y = data.GetValueOrDefault("Cres. Rec (5a)") ?? string.Empty,
            Ativo = data.GetValueOrDefault("Ativo") ?? string.Empty,
            GrossDebt = data.GetValueOrDefault("Dív. Bruta") ?? string.Empty,
            CashAndEquivalents = data.GetValueOrDefault("Disponibilidades") ?? string.Empty,
            NetDebt = data.GetValueOrDefault("Dív. Líquida") ?? string.Empty,
            CurrentAssets = data.GetValueOrDefault("Ativo Circulante") ?? string.Empty,
            ShareholdersEquity = data.GetValueOrDefault("Patrim. Líq") ?? string.Empty,
            NetRevenue = data.GetValueOrDefault("Receita Líquida") ?? string.Empty,
            EBIT = data.GetValueOrDefault("EBIT") ?? string.Empty,
            NetIncome = data.GetValueOrDefault("Lucro Líquido") ?? string.Empty
        };
    }
}