using BeckAcoesApp.Application.Dtos;
using BecksAcoesApp.ViewModels;
using System.Globalization;

namespace BecksAcoesApp.Converters;

internal static class ApplicationDtoToViewModel
{
    internal static FundamentusDetailsViewModel ToFundamentusDetailsViewModel(this FundamentusDto fundamentusDto, decimal precoJusto, decimal precoTeto)
    {
        string value = fundamentusDto.CurrentPrice;
        string normalizedValue = value.Replace(',', '.');

        return new FundamentusDetailsViewModel
        {
            Papel = fundamentusDto.StockSymbol,
            CotacaoAtual = decimal.TryParse(normalizedValue, CultureInfo.InvariantCulture, out var cotacao) ? cotacao : 0,
            DividendYield = fundamentusDto.DividendYield,
            PrecoSobreLucro = fundamentusDto.PriceToEarnings,
            PrecoSobreValorPatrimonial = fundamentusDto.PriceToBook,
            PrecoSobreReceita = fundamentusDto.PriceToSales,
            PrecoSobreAtivo = fundamentusDto.PriceToAssets,
            PrecoSobreCapitalDeGiro = fundamentusDto.PriceToWorkingCapital,
            PrecoSobreEbit = fundamentusDto.PriceToEBIT,
            PrecoSobreAtivoCirculanteLiquido = fundamentusDto.PriceToNetTangibleAssets,
            EnterpriseValueSobreEbit = fundamentusDto.EVToEBIT,
            EnterpriseValueSobreEbitda = fundamentusDto.EVToEBITDA,
            
            LiquidezMediaDoisMeses = fundamentusDto.Average2MonthsVolume,
            PatrimonioLiquido = fundamentusDto.EnterpriseValue,
            CrescimentoReceitaUltimosCincoAnos = fundamentusDto.RevenueGrowth5y,
            PrecoTetoBazin = precoTeto,
            PrecoJustoGraham = precoJusto
        };
    }
}