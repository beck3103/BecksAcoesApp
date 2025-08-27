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
            PrecoSobreLucro = fundamentusDto.PL,
            PrecoSobreValorPatrimonial = fundamentusDto.PVP,
            PrecoSobreReceita = fundamentusDto.PSR,
            PrecoSobreAtivo = fundamentusDto.PAtivos,
            PrecoSobreCapitalDeGiro = fundamentusDto.PCapGiro,
            PrecoSobreEbit = fundamentusDto.PEBIT,
            PrecoSobreAtivoCirculanteLiquido = fundamentusDto.PAtivCircLiq,
            EnterpriseValueSobreEbit = fundamentusDto.EVEBIT,
            EnterpriseValueSobreEbitda = fundamentusDto.EVEBITDA,
            MargemEbit = fundamentusDto.EBIT,//Verify
            LiquidezCorrente = fundamentusDto.EBIT,//Verify
            RetornoSobreCapitalInvestido = fundamentusDto.EBIT, //Verify
            RetornoSobrePatrimonioLiquido = fundamentusDto.EBIT, //Verify
            LiquidezMediaDoisMeses = fundamentusDto.EBIT,
            PatrimonioLiquido = fundamentusDto.PatrimLiq,
            DividaBrutaSobrePatrimonio = fundamentusDto.EBIT,//Verify
            CrescimentoReceitaUltimosCincoAnos = fundamentusDto.CresRec5a,
            PrecoTetoBazin = precoTeto,
            PrecoJustoGraham = precoJusto
        };
    }
}