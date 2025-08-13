using BeckAcoesApp.Application.Dtos;

namespace BeckAcoesApp.Application.Mappers;

internal static class FundamentusMapper
{
    internal static FundamentusDto? MapToFundamentusDto(this Dictionary<string, string> data)
    {
        if (data == null || data.Count == 0) return null;

        return new FundamentusDto
        {
            Papel = data.GetValueOrDefault("Papel") ?? string.Empty,
            Cotacao = data.GetValueOrDefault("Cotação") ?? string.Empty,
            Pl = data.GetValueOrDefault("P/L") ?? string.Empty,
            Pvp = data.GetValueOrDefault("P/VP") ?? string.Empty,
            Psr = data.GetValueOrDefault("PSR") ?? string.Empty,
            DivYield = data.GetValueOrDefault("Div.Yield") ?? string.Empty,
            PAtivo = data.GetValueOrDefault("P/Ativo") ?? string.Empty,
            PCapGiro = data.GetValueOrDefault("P/Cap.Giro") ?? string.Empty,
            Pebit = data.GetValueOrDefault("P/EBIT") ?? string.Empty,
            PAtivCircLiq = data.GetValueOrDefault("P/Ativ Circ.Liq") ?? string.Empty,
            Evebit = data.GetValueOrDefault("EV/EBIT") ?? string.Empty,
            Evebitda = data.GetValueOrDefault("EV/EBITDA") ?? string.Empty,
            MrgEbit = data.GetValueOrDefault("Mrg Ebit") ?? string.Empty,
            MrgLiq = data.GetValueOrDefault("Mrg. Líq.") ?? string.Empty,
            LiqCorr = data.GetValueOrDefault("Liq. Corr.") ?? string.Empty,
            Roic = data.GetValueOrDefault("ROIC") ?? string.Empty,
            Roe = data.GetValueOrDefault("ROE") ?? string.Empty,
            Liq2Meses = data.GetValueOrDefault("Liq.2meses") ?? string.Empty,
            PatrimLiq = data.GetValueOrDefault("Patrim. Líq") ?? string.Empty,
            DivBrutPatrim = data.GetValueOrDefault("Dív.Brut/ Patrim.") ?? string.Empty,
            CrescRec5a = data.GetValueOrDefault("Cresc. Rec.5a") ?? string.Empty
        };
    }
}