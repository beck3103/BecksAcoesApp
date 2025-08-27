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
            Tipo = data.GetValueOrDefault("Tipo") ?? string.Empty,
            DataUltCot = data.GetValueOrDefault("Data últ cot") ?? string.Empty,
            Empresa = data.GetValueOrDefault("Empresa") ?? string.Empty,
            Min52Sem = data.GetValueOrDefault("Min 52 sem") ?? string.Empty,
            Setor = data.GetValueOrDefault("Setor") ?? string.Empty,
            Max52Sem = data.GetValueOrDefault("Max 52 sem") ?? string.Empty,
            Subsetor = data.GetValueOrDefault("Subsetor") ?? string.Empty,
            VolMed2m = data.GetValueOrDefault("Vol $ méd (2m)") ?? string.Empty,
            ValorDeMercado = data.GetValueOrDefault("Valor de mercado") ?? string.Empty,
            UltBalançoProcessado = data.GetValueOrDefault("Últ balanço processado") ?? string.Empty,
            ValorDaFirma = data.GetValueOrDefault("Valor da firma") ?? string.Empty,
            NroAcoes = data.GetValueOrDefault("Nro. Ações") ?? string.Empty,
            PL = data.GetValueOrDefault("P/L") ?? string.Empty,
            PVP = data.GetValueOrDefault("P/VP") ?? string.Empty,
            PEBIT = data.GetValueOrDefault("P/EBIT") ?? string.Empty,
            PSR = data.GetValueOrDefault("PSR") ?? string.Empty,
            PAtivos = data.GetValueOrDefault("P/Ativos") ?? string.Empty,
            PCapGiro = data.GetValueOrDefault("P/Cap. Giro") ?? string.Empty,
            PAtivCircLiq = data.GetValueOrDefault("P/Ativ Circ Liq") ?? string.Empty,
            DivYield = data.GetValueOrDefault("Div. Yield") ?? string.Empty,
            EVEBITDA = data.GetValueOrDefault("EV / EBITDA") ?? string.Empty,
            EVEBIT = data.GetValueOrDefault("EV / EBIT") ?? string.Empty,
            CresRec5a = data.GetValueOrDefault("Cres. Rec (5a)") ?? string.Empty,
            Ativo = data.GetValueOrDefault("Ativo") ?? string.Empty,
            DivBruta = data.GetValueOrDefault("Dív. Bruta") ?? string.Empty,
            Disponibilidades = data.GetValueOrDefault("Disponibilidades") ?? string.Empty,
            DivLiquida = data.GetValueOrDefault("Dív. Líquida") ?? string.Empty,
            AtivoCirculante = data.GetValueOrDefault("Ativo Circulante") ?? string.Empty,
            PatrimLiq = data.GetValueOrDefault("Patrim. Líq") ?? string.Empty,
            ReceitaLiquida = data.GetValueOrDefault("Receita Líquida") ?? string.Empty,
            EBIT = data.GetValueOrDefault("EBIT") ?? string.Empty,
            LucroLiquido = data.GetValueOrDefault("Lucro Líquido") ?? string.Empty
        };
    }
}