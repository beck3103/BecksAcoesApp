namespace Infra.Http.Dtos;

public sealed class FundamentusDto
{
    public string Papel { get; private set; } = string.Empty;
    public decimal Cotacao { get; private set; }
    public decimal Pl { get; private set; }
    public decimal Pvp { get; private set; }
    public decimal Psr { get; private set; }
    public string DivYield { get; private set; } = string.Empty;
    public decimal PAtivo { get; private set; }
    public decimal PCapGiro { get; private set; }
    public decimal Pebit { get; private set; }
    public decimal PAtivCircLiq { get; private set; }
    public decimal Evebit { get; private set; }
    public decimal Evebitda { get; private set; }
    public string MrgEbit { get; private set; } = string.Empty;
    public string MrgLiq { get; private set; } = string.Empty;
    public decimal LiqCorr { get; private set; }
    public string Roic { get; private set; } = string.Empty;
    public string Roe { get; private set; } = string.Empty;
    public decimal Liq2Meses { get; private set; }
    public decimal PatrimLiq { get; private set; }
    public decimal DivBrutPatrim { get; private set; }
    public string CrescRec5a { get; private set; } = string.Empty;
}