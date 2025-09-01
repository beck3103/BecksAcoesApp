namespace BeckAcoesApp.Application.Dtos;

public sealed class FundamentusDto
{
    public string Ativo { get; set; } = string.Empty;

    /// <summary>
    /// Média de Volume em 2 Meses: representa o volume médio de negociações do ativo nos últimos dois meses.
    /// </summary>
    public string Average2MonthsVolume { get; set; } = string.Empty;

    /// <summary>
    /// Caixa e Equivalentes de Caixa: representa o valor total de dinheiro disponível e ativos líquidos que podem ser rapidamente convertidos em dinheiro.
    /// </summary>
    public string CashAndEquivalents { get; set; } = string.Empty;

    /// <summary>
    /// Nome da Empresa: representa o nome completo da empresa associada ao ativo.
    /// </summary>
    public string CompanyName { get; set; } = string.Empty;

    /// <summary>
    /// Ativo Circulante: representa os ativos que podem ser convertidos em caixa dentro de um ano, como caixa, contas a receber e estoques.
    /// </summary>
    public string CurrentAssets { get; set; } = string.Empty;

    /// <summary>
    /// Preço Atual: representa o valor atual de uma única cota do ativo no mercado.
    /// </summary>
    public string CurrentPrice { get; set; } = string.Empty;

    /// <summary>
    /// Dividend Yield: representa o rendimento de dividendos pagos nos últimos 12 meses em relação à cotação atual.
    /// </summary>
    public string DividendYield { get; set; } = string.Empty;

    /// <summary>
    /// Earnings Before Interest and Taxes (EBIT): representa o lucro operacional da empresa antes de considerar despesas com juros e impostos.
    /// </summary>
    public string EBIT { get; set; } = string.Empty;

    /// <summary>
    /// Valor da Empresa (Enterprise Value): representa o valor total da empresa, incluindo o valor de mercado das ações, dívidas e outros passivos, subtraindo o caixa e equivalentes de caixa.
    /// </summary>
    public string EnterpriseValue { get; set; } = string.Empty;

    /// <summary>
    /// Evalua o valor da empresa (Enterprise Value) dividido pelo EBIT (Earnings Before Interest and Taxes).
    /// </summary>
    public string EVToEBIT { get; set; } = string.Empty;

    /// <summary>
    /// EV/EBITDA: representa o valor da empresa (Enterprise Value) dividido pelo EBITDA (Earnings Before Interest, Taxes, Depreciation, and Amortization).
    /// </summary>
    public string EVToEBITDA { get; set; } = string.Empty;

    /// <summary>
    /// Dívida Bruta: representa o valor total das dívidas da empresa antes de considerar o caixa e equivalentes de caixa.
    /// </summary>
    public string GrossDebt { get; set; } = string.Empty;

    /// <summary>
    /// Data do Último Balanço Processado: representa a data em que o último balanço financeiro da empresa foi registrado.
    /// </summary>

    public string LastProcessedBalanceSheetDate { get; set; } = string.Empty;

    /// <summary>
    /// Data da Última Cotação: representa a data em que a cotação atual foi registrada.
    /// </summary>
    public string LastUpdatedDate { get; set; } = string.Empty;

    /// <summary>
    /// Capitalização de Mercado: representa o valor total de mercado das ações emitidas pela empresa.
    /// </summary>
    public string MarketCapitalization { get; set; } = string.Empty;

    /// <summary>
    /// Máxima dos Últimos 52 Semanas: representa o preço mais alto alcançado pela ação nos últimos 52 semanas (1 ano).
    /// </summary>
    public string Max52Week { get; set; } = string.Empty;

    /// <summary>
    /// Mínima dos Últimos 52 Semanas: representa o preço mais baixo alcançado pela ação nos últimos 52 semanas (1 ano).
    /// </summary>
    public string Min52Week { get; set; } = string.Empty;

    /// <summary>
    /// Dívida Líquida: representa o valor total das dívidas da empresa subtraído do caixa e equivalentes de caixa.
    /// </summary>
    public string NetDebt { get; set; } = string.Empty;

    /// <summary>
    /// Lucro Líquido: representa o lucro da empresa após a dedução de todas as despesas, impostos e custos.
    /// </summary>
    public string NetIncome { get; set; } = string.Empty;

    /// <summary>
    /// Receita Líquida: representa a receita total da empresa após deduzir impostos, devoluções e descontos.
    /// </summary>
    public string NetRevenue { get; set; } = string.Empty;

    /// <summary>
    /// Número de Ações: representa o total de ações emitidas pela empresa.
    /// </summary>
    public string NumberOfShares { get; set; } = string.Empty;

    /// <summary>
    /// Preço sobre Ativos (P/Ativos): representa o preço da ação dividido pelo valor contábil dos ativos por ação.
    /// </summary>
    public string PriceToAssets { get; set; } = string.Empty;

    /// <summary>
    /// Preço sobre Valor Patrimonial (P/VP): representa o preço da ação dividido pelo valor patrimonial por ação.
    /// </summary>
    public string PriceToBook { get; set; } = string.Empty;

    /// <summary>
    /// Preço sobre Lucro (P/L): representa o preço da ação dividido pelo lucro por ação.
    /// </summary>
    public string PriceToEarnings { get; set; } = string.Empty;

    /// <summary>
    /// Preço sobre EBIT (P/EBIT): representa o preço da ação dividido pelo EBIT (Earnings Before Interest and Taxes) por ação.
    /// </summary>
    public string PriceToEBIT { get; set; } = string.Empty;

    /// <summary>
    /// Preço sobre Ativo Circulante Líquido (P/Ativ Circ Liq): representa o preço da ação dividido pelo ativo circulante líquido por ação.
    /// </summary>
    public string PriceToNetTangibleAssets { get; set; } = string.Empty;

    /// <summary>
    /// Preço sobre Vendas (PSR): representa o preço da ação dividido pela receita líquida por ação.
    /// </summary>
    public string PriceToSales { get; set; } = string.Empty;

    /// <summary>
    /// Preço sobre Capital de Giro (P/Cap. Giro): representa o preço da ação dividido pelo capital de giro por ação.
    /// </summary>
    public string PriceToWorkingCapital { get; set; } = string.Empty;

    /// <summary>
    /// Crescimento da Receita nos Últimos 5 Anos: representa a taxa de crescimento anual composta da receita líquida da empresa nos últimos cinco anos.
    /// </summary>
    public string RevenueGrowth5y { get; set; } = string.Empty;

    /// <summary>
    /// Setor: representa o setor econômico ao qual a empresa pertence, como Tecnologia, Saúde, Financeiro, etc.
    /// </summary>
    public string Sector { get; set; } = string.Empty;

    /// <summary>
    /// Patrimônio Líquido: representa o valor residual dos ativos da empresa após a dedução de todas as suas dívidas e obrigações.
    /// </summary>
    public string ShareholdersEquity { get; set; } = string.Empty;

    /// <summary>
    /// Símbolo da Ação: representa o código (ticker) utilizado para identificar a ação ou ativo no mercado financeiro.
    /// </summary>
    public string StockSymbol { get; set; } = string.Empty;

    /// <summary>
    /// Tipo de Ação: representa a categoria ou classificação da ação, como ordinária (ON), preferencial (PN), units, etc.
    /// </summary>
    public string StockType { get; set; } = string.Empty;

    /// <summary>
    /// Subsetor: representa o subsetor econômico ao qual a empresa pertence, oferecendo uma classificação mais detalhada dentro do setor principal.
    /// </summary>
    public string Subsector { get; set; } = string.Empty;
}