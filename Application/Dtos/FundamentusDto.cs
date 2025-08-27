using System.Text.Json.Serialization;

namespace BeckAcoesApp.Application.Dtos;

public sealed class FundamentusDto
{
    #region formerProperties

    //[JsonPropertyName("papel")]
    //public string Papel { get; set; } = string.Empty;

    //[JsonPropertyName("cotacao")]
    //public string Cotacao { get; set; } = string.Empty;

    //[JsonPropertyName("pl")]
    //public string Pl { get; set; } = string.Empty;

    //[JsonPropertyName("pvp")]
    //public string Pvp { get; set; } = string.Empty;

    //[JsonPropertyName("psr")]
    //public string Psr { get; set; } = string.Empty;

    //[JsonPropertyName("divYield")]
    //public string DivYield { get; set; } = string.Empty;

    //[JsonPropertyName("pAtivo")]
    //public string PAtivo { get; set; } = string.Empty;

    //[JsonPropertyName("pCapGiro")]
    //public string PCapGiro { get; set; } = string.Empty;

    //[JsonPropertyName("pebit")]
    //public string Pebit { get; set; } = string.Empty;

    //[JsonPropertyName("pAtivCircLiq")]
    //public string PAtivCircLiq { get; set; } = string.Empty;

    //[JsonPropertyName("evebit")]
    //public string Evebit { get; set; } = string.Empty;

    //[JsonPropertyName("evebitda")]
    //public string Evebitda { get; set; } = string.Empty;

    //[JsonPropertyName("mrgEbit")]
    //public string MrgEbit { get; set; } = string.Empty;

    //[JsonPropertyName("mrgLiq")]
    //public string MrgLiq { get; set; } = string.Empty;

    //[JsonPropertyName("liqCorr")]
    //public string LiqCorr { get; set; } = string.Empty;

    //[JsonPropertyName("roic")]
    //public string Roic { get; set; } = string.Empty;

    //[JsonPropertyName("roe")]
    //public string Roe { get; set; } = string.Empty;

    //[JsonPropertyName("liq2meses")]
    //public string Liq2Meses { get; set; } = string.Empty;

    //[JsonPropertyName("patrimLiq")]
    //public string PatrimLiq { get; set; } = string.Empty;

    //[JsonPropertyName("divBrutPatrim")]
    //public string DivBrutPatrim { get; set; } = string.Empty;

    //[JsonPropertyName("crescRec5a")]
    //public string CrescRec5a { get; set; } = string.Empty;

    #endregion formerProperties

    public string Papel { get; set; } = string.Empty;
    public string Cotacao { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public string DataUltCot { get; set; } = string.Empty;
    public string Empresa { get; set; } = string.Empty;
    public string Min52Sem { get; set; } = string.Empty;
    public string Setor { get; set; } = string.Empty;
    public string Max52Sem { get; set; } = string.Empty;
    public string Subsetor { get; set; } = string.Empty;
    public string VolMed2m { get; set; } = string.Empty;
    public string ValorDeMercado { get; set; } = string.Empty;
    public string UltBalançoProcessado { get; set; } = string.Empty;
    public string ValorDaFirma { get; set; } = string.Empty;
    public string NroAcoes { get; set; } = string.Empty;
    public string PL { get; set; } = string.Empty;
    public string PVP { get; set; } = string.Empty;
    public string PEBIT { get; set; } = string.Empty;
    public string PSR { get; set; } = string.Empty;
    public string PAtivos { get; set; } = string.Empty;
    public string PCapGiro { get; set; } = string.Empty;
    public string PAtivCircLiq { get; set; } = string.Empty;
    public string DivYield { get; set; } = string.Empty;
    public string EVEBITDA { get; set; } = string.Empty;
    public string EVEBIT { get; set; } = string.Empty;
    public string CresRec5a { get; set; } = string.Empty;
    public string Ativo { get; set; } = string.Empty;
    public string DivBruta { get; set; } = string.Empty;
    public string Disponibilidades { get; set; } = string.Empty;
    public string DivLiquida { get; set; } = string.Empty;
    public string AtivoCirculante { get; set; } = string.Empty;
    public string PatrimLiq { get; set; } = string.Empty;
    public string ReceitaLiquida { get; set; } = string.Empty;
    public string EBIT { get; set; } = string.Empty;
    public string LucroLiquido { get; set; } = string.Empty;
}