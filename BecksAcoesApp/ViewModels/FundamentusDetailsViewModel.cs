namespace BecksAcoesApp.ViewModels;

internal sealed class FundamentusDetailsViewModel
{
    /// <summary>
    /// O código (ticker) da ação ou do ativo. Ex: PETR4, MGLU3.
    /// </summary>
    public string Papel { get; set; } = string.Empty;

    /// <summary>
    /// O valor atual de uma única cota do ativo no mercado.
    /// </summary>
    public decimal CotacaoAtual { get; set; }

    /// <summary>
    /// Dividend Yield: o rendimento de dividendos pagos nos últimos 12 meses em relação à cotação atual.
    /// </summary>
    public string DividendYield { get; set; } = string.Empty;

    /// <summary>
    /// P/L: Preço da ação dividido pelo Lucro por Ação.
    /// </summary>
    public string PrecoSobreLucro { get; set; } = string.Empty;

    /// <summary>
    /// P/VP: Preço da ação dividido pelo Valor Patrimonial por Ação.
    /// </summary>
    public string PrecoSobreValorPatrimonial { get; set; } = string.Empty;

    /// <summary>
    /// PSR: Price to Sales Ratio, ou Preço/Vendas. Preço da ação dividido pela Receita Líquida por Ação.
    /// </summary>
    public string PrecoSobreReceita { get; set; } = string.Empty;

    /// <summary>
    /// P/Ativo: Preço da ação dividido pelo valor dos Ativos Totais por ação.
    /// </summary>
    public string PrecoSobreAtivo { get; set; } = string.Empty;

    /// <summary>
    /// P/Cap. Giro: Preço da ação dividido pelo Capital de Giro por ação.
    /// </summary>
    public string PrecoSobreCapitalDeGiro { get; set; } = string.Empty;

    /// <summary>
    /// P/EBIT: Preço da ação dividido pelo EBIT (Lucro Antes de Juros e Impostos) por ação.
    /// </summary>
    public string PrecoSobreEbit { get; set; } = string.Empty;

    /// <summary>
    /// P/Ativ. Circ. Liq.: Preço da ação dividido pelo Ativo Circulante Líquido por ação.
    /// </summary>
    public string PrecoSobreAtivoCirculanteLiquido { get; set; } = string.Empty;

    /// <summary>
    /// EV/EBIT: Enterprise Value (Valor da Firma) dividido pelo EBIT.
    /// </summary>
    public string EnterpriseValueSobreEbit { get; set; } = string.Empty;

    /// <summary>
    /// EV/EBITDA: Enterprise Value (Valor da Firma) dividido pelo EBITDA (Lucro Antes de Juros, Impostos, Depreciação e Amortização).
    /// </summary>
    public string EnterpriseValueSobreEbitda { get; set; } = string.Empty;

    /// <summary>
    /// Margem EBIT: EBIT dividido pela Receita Líquida.
    /// </summary>
    public string MargemEbit { get; set; } = string.Empty;

    /// <summary>
    /// Margem Líquida: Lucro Líquido dividido pela Receita Líquida.
    /// </summary>
    public string MargemLiquida { get; set; } = string.Empty;

    /// <summary>
    /// Liquidez Corrente: Ativo Circulante dividido pelo Passivo Circulante.
    /// </summary>
    public string LiquidezCorrente { get; set; } = string.Empty;

    /// <summary>
    /// ROIC (Return on Invested Capital): Retorno sobre o Capital Investido.
    /// </summary>
    public string RetornoSobreCapitalInvestido { get; set; } = string.Empty;

    /// <summary>
    /// ROE (Return on Equity): Retorno sobre o Patrimônio Líquido.
    /// </summary>
    public string RetornoSobrePatrimonioLiquido { get; set; } = string.Empty;

    /// <summary>
    /// Volume médio de negociação dos últimos 2 meses.
    /// </summary>
    public string LiquidezMediaDoisMeses { get; set; } = string.Empty;

    /// <summary>
    /// O valor total do Patrimônio Líquido da empresa.
    /// </summary>
    public string PatrimonioLiquido { get; set; } = string.Empty;

    /// <summary>
    /// Dívida Bruta dividida pelo Patrimônio Líquido.
    /// </summary>
    public string DividaBrutaSobrePatrimonio { get; set; } = string.Empty;

    /// <summary>
    /// Crescimento da Receita nos últimos 5 anos (CAGR - Taxa de Crescimento Anual Composta).
    /// </summary>
    public string CrescimentoReceitaUltimosCincoAnos { get; set; } = string.Empty;

    public decimal PrecoTetoBazin { get; set; } = 0;

    public decimal PrecoJustoGraham { get; set; } = 0;
}