using BeckAcoesApp.Application.Dtos;
using BecksAcoesApp.ViewModels;

namespace BecksAcoesApp.Converters;

internal static class ApplicationDtoToViewModel
{
    internal static FundamentusDetailsViewModel ToFundamentusDetailsViewModel(this FundamentusDto fundamentusDto)
    { 
        return new FundamentusDetailsViewModel
        {
            Papel = fundamentusDto.Papel,
            CotacaoAtual = decimal.TryParse(fundamentusDto.Cotacao, out var cotacao) ? cotacao : 0,
            DividendYield = fundamentusDto.DivYield
        };
    }
}