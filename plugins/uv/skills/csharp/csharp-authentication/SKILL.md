---
name: 'csharp-authentication'
description: 'Set credentials on the Upvest Investment API C# SDK. Load before configuring any scheme, or when a call comes back 401 or 403. The setter name won''t tell you it can drop or double the `Credentials` suffix, that required values are positional on the model''s constructor and throw `ArgumentNullException` there rather than on the first call, or which getter reads the model back. Also load before any request reaches Upvest - every request, the token request included, needs an HTTP message signature, and `.HttpSignature(...)` silently replaces any HttpClient you configured.'
---

# Authenticating an APIMatic C# SDK client

The API spec decides which schemes exist. Set every scheme your endpoints need **while you build the
client** — a built client has no credential setter (see **csharp-client-initialization**).

## Finding which schemes this SDK accepts

1. `UpvestInvestmentApiClient.cs` — the credential setters on `UpvestInvestmentApiClient.Builder` are **the source of
   truth**.
2. `Authentication/` — one `{Scheme}Manager.cs` per scheme, holding the manager and the
   `sealed class {Scheme}Model`, plus an `I{Scheme}Credentials.cs`. A **custom** scheme that declares no
   parameters has no model and no client setter at all — see [reference.md](reference.md).
3. `doc/auth/*.md` — a page per scheme listing each parameter with its type, setter and getter.

**Never derive the setter name — take it from the Authentication table in csharp-getting-started, which
resolves it.** The usual form is the emitted scheme name with `Credentials` appended
(`.BasicAuthCredentials(...)`), and a grant-named scheme sometimes doubles the word
(`.Oauth2ClientCredentialsCredentials(...)`). The suffix is dropped **only** when the SDK has exactly one
scheme *and* that scheme is an OAuth 2 grant type (`.ClientCredentialsAuth(...)`, interface
`IClientCredentialsAuth`). Ending in `Auth` is **not** the trigger — a `BasicAuth` scheme alongside others
still emits `.BasicAuthCredentials(...)` and `IBasicAuthCredentials`. Read the `Builder`'s method list in
`UpvestInvestmentApiClient.cs` and the file names under `Authentication/`; the shapes to recognise are in
[reference.md](reference.md).

> **This SDK's schemes, setters, credential models and required arguments are already resolved** in the
> *This SDK's map* table at the top of **csharp-getting-started**. Read that first — everything below is
> the shape and the traps, not the names.

## Which schemes an operation needs

Grep the operation's request builder for `WithAuth` / `WithOrAuth` / `WithAndAuth`.

> **The string inside is the *spec's* security-scheme name, not the emitted C# name.** It is a key into
> the `AuthManagers` dictionary built in `UpvestInvestmentApiClient.cs`, so it may have no setter, no
> `{Scheme}Model`, no `Authentication/` file and no `doc/auth/` page under that spelling — a spec scheme
> called `BearerAuth` can be wired to a manager the SDK exposes as `ClientCredentialsAuth`. Resolve the
> key through that `.AuthManagers(...)` dictionary to get the scheme in the **Authentication** table
> above; do not match it against setter names. On a single-scheme SDK the mismatch is harmless, but with
> two or more it is the difference between configuring the right credential and the wrong one.

- **no match anywhere in the controller folder** — no operation requires a scheme. A credential-less
  client works, and anything you configure never reaches the wire.
- **`WithAndAuth(a, b)`** — configure both, or the call throws `AuthValidationException` while the
  request is built.
- **`WithOrAuth(...)`** — any one alternative satisfies it. The SDK applies the **first *satisfiable*
  alternative in listed order** and sends only that one: an earlier alternative you left unconfigured is
  skipped, and a later one you did configure is used. So if the choice matters (different rate limits,
  different audit identity), configure exactly the one you intend, and read the argument order to see which
  wins when you configure more than one.

  > **An OR group can mix the two failure kinds, and then the OAuth one governs.** Where the group lists
  > both a parameter-registering scheme and an OAuth grant, a client with **no** credentials does not throw
  > `AuthValidationException` — the OAuth alternative passes up-front validation, so what you get is a token
  > request through your handler and then an `ApiException` (see the callout below). Reading the group as
  > "two header schemes are listed, so it must fail before the wire" is wrong. Check whether any alternative
  > in the group is a grant before predicting the failure.
- **`.AddAndGroup(g => g.Add("a").Add("b"))` nested inside a `WithOrAuth`** — an AND requirement that does
  **not** appear as `WithAndAuth`. Some SDKs express every AND this way, so grepping only for `WithAndAuth`
  concludes "no operation needs two schemes at once" when several do. Read the whole auth expression, not
  just its opening call.

## The shape: build a model, hand it to the client builder

```csharp
using UpvestInvestmentApi.Standard;
using UpvestInvestmentApi.Standard.Authentication;

var client = new UpvestInvestmentApiClient.Builder()
    .{Scheme}Credentials(
        new {Scheme}Model.Builder(
                System.Environment.GetEnvironmentVariable("API_CLIENT_ID"),      // required: positional
                System.Environment.GetEnvironmentVariable("API_CLIENT_SECRET"))  // null => ArgumentNullException
            .{OptionalParam}(...)                                                // optional: fluent setter
            .Build())
    .Build();
```

- **Required credentials are positional on the `Builder`'s constructor**, each assigned
  `?? throw new ArgumentNullException(...)` — an unset environment variable fails there, not on the
  first call. Every parameter also gets a same-named fluent setter; the optional ones are the only
  ones **not** null-checked.
- `{Scheme}Model` is `sealed` with an `internal` constructor and `internal` properties: the `Builder`
  is the only way to make one; `model.ToBuilder()` derives a variant.
- Write `System.Environment` in full — `using UpvestInvestmentApi.Standard;` also brings the SDK's own
  `Environment` enum into scope, so with `System` imported a bare `Environment` is ambiguous.

> **`Build()` drops an unconfigured scheme silently.** The client `Builder` seeds every scheme with an
> empty model, then replaces any whose required values are still `null` with `null` — no exception, no
> log. `client.{Scheme}Model == null` is the in-SDK signal — assert on it at startup.
>
> **How the first call then fails depends on the scheme kind, and the two are not interchangeable:**
>
> - **Schemes that register a required wire parameter** — custom header, custom query, basic, static
>   bearer — fail *before the request leaves*, throwing
>   `APIMatic.Core.Types.Sdk.Exceptions.AuthValidationException` with a message naming each missing
>   parameter. It derives from `ArgumentNullException`, **not** `ApiException`, so an `ApiException` catch
>   never sees it, and no HTTP request is made — a stub handler records **zero** calls.
> - **OAuth 2 grant schemes register nothing outside their `Apply()`**, so the up-front validation finds
>   nothing missing and **always passes** — there is no `AuthValidationException` on this path at all. What
>   happens instead depends entirely on **how the token endpoint answers**, and a real `POST` to it has
>   already travelled through your handler by then. Three outcomes, all reachable with empty credentials:
>   - **The token call succeeds** — the SDK caches the token and your call goes out authenticated. A
>     credential-less client therefore **succeeds** against a stub that answers the token request, which is
>     what a stubbed test normally does. No exception, and two recorded requests.
>   - **It returns 2xx but the token has no usable expiry** — `UpvestInvestmentApi.Standard.Exceptions.ApiException`,
>     message `OAuth token is expired. A valid token is needed to make API calls.`, `HttpContext == null`,
>     `ResponseCode == -1`, one recorded request.
>   - **It returns an error** (what a real server does with empty credentials) —
>     `OauthProviderException`, a typed subclass of `ApiException` carrying the provider's own
>     `ResponseCode` and a real `HttpContext`.
>
>   All three are caught by `catch (ApiException)`. So do **not** write a test asserting "a client with no
>   credentials throws": against a stub that answers the token request it does not. Assert on the outcome
>   you actually stubbed.
>
> Getting this backwards is the most common way a stubbed test goes wrong: against an OAuth scheme a
> credential-less client produces one unexplained extra request and an exception type you did not expect.
> Check which kind you have — `{Scheme}Manager` overriding `Apply` with a `FetchToken`/`IsTokenExpired`
> pair is a grant; one that sets its header in the constructor is not.

## Basic auth

```csharp
.{Scheme}Credentials(new {Scheme}Model.Builder(username, password).Build())
```

Sends `Authorization: Basic <base64(username:password)>`, encoded with `Encoding.ASCII` — non-ASCII
credentials are **mangled rather than rejected**.

## API key — header or query parameter

```csharp
.{Scheme}Credentials(new {Scheme}Model.Builder(apiKey).Build())
```

Placement and wire name are fixed in the manager's constructor and never appear in your code. A scheme
can take **more than one** parameter — the `Builder` constructor's arity is the answer.

## Bearer / access token

**Check the manager before assuming this is a static token.** A scheme named `BearerToken` or
`BearerAuth` may be either:

- **A static token** — one required `Builder` parameter, the token itself. The manager sets
  `Authorization: Bearer <token>` in its constructor and does nothing else: it never fetches or
  refreshes, so build a new client when the token changes.
- **An OAuth client-credentials grant wearing a bearer name** — the `Builder` then takes **two**
  parameters (`oAuthClientId`, `oAuthClientSecret`), and the manager overrides `Apply` and exposes
  `FetchToken`/`FetchTokenAsync`/`IsTokenExpired`. It acquires and refreshes on its own; treat it as
  the client-credentials section below.

**The `Builder` constructor's arity tells you which** — one argument or two. Passing one to a
two-argument constructor is `CS7036`.

## OAuth 2.0 — client credentials

**This manager drives the exchange itself**: given a client id and secret it acquires a token on the
first call that needs the scheme, caches it, and re-acquires when that one expires. Other grants leave
it to you, exposing `FetchToken`/`RefreshToken` or a `BuildAuthorizationUrl` you drive yourself — **the
manager that overrides `Apply` is the one that refreshes on its own**, so read the manager file.

```csharp
.{Scheme}Credentials(
    new {Scheme}Model.Builder(
            System.Environment.GetEnvironmentVariable("API_OAUTH_CLIENT_ID"),
            System.Environment.GetEnvironmentVariable("API_OAUTH_CLIENT_SECRET"))
        .OauthClockSkew(TimeSpan.FromSeconds(30))       // a TimeSpan, not a number of seconds
        .OauthOnTokenUpdate(token => SaveToken(token))  // fires on every refresh — persist here
        .OauthTokenProvider(async (manager, current) => // supply a stored token instead of fetching
            LoadToken() ?? await manager.FetchTokenAsync())
        .Build())
```

Those three setters plus `OauthToken` are emitted on every client-credentials model; the credential
parameters come from the spec, so confirm the `Builder`'s names in the manager file. **`OauthScopes` is
not among them unless the spec declared scopes on this grant** — usually only the authorization-code
one does. Where it exists it takes `List<{ScopesEnum}>`, a generated `[EnumMember]`-mapped enum in
`UpvestInvestmentApi.Standard.Models` — **pass its members, never raw strings**. The scopes themselves are the
`Scopes` table in that grant's `doc/auth/*.md` page; `doc/controllers/{group}.md` names the scheme an
operation requires but never its scopes.

Two traps, with the full lifecycle, in [reference.md](reference.md): a **`null` `Expiry` counts as
expired**, so persist the expiry or every restart re-fetches; and
`client.{Scheme}Credentials.IsTokenExpired()` reads **only the seed token passed to `.OauthToken(...)`**,
never the one the manager fetched and is sending, so it is not the health check it looks like.

## HTTP message signatures — required on every request

Upvest refuses any request without an HTTP message signature, **including the OAuth token request**.
A valid token alone gets every call refused with `401`. Everything below is read from the SDK at tag
`0.0.5` — `Http/Signature/HttpMessageSigner.cs`, `UpvestHttpMessageSigner.cs`,
`SigningHttpMessageHandler.cs`, `HttpSignatureCredentials.cs`, `doc/http-signatures.md` — not from the
draft standard, whose ECDSA encoding Upvest does **not** accept.

### Pick the route first — the two do not combine

| You need… | Route |
| --- | --- |
| the environment's own URL (`Environment.Production` = `https://sandbox.upvest.co`, `Environment.Environment2` = `https://api.upvest.co`) and no custom `HttpClient` | **A — `.HttpSignature(...)`** |
| any other host (a configured base URL, mock, proxy, gateway), **or** your own `HttpClient` / `DelegatingHandler` for any reason | **B — sign in your own `DelegatingHandler`** |

**Why they do not combine:** when `.HttpSignature(...)` is set, `Builder.Build()` *replaces* the
`HttpClientConfig` instance with its own
`new HttpClient(new SigningHttpMessageHandler(signer, new HttpClientHandler()))`. Your `HttpClient`, its
handlers and any base-URL rewrite are dropped **silently** — the calls are signed but go to the
environment URL. The SDK's `SigningHttpMessageHandler` and signer are `internal`, so you cannot chain
them into your own pipeline either. Setting both is never right.

### Route A — the SDK signs

```csharp
using UpvestInvestmentApi.Standard;
using UpvestInvestmentApi.Standard.Authentication;
using UpvestInvestmentApi.Standard.Http.Signature;

var signing = HttpSignatureCredentials.FromFile(
    keyId: keyId,                                   // the key ID registered at Upvest
    privateKeyPath: privateKeyPemPath,
    privateKeyPassphrase: passphrase);              // null if the key is not encrypted

var client = new UpvestInvestmentApiClient.Builder()
    .ClientCredentialsAuth(new ClientCredentialsAuthModel.Builder(clientId, clientSecret)
        .OauthScopes(scopes).Build())
    .HttpSignature(signing)                         // signs every request, the token request included
    .Environment(Environment.Production)
    .Build();
```

- `new HttpSignatureCredentials(keyId, privateKeyPem, privateKeyPassphrase)` takes PEM text instead of a path.
- `HttpSignatureCredentials.FromEnvironment()` reads `UPVEST_API_KEY_ID` (required), exactly one of
  `UPVEST_API_HTTP_SIGN_PRIVATE_KEY_FILENAME` / `_PRIVATE_KEY` / `_PRIVATE_KEY_BASE64` (read in that order),
  `UPVEST_API_HTTP_SIGN_PRIVATE_KEY_PASSPHRASE` and `UPVEST_API_CLIENT_ID`, and returns **`null`** when they
  are unset — check for it.
- The credentials own the key and are `IDisposable`: keep one alive for the client's lifetime.
- `upvest-client-id` defaults to the OAuth client ID.
- `UPVEST_SIGNATURE_DEBUG=1` makes the SDK's handler print each signed request to stderr.

### Route B — sign in your own `DelegatingHandler`

Reproduce exactly what the SDK's signer does. For each outgoing request, **after** any URL rewrite (the
signature covers the path that is actually sent):

1. If `content-type` is `application/json` with a charset, **drop the charset**.
2. Set on the request: `accept: application/json` unless it already is `application/json` or
   `application/pdf`; `upvest-api-version: 1` if absent; `upvest-client-id: <client id>` if absent;
   `date` = now (RFC 1123); and **only when there is a body** `content-digest: sha-512=:<base64 SHA-512 of
   the body bytes>:` and `content-length`.
3. **Covered components**: `@method` (upper case), `@path` (`/` if empty), `@query` **only if the URL has
   one** (with its leading `?`), then **every request and content header** lower-cased **except** names
   starting with `cf-`, `cdn-`, `cookie`, `x-`, `priority`, `upvest-signature`, `sec-`, `user-agent`,
   `accept-encoding`, `connection`, `host`, `expect`, `te`, `transfer-encoding`. `authorization` **is**
   covered — so the token request (which has none) and API calls differ.
4. **Parameters**: `("<k1>" "<k2>" …);keyid="<key id>";nonce="<new GUID>";created=<unix s>;expires=<created + 10>`.
5. **Signature base**: one line `"<name>": <value>` per covered component, `\n`-separated, then
   `"@signature-params": <parameters>` with no trailing newline. UTF-8.
6. **Sign** with ECDSA over **SHA-512** and encode **DER** (`DSASignatureFormat.Rfc3279DerSequence`) — the
   raw `r‖s` form is refused — then base64.
7. Add `signature-input: sig1=<parameters>`, `signature: sig1=:<base64>:`, and **last, not covered**,
   `upvest-signature-version: 15`.

The order of components is yours; it only has to be the same in `signature-input` and in the base.

```csharp
public sealed class UpvestSigningHandler : DelegatingHandler
{
    static readonly string[] Ignored = { "cf-", "cdn-", "cookie", "x-", "priority", "upvest-signature", "sec-",
        "user-agent", "accept-encoding", "connection", "host", "expect", "te", "transfer-encoding" };
    readonly ECDsa _key; readonly string _keyId, _clientId; readonly Uri _baseUrl;

    public UpvestSigningHandler(ECDsa key, string keyId, string clientId, Uri baseUrl, HttpMessageHandler inner)
        : base(inner) { _key = key; _keyId = keyId; _clientId = clientId; _baseUrl = baseUrl; }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage req, CancellationToken ct)
    {
        req.RequestUri = new Uri(_baseUrl, req.RequestUri!.PathAndQuery);   // rewrite FIRST; base URL without a path
        if (req.Content?.Headers.ContentType is { MediaType: "application/json" } ctype) ctype.CharSet = null;
        byte[]? body = req.Content is null ? null : await req.Content.ReadAsByteArrayAsync(ct);

        var accept = req.Headers.Accept.ToString();
        if (accept != "application/json" && accept != "application/pdf") { req.Headers.Accept.Clear(); req.Headers.Accept.ParseAdd("application/json"); }
        if (!req.Headers.Contains("upvest-api-version")) req.Headers.TryAddWithoutValidation("upvest-api-version", "1");
        if (!req.Headers.Contains("upvest-client-id")) req.Headers.TryAddWithoutValidation("upvest-client-id", _clientId);
        var now = DateTimeOffset.UtcNow; req.Headers.Date = now;
        if (body is { Length: > 0 })
        {
            req.Content!.Headers.Remove("content-digest");
            req.Content.Headers.TryAddWithoutValidation("content-digest", "sha-512=:" + Convert.ToBase64String(SHA512.HashData(body)) + ":");
            req.Content.Headers.ContentLength = body.Length;
        }

        var comps = new List<(string Name, string Value)> { ("@method", req.Method.Method.ToUpperInvariant()),
            ("@path", string.IsNullOrEmpty(req.RequestUri.AbsolutePath) ? "/" : req.RequestUri.AbsolutePath) };
        if (req.RequestUri.Query.Length > 1) comps.Add(("@query", req.RequestUri.Query));
        IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers = req.Headers;
        if (req.Content is not null) headers = headers.Concat(req.Content.Headers);
        foreach (var h in headers)
        {
            var name = h.Key.ToLowerInvariant();
            if (!Ignored.Any(p => name.StartsWith(p, StringComparison.Ordinal))) comps.Add((name, string.Join(", ", h.Value)));
        }

        long created = now.ToUnixTimeSeconds();
        string sigParams = "(" + string.Join(" ", comps.Select(c => $"\"{c.Name}\""))
            + $");keyid=\"{_keyId}\";nonce=\"{Guid.NewGuid()}\";created={created};expires={created + 10}";
        var sigBase = string.Join("\n", comps.Select(c => $"\"{c.Name}\": {c.Value}")) + "\n\"@signature-params\": " + sigParams;
        byte[] sig = _key.SignData(Encoding.UTF8.GetBytes(sigBase), HashAlgorithmName.SHA512, DSASignatureFormat.Rfc3279DerSequence);

        req.Headers.TryAddWithoutValidation("signature-input", "sig1=" + sigParams);
        req.Headers.TryAddWithoutValidation("signature", "sig1=:" + Convert.ToBase64String(sig) + ":");
        req.Headers.TryAddWithoutValidation("upvest-signature-version", "15");
        return await base.SendAsync(req, ct);
    }
}
```

Wire it **instead of** `.HttpSignature(...)`, through the client's `HttpClientConfig`; the SDK's OAuth
token request goes through the same `HttpClient`, so it is signed too:

```csharp
var key = UpvestKeys.LoadEcPrivateKey(File.ReadAllText(privateKeyPemPath), passphrase);
var http = new HttpClient(new UpvestSigningHandler(key, keyId, clientId, new Uri(baseUrl), new HttpClientHandler()));

var client = new UpvestInvestmentApiClient.Builder()
    .ClientCredentialsAuth(new ClientCredentialsAuthModel.Builder(clientId, clientSecret).OauthScopes(scopes).Build())
    .HttpClientConfig(c => c.HttpClientInstance(http))   // do NOT also call .HttpSignature(...)
    .Build();
```

**Loading the key.** Upvest's key setup produces an EC key encrypted the legacy OpenSSL way: a
`-----BEGIN EC PRIVATE KEY-----` block with `Proc-Type: 4,ENCRYPTED` and `DEK-Info: AES-256-CBC,…`
headers. `ECDsa.ImportFromEncryptedPem` **rejects that format** ("No supported key formats were
found"), because it reads only PKCS#8. The SDK's own reader (`PemKeyReader`) handles it but is
`internal`. This loader handles all three formats and was verified against the live sandbox:

```csharp
using System.Security.Cryptography;
using System.Text;

public static class UpvestKeys
{
    public static ECDsa LoadEcPrivateKey(string pem, string? passphrase)
    {
        var ec = ECDsa.Create();
        if (!pem.Contains("Proc-Type: 4,ENCRYPTED", StringComparison.Ordinal))
        {
            if (pem.Contains("BEGIN ENCRYPTED PRIVATE KEY")) ec.ImportFromEncryptedPem(pem, passphrase);   // PKCS#8, encrypted
            else ec.ImportFromPem(pem);                                                                  // SEC1 or PKCS#8, plain
            return ec;
        }
        // SEC1 encrypted the legacy OpenSSL way (`openssl ec -aes256`), which ImportFromEncryptedPem rejects.
        var lines = pem.Split('\n').Select(l => l.Trim()).ToList();
        var dek = lines.First(l => l.StartsWith("DEK-Info:"))["DEK-Info:".Length..].Trim().Split(',');
        if (dek[0] != "AES-256-CBC") throw new NotSupportedException("DEK-Info " + dek[0]);
        byte[] iv = Convert.FromHexString(dek[1]);
        byte[] data = Convert.FromBase64String(string.Concat(lines.Where(l => l.Length > 0 && !l.StartsWith("-----") && !l.Contains(':'))));
        byte[] pw = Encoding.UTF8.GetBytes(passphrase ?? ""), salt = iv[..8];
        byte[] d1 = MD5.HashData([.. pw, .. salt]), d2 = MD5.HashData([.. d1, .. pw, .. salt]);   // OpenSSL EVP_BytesToKey, MD5
        using var aes = Aes.Create();
        aes.Key = [.. d1, .. d2];
        ec.ImportECPrivateKey(aes.DecryptCbc(data, iv), out _);
        return ec;
    }
}
```

The alternative is to convert the key once to PKCS#8 (`openssl pkcs8 -topk8 -v2 aes-256-cbc -in key.pem
-out key.p8.pem`) and use `ImportFromEncryptedPem` directly. Route A needs neither, because
`HttpSignatureCredentials.FromFile` reads all three formats.

If calls come back `401 Signature mismatch`, compare your base string with the SDK's for the same
request: run route A once against the sandbox with `UPVEST_SIGNATURE_DEBUG=1`.

## Reading credentials back off the client

| Property | Type | What it gives you |
| --- | --- | --- |
| `client.{Scheme}Credentials` — **or bare `client.{Scheme}`, matching whatever the setter is called** | `I{Scheme}Credentials` or bare `I{Scheme}` | the auth manager behind its interface — **never `null`**, configured or not |
| `client.{Scheme}Model` | `{Scheme}Model` | the model you supplied — `null` if `Build()` discarded it |

`I{Scheme}Credentials` exposes a getter for each **credential value** plus an `Equals(...)` overload; a
client-credentials grant adds `FetchToken`, `FetchTokenAsync` and `IsTokenExpired`.

> **Some values you set through a fluent setter on the model's `Builder` are not readable back through
> either route** — check the interface rather than assuming either way. Credential-shaped values usually
> *are* there (an `OauthToken` or `OauthScopes` you supplied typically appears on the interface);
> the tuning knobs and callbacks are not. `OauthClockSkew` is the one that catches people: it is a
> `TimeSpan?` value, not a callback,
> and it is absent from `I{Scheme}Credentials` on every SDK — `credentials.OauthClockSkew` is
> **`CS1061`**. The `client.{Scheme}Model` route fails identically, because the model's properties are
> `internal`: that getter is a null-check, never a readable value. The only route is a downcast to the
> concrete manager, `(({Scheme}Manager)client.{Scheme}Credentials).OauthClockSkew` — and that compiles
> only when the manager class is `public`, which varies. The same applies to the token-provider and
> on-token-update callbacks. **If you need to assert your own configuration at startup, keep the value you
> passed in rather than trying to read it back.**

## Combining schemes — the operation decides, not the client

There is no combined credentials object: set **every** scheme the operations you call require, and each
operation composes what it needs. **Two operations in the same controller can differ**, and one may
need no credentials at all — read the operation in `UpvestInvestmentApi.Standard.Apis`, or the
**Authentication** section of `doc/controllers/{group}.md`.

## More schemes

For OAuth 2 **authorization code (3-legged)**, **resource-owner password**, **implicit**, **custom
auth** and **no-auth**, the AND/OR composition rules, and binding credentials from configuration, see
[reference.md](reference.md).

## Notes

- **Rotating credentials means a new client.** `client.ToBuilder()` carries the credential models over,
  so `client.ToBuilder().{Scheme}Credentials(newModel).Build()` is the rotation — but it does **not**
  carry the HTTP client configuration; see **csharp-client-initialization**.
- `Equals(...)` on a credentials interface is a **credential-comparison overload**, not
  `object.Equals`; it dereferences its argument, so `null` throws.
- **A missing credential is not an `ApiException` — unless the scheme is an OAuth grant.** For
  parameter-registering schemes it is `AuthValidationException`, an `ArgumentNullException`, raised before
  the request leaves; for OAuth grants it is an `ApiException` raised from the token request. See the
  callout under **The shape** above, and **csharp-error-handling** for where each failure class lands.

## Next

- Step 3, make your first call → **csharp-calling-endpoints**
- A call that comes back `401` or `403` → **csharp-error-handling**
