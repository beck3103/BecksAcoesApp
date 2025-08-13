using BeckAcoesApp.Application.Dtos;
using BecksAcoesApp.ViewModels;
using System.Globalization;

namespace BecksAcoesApp.Converters;

internal static class ApplicationDtoToViewModel
{
    internal static FundamentusDetailsViewModel ToFundamentusDetailsViewModel(this FundamentusDto fundamentusDto, decimal precoJusto, decimal precoTeto)
    {
        string value = fundamentusDto.Cotacao;
        string normalizedValue = value.Replace(',', '.');

        return new FundamentusDetailsViewModel
        {
            Papel = fundamentusDto.Papel,
            CotacaoAtual = decimal.TryParse(normalizedValue, CultureInfo.InvariantCulture, out var cotacao) ? cotacao : 0,
            DividendYield = fundamentusDto.DivYield,
            PrecoSobreLucro = fundamentusDto.Pl,
            PrecoSobreValorPatrimonial = fundamentusDto.Pvp,
            PrecoSobreReceita = fundamentusDto.Psr,
            PrecoSobreAtivo = fundamentusDto.PAtivo,
            PrecoSobreCapitalDeGiro = fundamentusDto.PCapGiro,
            PrecoSobreEbit = fundamentusDto.Pebit,
            PrecoSobreAtivoCirculanteLiquido = fundamentusDto.PAtivCircLiq,
            EnterpriseValueSobreEbit = fundamentusDto.Evebit,
            EnterpriseValueSobreEbitda = fundamentusDto.Evebitda,
            MargemEbit = fundamentusDto.MrgEbit,
            LiquidezCorrente = fundamentusDto.LiqCorr,
            RetornoSobreCapitalInvestido = fundamentusDto.Roic,
            RetornoSobrePatrimonioLiquido = fundamentusDto.Roe,
            LiquidezMediaDoisMeses = fundamentusDto.Liq2Meses,
            PatrimonioLiquido = fundamentusDto.PatrimLiq,
            DividaBrutaSobrePatrimonio = fundamentusDto.DivBrutPatrim,
            CrescimentoReceitaUltimosCincoAnos = fundamentusDto.CrescRec5a,
            PrecoTetoBazin = precoTeto,
            PrecoJustoGraham = precoJusto
        };
    }
}