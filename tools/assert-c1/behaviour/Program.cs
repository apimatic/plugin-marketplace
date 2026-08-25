// assert-c1, behavioural tier.
//
// The static tier reads source. This one RUNS the SDK, because several of the
// claims the dotnet-* skills make are only observable at runtime — how many
// times a handler is invoked, what ToString() actually returns, whether a fresh
// client refetches an OAuth token. Three of the worst defects found in these
// skills were invisible to source reading and obvious to a compiled probe.
//
// Build against the SDK under test:
//     dotnet run -c Release -p:SdkProject=<path-to-sdk>.csproj
// or, with no property, against the pinned NuGet package (see the .csproj).
//
// Exit status is 0 when every check passes.

using System.Diagnostics;
using System.Net;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayPalServerSdk;
using PayPalServerSdk.Core;
using PayPalServerSdk.Core.Authentication.OAuth2;
using PayPalServerSdk.Core.Configuration;
using PayPalServerSdk.Models.Enums;

var checks = new Checks();

// ---------------------------------------------------------------------------
// retry — the section that was wrong in four of five shipped plugins
// ---------------------------------------------------------------------------

checks.Run(
    "retry.post-not-resent-on-transport-fault",
    "A POST is never resent by the SDK — the method filter gates every trigger, "
    + "including a thrown HttpRequestException.",
    "dotnet-configuration-resilience § Notes; dotnet-testing § Notes",
    () =>
    {
        var handler = new CountingHandler(_ => throw new HttpRequestException("connection reset"));
        var client = NewClient(handler);
        ExpectThrow(() => client.Orders.CreateOrder(
            payPalMockResponse: null, payPalRequestId: null, payPalPartnerAttributionId: null,
            payPalClientMetadataId: null, payPalAuthAssertion: null, body: MinimalOrder(),
            ct: default).GetAwaiter().GetResult());
        return handler.Count == 1
            ? Ok($"1 send, as expected")
            : Fail($"{handler.Count} sends — the method filter is not gating the transport arm");
    });

checks.Run(
    "retry.get-retries-on-transport-fault",
    "A GET is retried up to MaxRetries extra times: 1 + 3 = 4 sends on the defaults.",
    "dotnet-configuration-resilience § defaults table and cost table",
    () =>
    {
        var handler = new CountingHandler(_ => throw new HttpRequestException("connection reset"));
        var client = NewClient(handler, o => o.Retry = RetryOptions.Default() with
        {
            Delay = TimeSpan.FromMilliseconds(1),
            MaxJitter = TimeSpan.Zero,
        });
        ExpectThrow(() => Get(client).GetAwaiter().GetResult());
        return handler.Count == 4
            ? Ok("4 sends (1 + MaxRetries)")
            : Fail($"{handler.Count} sends, expected 4");
    });

checks.Run(
    "retry.disabled-holds-at-one",
    "RetryOptions.Disabled() removes SDK-side resends entirely — and does not throw at "
    + "client construction, so there is no MaxRetries = 1 floor.",
    "dotnet-configuration-resilience § Making a write safe under retries, option 3",
    () =>
    {
        var handler = new CountingHandler(_ => throw new HttpRequestException("reset"));
        var client = NewClient(handler, o => o.Retry = RetryOptions.Disabled());
        ExpectThrow(() => Get(client).GetAwaiter().GetResult());
        return handler.Count == 1
            ? Ok("1 send with Disabled(), and construction did not throw")
            : Fail($"{handler.Count} sends, expected 1");
    });

checks.Run(
    "retry.timeout-surfaces-as-taskcanceled",
    "The caller never sees TimeoutRejectedException — it is translated to a "
    + "TaskCanceledException wrapping a TimeoutException.",
    "dotnet-configuration-resilience § Notes, 'You never catch TimeoutRejectedException'",
    () =>
    {
        var handler = new CountingHandler(async (_, ct) =>
        {
            await Task.Delay(TimeSpan.FromSeconds(5), ct).ConfigureAwait(false);
            return Json("{}");
        });
        var client = NewClient(handler, o => o.Retry = RetryOptions.Disabled() with
        {
            Timeout = TimeSpan.FromMilliseconds(50),
        });
        var ex = CatchAny(() => Get(client).GetAwaiter().GetResult());
        if (ex is not TaskCanceledException tce)
            return Fail($"caught {ex?.GetType().Name ?? "nothing"}, expected TaskCanceledException");
        return tce.InnerException is TimeoutException
            ? Ok("TaskCanceledException(inner: TimeoutException)")
            : Fail($"inner was {tce.InnerException?.GetType().Name ?? "null"}, expected TimeoutException");
    });

// ---------------------------------------------------------------------------
// enums — the ToString trap, and the case-insensitive known-value table
// ---------------------------------------------------------------------------

checks.Run(
    "enum.tostring-is-the-record-debug-form",
    "`.Value` and the implicit conversion give the wire value; ToString() and string "
    + "interpolation give the record debug form.",
    "dotnet-models § Enums, the ToString warning",
    () =>
    {
        var v = ApplePayPaymentDataType.Emv;
        string viaValue = v.Value;
        string viaImplicit = v;
        string viaInterp = $"{v}";
        string viaToString = v.ToString();

        if (viaValue != "EMV") return Fail($".Value gave '{viaValue}'");
        if (viaImplicit != "EMV") return Fail($"implicit gave '{viaImplicit}'");
        if (viaInterp == "EMV")
            return Fail("interpolation gave the wire value — the ToString warning is now WRONG "
                        + "and the skill must be updated");
        if (viaToString == "EMV")
            return Fail("ToString() gave the wire value — the warning is now WRONG");
        return Ok($".Value='EMV', interpolation='{viaInterp}'");
    });

checks.Run(
    "enum.plus-is-safe-on-string-enum-only",
    "`+` picks the implicit conversion on a string enum (wire value) but binds "
    + "string+object on an int enum (debug form).",
    "dotnet-models § Enums, the ToString warning",
    () =>
    {
        string s = "x" + ApplePayPaymentDataType.Emv;
        return s == "xEMV"
            ? Ok("string enum: 'xEMV'")
            : Fail($"string enum + gave '{s}', expected 'xEMV'");
    });

checks.Run(
    "enum.fromvalue-is-case-insensitive",
    "A case variant of a declared value is normalised to the declared constant; a value "
    + "matching nothing passes through with IsKnownValue() false.",
    "dotnet-models § Enums, the case-insensitivity paragraph",
    () =>
    {
        var lower = ApplePayPaymentDataType.FromValue("emv");
        if (lower.Value != "EMV")
            return Fail($"FromValue(\"emv\") gave '{lower.Value}', expected the declared 'EMV'");
        if (!lower.IsKnownValue())
            return Fail("a case variant did not resolve to a known value");
        var unknown = ApplePayPaymentDataType.FromValue("NOT_A_REAL_VALUE");
        if (unknown.IsKnownValue())
            return Fail("an unrecognised value reported IsKnownValue() true");
        return unknown.Value == "NOT_A_REAL_VALUE"
            ? Ok("case variant normalised; unknown passed through verbatim")
            : Fail($"unknown value was rewritten to '{unknown.Value}'");
    });

// ---------------------------------------------------------------------------
// dates — no converter on a model property
// ---------------------------------------------------------------------------

checks.Run(
    "models.datetimeoffset-uses-stj-default",
    "A DateTimeOffset model property carries no converter and round-trips as "
    + "System.Text.Json's default ISO-8601-with-offset.",
    "dotnet-models § Dates & numbers",
    () =>
    {
        var probe = new { when = new DateTimeOffset(2024, 6, 17, 15, 30, 45, TimeSpan.Zero) };
        var json = System.Text.Json.JsonSerializer.Serialize(probe);
        return json.Contains("2024-06-17T15:30:45+00:00")
            ? Ok("ISO-8601 with offset")
            : Fail($"serialized as {json} — check whether a converter is now attached");
    });

// ---------------------------------------------------------------------------
// client lifetime — the OAuth token cache lives on the client
// ---------------------------------------------------------------------------

checks.Run(
    "client.transient-refetches-token",
    "The OAuth token cache is an instance field reached through the client, so a "
    + "per-request client pays a token request on every call.",
    "dotnet-client-initialization § lifetime",
    () =>
    {
        int tokenPosts = 0;
        HttpResponseMessage Respond(HttpRequestMessage r)
        {
            if (r.RequestUri!.AbsolutePath.Contains("oauth2/token"))
            {
                Interlocked.Increment(ref tokenPosts);
                return Json("""{"access_token":"t","token_type":"Bearer","expires_in":3600}""");
            }
            return Json("""{"id":"o1"}""");
        }

        var shared = NewClient(new CountingHandler(Respond), WithOAuth);
        for (var i = 0; i < 3; i++)
            Swallow(() => Get(shared).GetAwaiter().GetResult());
        var sharedTokens = tokenPosts;

        tokenPosts = 0;
        for (var i = 0; i < 3; i++)
        {
            var fresh = NewClient(new CountingHandler(Respond), WithOAuth);
            Swallow(() => Get(fresh).GetAwaiter().GetResult());
        }

        return sharedTokens == 1 && tokenPosts == 3
            ? Ok($"shared client: {sharedTokens} token request; 3 fresh clients: {tokenPosts}")
            : Fail($"shared={sharedTokens} (expected 1), transient={tokenPosts} (expected 3)");

        static void WithOAuth(PayPalServerSdkClientOptions o) =>
            o.Oauth2 = new PayPalServerSdk.Core.Authentication.OAuth2.ClientCredentials
                .OAuth2ClientCredentials { ClientId = "id", ClientSecret = "secret" };
    });

checks.Run(
    "auth.no-expires-in-never-expires",
    "A token response without expires_in is never considered expired — only a 401 "
    + "replaces it.",
    "dotnet-authentication § Token caching & refresh, the expires_in warning",
    () =>
    {
        var token = System.Text.Json.JsonSerializer.Deserialize<OAuthToken>(
            """{"access_token":"t","token_type":"Bearer"}""")!;
        return !token.IsExpired(DateTimeOffset.UtcNow.AddYears(10))
            ? Ok("still not expired ten years on")
            : Fail("a token with no expires_in reported itself expired");
    });

// ---------------------------------------------------------------------------
// DI — logging is already on
// ---------------------------------------------------------------------------

checks.Run(
    "di.logger-factory-comes-from-container",
    "Add{Api}Client fills Logging.LoggerFactory from the container, so SDK request "
    + "logging is already on in any host.",
    "dotnet-configuration-resilience § Logging, the three-state table",
    () =>
    {
        var services = new ServiceCollection();
        services.AddLogging(b => b.AddProvider(new CapturingProvider(out var sink)));
        services.AddPayPalServerSdkClient(o => { });
        var provider = services.BuildServiceProvider();
        var factory = provider.GetService<ILoggerFactory>();
        return factory is not null
            ? Ok("the container supplies an ILoggerFactory for the extension to pick up")
            : Fail("no ILoggerFactory in a container that called AddLogging");
    });

return checks.Report();


// ---------------------------------------------------------------------------
// harness
// ---------------------------------------------------------------------------

static PayPalServerSdkClient NewClient(
    HttpMessageHandler handler, Action<PayPalServerSdkClientOptions>? configure = null)
{
    var options = new PayPalServerSdkClientOptions();
    configure?.Invoke(options);
    return new PayPalServerSdkClient(new HttpClient(handler), options);
}

// Written with named arguments on purpose: a positional call built from memory is
// exactly the mis-binding dotnet-calling-endpoints warns about, and the first draft of
// this file hit it.
static Task<PayPalServerSdk.Models.Order> Get(PayPalServerSdkClient client) =>
    client.Orders.GetOrder(
        id: "o1", fields: null, payPalMockResponse: null, payPalAuthAssertion: null,
        ct: default);

static PayPalServerSdk.Models.OrderRequest MinimalOrder() => new()
{
    Intent = CheckoutPaymentIntent.Capture,
    PurchaseUnits =
    [
        new PayPalServerSdk.Models.PurchaseUnitRequest
        {
            Amount = new PayPalServerSdk.Models.AmountWithBreakdown
            {
                CurrencyCode = "USD",
                Value = "1.00",
            },
        },
    ],
};

static HttpResponseMessage Json(string body) =>
    new(HttpStatusCode.OK) { Content = new StringContent(body, Encoding.UTF8, "application/json") };

static void ExpectThrow(Action a) { try { a(); } catch { } }
static void Swallow(Action a) { try { a(); } catch { } }
static Exception? CatchAny(Action a) { try { a(); return null; } catch (Exception e) { return e; } }

static (bool, string) Ok(string detail) => (true, detail);
static (bool, string) Fail(string detail) => (false, detail);

sealed class CountingHandler : HttpMessageHandler
{
    private readonly Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> _responder;
    private int _count;

    public CountingHandler(Func<HttpRequestMessage, HttpResponseMessage> responder)
        : this((r, _) => Task.FromResult(responder(r))) { }

    // The async overload matters for the timeout check: a handler that blocks the
    // thread returns an already-completed Task, so Polly's timeout strategy has
    // nothing to cancel and never fires.
    public CountingHandler(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> responder) =>
        _responder = responder;

    public int Count => _count;

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken ct)
    {
        Interlocked.Increment(ref _count);
        var response = await _responder(request, ct).ConfigureAwait(false);
        response.RequestMessage = request;   // real HttpClient sets this
        return response;
    }
}

sealed class CapturingProvider : ILoggerProvider
{
    public CapturingProvider(out List<string> sink) => sink = Lines;
    public List<string> Lines { get; } = new();
    public ILogger CreateLogger(string categoryName) => new Sink(Lines);
    public void Dispose() { }

    private sealed class Sink(List<string> lines) : ILogger
    {
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;
        public bool IsEnabled(LogLevel logLevel) => true;
        public void Log<TState>(LogLevel level, EventId id, TState state, Exception? ex,
                                Func<TState, Exception?, string> fmt) =>
            lines.Add(fmt(state, ex));
    }
}

sealed class Checks
{
    private int _failed, _total;

    public void Run(string id, string claim, string defends, Func<(bool ok, string detail)> body)
    {
        _total++;
        bool ok;
        string detail;
        try
        {
            (ok, detail) = body();
        }
        catch (Exception ex)
        {
            ok = false;
            detail = $"{ex.GetType().Name}: {ex.Message}";
        }

        if (ok)
        {
            Console.WriteLine($"ok   {id}  ({detail})");
            return;
        }

        _failed++;
        Console.WriteLine($"FAIL {id}");
        Console.WriteLine($"       claim: {claim}");
        Console.WriteLine($"     defends: {defends}");
        Console.WriteLine($"      result: {detail}");
    }

    public int Report()
    {
        Console.WriteLine();
        Console.WriteLine($"{_total} behavioural checks: {_total - _failed} passed, {_failed} failed");
        return _failed == 0 ? 0 : 1;
    }
}
