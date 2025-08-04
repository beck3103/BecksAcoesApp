using System.Text.Json.Serialization;

namespace Infra.Http.Dtos;

public sealed class FundamentusDto
{
    [JsonPropertyName("papel")]
    public string Papel { get; private set; } = string.Empty;

    [JsonPropertyName("cotacao")]
    public string Cotacao { get; private set; } = string.Empty;

    [JsonPropertyName("pl")]
    public string Pl { get; private set; } = string.Empty;

    [JsonPropertyName("pvp")]
    public string Pvp { get; private set; } = string.Empty;

    [JsonPropertyName("psr")]
    public string Psr { get; private set; } = string.Empty;

    [JsonPropertyName("divYield")]
    public string DivYield { get; private set; } = string.Empty;

    [JsonPropertyName("pAtivo")]
    public string PAtivo { get; private set; } = string.Empty;

    [JsonPropertyName("pCapGiro")]
    public string PCapGiro { get; private set; } = string.Empty;

    [JsonPropertyName("pebit")]
    public string Pebit { get; private set; } = string.Empty;

    [JsonPropertyName("pAtivCircLiq")]
    public string PAtivCircLiq { get; private set; } = string.Empty;

    [JsonPropertyName("evebit")]
    public string Evebit { get; private set; } = string.Empty;

    [JsonPropertyName("evebitda")]
    public string Evebitda { get; private set; } = string.Empty;

    [JsonPropertyName("mrgebit")]
    public string MrgEbit { get; private set; } = string.Empty;

    [JsonPropertyName("mrgliq")]
    public string MrgLiq { get; private set; } = string.Empty;

    [JsonPropertyName("liqCorr")]
    public string LiqCorr { get; private set; } = string.Empty;

    [JsonPropertyName("roic")]
    public string Roic { get; private set; } = string.Empty;

    [JsonPropertyName("roe")]
    public string Roe { get; private set; } = string.Empty;

    [JsonPropertyName("liq2meses")]
    public string Liq2Meses { get; private set; } = string.Empty;

    [JsonPropertyName("patrimLiq")]
    public string PatrimLiq { get; private set; } = string.Empty;

    [JsonPropertyName("divBrutPatrim")]
    public string DivBrutPatrim { get; private set; } = string.Empty;

    [JsonPropertyName("crescRec5a")]
    public string CrescRec5a { get; private set; } = string.Empty;
}