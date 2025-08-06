using System.Text.Json.Serialization;

namespace BeckAcoesApp.Application.Dtos;

public sealed class FundamentusDto
{
    public FundamentusDto()
    {
    }

    [JsonPropertyName("papel")]
    public string Papel { get; set; } = string.Empty;

    [JsonPropertyName("cotacao")]
    public string Cotacao { get; set; } = string.Empty;

    [JsonPropertyName("pl")]
    public string Pl { get; set; } = string.Empty;

    [JsonPropertyName("pvp")]
    public string Pvp { get; set; } = string.Empty;

    [JsonPropertyName("psr")]
    public string Psr { get; set; } = string.Empty;

    [JsonPropertyName("divYield")]
    public string DivYield { get; set; } = string.Empty;

    [JsonPropertyName("pAtivo")]
    public string PAtivo { get; set; } = string.Empty;

    [JsonPropertyName("pCapGiro")]
    public string PCapGiro { get; set; } = string.Empty;

    [JsonPropertyName("pebit")]
    public string Pebit { get; set; } = string.Empty;

    [JsonPropertyName("pAtivCircLiq")]
    public string PAtivCircLiq { get; set; } = string.Empty;

    [JsonPropertyName("evebit")]
    public string Evebit { get; set; } = string.Empty;

    [JsonPropertyName("evebitda")]
    public string Evebitda { get; set; } = string.Empty;

    [JsonPropertyName("mrgEbit")]
    public string MrgEbit { get; set; } = string.Empty;

    [JsonPropertyName("mrgLiq")]
    public string MrgLiq { get; set; } = string.Empty;

    [JsonPropertyName("liqCorr")]
    public string LiqCorr { get; set; } = string.Empty;

    [JsonPropertyName("roic")]
    public string Roic { get; set; } = string.Empty;

    [JsonPropertyName("roe")]
    public string Roe { get; set; } = string.Empty;

    [JsonPropertyName("liq2meses")]
    public string Liq2Meses { get; set; } = string.Empty;

    [JsonPropertyName("patrimLiq")]
    public string PatrimLiq { get; set; } = string.Empty;

    [JsonPropertyName("divBrutPatrim")]
    public string DivBrutPatrim { get; set; } = string.Empty;

    [JsonPropertyName("crescRec5a")]
    public string CrescRec5a { get; set; } = string.Empty;

    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(Papel) &&
               !string.IsNullOrWhiteSpace(Cotacao) &&
               !string.IsNullOrWhiteSpace(Pl) &&
               !string.IsNullOrWhiteSpace(Pvp) &&
               !string.IsNullOrWhiteSpace(Psr) &&
               !string.IsNullOrWhiteSpace(DivYield) &&
               !string.IsNullOrWhiteSpace(PAtivo) &&
               !string.IsNullOrWhiteSpace(PCapGiro) &&
               !string.IsNullOrWhiteSpace(Pebit) &&
               !string.IsNullOrWhiteSpace(PAtivCircLiq) &&
               !string.IsNullOrWhiteSpace(Evebit) &&
               !string.IsNullOrWhiteSpace(Evebitda) &&
               !string.IsNullOrWhiteSpace(MrgEbit) &&
               !string.IsNullOrWhiteSpace(MrgLiq) &&
               !string.IsNullOrWhiteSpace(LiqCorr) &&
               !string.IsNullOrWhiteSpace(Roic) &&
               !string.IsNullOrWhiteSpace(Roe) &&
               !string.IsNullOrWhiteSpace(Liq2Meses) &&
               !string.IsNullOrWhiteSpace(PatrimLiq) &&
               !string.IsNullOrWhiteSpace(DivBrutPatrim) &&
               !string.IsNullOrWhiteSpace(CrescRec5a);
    }
}