using System.Net.Http;
using UpvestInvestmentApi.Api;
using UpvestInvestmentApi.Core;
using UpvestInvestmentApi.Core.Configuration;
using UpvestInvestmentApi.Core.Logging;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi;

/// <summary>
/// Upvest Investment API.
/// </summary>
public sealed class UpvestInvestmentApiClient
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    public UpvestInvestmentApiClient(HttpClient httpClient, UpvestInvestmentApiClientOptions options)
    {
        _server = new Server(options.Environment, options.Server);
        var queryParameterFactory = new QueryParameterFactory([]);
        var templateParamsFactory = new TemplateParamsFactory([]);
        var urlFactory = new UriFactory(queryParameterFactory, templateParamsFactory);
        var httpStatusPolicy = new HttpStatusPolicy([]);
        var headersFactory = new HeadersFactory([
            new HeaderParam("User-Agent", "UpvestInvestmentApiClient/1.172.0 CSharp"),
            new HeaderParam("X-APIMatic-Lang", "CSharp"),
            new HeaderParam("X-APIMatic-Package-Version", "1.172.0"),
            new HeaderParam("X-APIMatic-Gen-Version", "4.0.0"),
            new HeaderParam("X-APIMatic-OS", RuntimeEnvironment.Os),
            new HeaderParam("X-APIMatic-Runtime", RuntimeEnvironment.Runtime),
        ]);
        var resiliencePipelineFactory = new ResiliencePipelineFactory(options.Retry, options.TimeProvider);
        var httpLogger = new HttpLogger(
            options.Logging.WithEnvironmentDefaults("UPVEST_INVESTMENT_API_LOG"),
            "UpvestInvestmentApiClient",
            options.TimeProvider);
        var responseContexts = new ResponseContextFactory(options.TimeProvider, options.StreamReadTimeout);
        _rawClient =
            new RawClient(
                httpClient,
                urlFactory,
                httpStatusPolicy,
                headersFactory,
                resiliencePipelineFactory,
                httpLogger,
                // Custom code: Upvest rejects unsigned requests; sign by default (see Signing/UpvestSigningDefaults.cs).
                UpvestInvestmentApi.Signing.UpvestSigningDefaults.WithSigning(options.Hooks),
                responseContexts);
        _auth = new AuthSchemes(options, _server, _rawClient);
    }

    /// <summary>
    /// All authentication related paths.
    /// </summary>
    public AccessTokens AccessTokens => field ??= new AccessTokens(_rawClient, _server);

    /// <summary>
    /// All account groups related paths
    /// </summary>
    public AccountGroups AccountGroups => field ??= new AccountGroups(_rawClient, _server, _auth);

    /// <summary>
    /// All accounts related paths
    /// </summary>
    public AccountsApi AccountsApi => field ??= new AccountsApi(_rawClient, _server, _auth);

    /// <summary>
    /// All Business Checks related paths.
    /// </summary>
    public BusinessChecks BusinessChecks => field ??= new BusinessChecks(_rawClient, _server, _auth);

    /// <summary>
    /// All Businesses related paths.
    /// </summary>
    public Businesses Businesses => field ??= new Businesses(_rawClient, _server, _auth);

    /// <summary>
    /// All cash balance transfer related paths
    /// </summary>
    public CashBalanceTransfers CashBalanceTransfers => field ??= new CashBalanceTransfers(_rawClient, _server, _auth);

    /// <summary>
    /// All cash balance related paths
    /// </summary>
    public CashBalances CashBalances => field ??= new CashBalances(_rawClient, _server, _auth);

    /// <summary>
    /// All credit fundings related paths
    /// </summary>
    public CreditFundings CreditFundings => field ??= new CreditFundings(_rawClient, _server, _auth);

    /// <summary>
    /// All direct debits related paths
    /// </summary>
    public DirectDebits DirectDebits => field ??= new DirectDebits(_rawClient, _server, _auth);

    /// <summary>
    /// All fees related paths.
    /// </summary>
    public Fees Fees => field ??= new Fees(_rawClient, _server, _auth);

    /// <summary>
    /// All fees configurations related paths.
    /// </summary>
    public FeesConfigurations FeesConfigurations => field ??= new FeesConfigurations(_rawClient, _server, _auth);

    /// <summary>
    /// All files API related paths.
    /// </summary>
    public Files Files => field ??= new Files(_rawClient, _server, _auth);

    /// <summary>
    /// ISA tax wrapper and transfer related paths.
    /// </summary>
    public Isa Isa => field ??= new Isa(_rawClient, _server, _auth);

    /// <summary>
    /// All instrument related paths.
    /// </summary>
    public Instruments Instruments => field ??= new Instruments(_rawClient, _server, _auth);

    /// <summary>
    /// All accounts liquidations related paths.
    /// </summary>
    public Liquidations Liquidations => field ??= new Liquidations(_rawClient, _server, _auth);

    /// <summary>
    /// All direct debit mandates related paths
    /// </summary>
    public Mandates Mandates => field ??= new Mandates(_rawClient, _server, _auth);

    /// <summary>
    /// All order related paths.
    /// </summary>
    public Orders Orders => field ??= new Orders(_rawClient, _server, _auth);

    /// <summary>
    /// All portfolios related paths.
    /// </summary>
    public Portfolios Portfolios => field ??= new Portfolios(_rawClient, _server, _auth);

    /// <summary>
    /// All portfolios rebalancing related paths.
    /// </summary>
    public PortfoliosRebalancing PortfoliosRebalancing =>
        field ??= new PortfoliosRebalancing(_rawClient, _server, _auth);

    /// <summary>
    /// All positions related paths.
    /// </summary>
    public Positions Positions => field ??= new Positions(_rawClient, _server, _auth);

    /// <summary>
    /// All price data related paths.
    /// </summary>
    public PriceData PriceData => field ??= new PriceData(_rawClient, _server, _auth);

    /// <summary>
    /// All reference account related paths
    /// </summary>
    public ReferenceAccounts ReferenceAccounts => field ??= new ReferenceAccounts(_rawClient, _server, _auth);

    /// <summary>
    /// All reports related paths.
    /// </summary>
    public Reports Reports => field ??= new Reports(_rawClient, _server, _auth);

    /// <summary>
    /// All accounts returns related paths.
    /// </summary>
    public Returns Returns => field ??= new Returns(_rawClient, _server, _auth);

    /// <summary>
    /// All Roles related paths.
    /// </summary>
    public Roles Roles => field ??= new Roles(_rawClient, _server, _auth);

    /// <summary>
    /// All savings plans related paths.
    /// </summary>
    public SavingsPlans SavingsPlans => field ??= new SavingsPlans(_rawClient, _server, _auth);

    /// <summary>
    /// All Securities Transfers related paths.
    /// </summary>
    public SecuritiesTransfers SecuritiesTransfers => field ??= new SecuritiesTransfers(_rawClient, _server, _auth);

    /// <summary>
    /// All tax exemptions related paths
    /// </summary>
    public TaxExemptions TaxExemptions => field ??= new TaxExemptions(_rawClient, _server, _auth);

    /// <summary>
    /// All tax residencies related paths.
    /// </summary>
    public TaxResidencies TaxResidencies => field ??= new TaxResidencies(_rawClient, _server, _auth);

    /// <summary>
    /// All test related paths.
    /// </summary>
    public Tests Tests => field ??= new Tests(_rawClient, _server, _auth);

    /// <summary>
    /// All top-ups related paths
    /// </summary>
    public TopUps TopUps => field ??= new TopUps(_rawClient, _server, _auth);

    /// <summary>
    /// All transaction fees configurations related paths.
    /// </summary>
    public TransactionFeesConfigurations TransactionFeesConfigurations =>
        field ??= new TransactionFeesConfigurations(_rawClient, _server, _auth);

    /// <summary>
    /// All transaction fees models related paths.
    /// </summary>
    public TransactionFeesModels TransactionFeesModels =>
        field ??= new TransactionFeesModels(_rawClient, _server, _auth);

    /// <summary>
    /// All transactions related paths.
    /// </summary>
    public Transactions Transactions => field ??= new Transactions(_rawClient, _server, _auth);

    /// <summary>
    /// All user checks related paths.
    /// </summary>
    public UserChecks UserChecks => field ??= new UserChecks(_rawClient, _server, _auth);

    /// <summary>
    /// All user identifiers related paths.
    /// </summary>
    public UserIdentifiers UserIdentifiers => field ??= new UserIdentifiers(_rawClient, _server, _auth);

    /// <summary>
    /// All user related paths.
    /// </summary>
    public Users Users => field ??= new Users(_rawClient, _server, _auth);

    /// <summary>
    /// All valuations related paths.
    /// </summary>
    public Valuations Valuations => field ??= new Valuations(_rawClient, _server, _auth);

    /// <summary>
    /// All virtual bank accounts related paths
    /// </summary>
    public VirtualBankAccounts VirtualBankAccounts => field ??= new VirtualBankAccounts(_rawClient, _server, _auth);

    /// <summary>
    /// All virtual cash balances related paths
    /// </summary>
    public VirtualCashBalances VirtualCashBalances => field ??= new VirtualCashBalances(_rawClient, _server, _auth);

    /// <summary>
    /// All webhook subscriptions related paths.
    /// </summary>
    public WebhookSubscriptions WebhookSubscriptions => field ??= new WebhookSubscriptions(_rawClient, _server, _auth);

    /// <summary>
    /// All withdrawals related paths
    /// </summary>
    public Withdrawals Withdrawals => field ??= new Withdrawals(_rawClient, _server, _auth);
}
