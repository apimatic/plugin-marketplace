# Reference

Every operation below is shown in its throwing form. On an error status it throws `ApiException<TError>` — the status code, headers, content type and the operation's error type, `RawError` (the raw body) when the spec declares none — and where an operation offers an `…AsResult` sibling, that sibling returns `ApiResult<TResponse, TError>` instead. A request that produces no usable response surfaces as `SdkConnectionException` or `SdkTimeoutException`, a body that does not match the documented response type as `ResponseDeserializationException`, and a required credential that is not configured, or one that cannot be applied, as `AuthSchemeException`; all of them derive from `SdkException` and name the failed call. See [README → Error Handling](README.md#error-handling).

> Source: [UpvestInvestmentApiClient](src/UpvestInvestmentApi/UpvestInvestmentApiClient.cs)

## AccessTokens

> Source: [AccessTokens](src/UpvestInvestmentApi/Api/AccessTokens.cs)

<details>
<summary><code>Task&lt;AuthAccessToken&gt; IssueToken(IssueTokenRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Get an access token to use with the API with specified scopes.

You should _always_ scope your access tokens. You get one for read-access and separate ones for updating, creating or deleting resources.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AccessTokens.IssueToken(new IssueTokenRequest
    {
        UpvestApiVersion = UpvestApiVersion._1,
        ClientId = Guid.Parse("363f3305-7ab0-4e82-a158-f9d382ad08b6"),
        ClientSecret = "WHIW1yic-ouct3sceh",
        GrantType = "client_credentials",
        Scope = "users:read",
    });
    // TODO: Handle 'response' of type AuthAccessToken
}
catch (ApiException<IssueTokenError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[IssueTokenRequest](src/UpvestInvestmentApi/Requests/AccessTokens/IssueTokenRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AuthAccessToken](src/UpvestInvestmentApi/Models/AuthAccessToken.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[IssueTokenError](src/UpvestInvestmentApi/Errors/IssueTokenError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## AccountGroups

> Source: [AccountGroups](src/UpvestInvestmentApi/Api/AccountGroups.cs)

<details>
<summary><code>Task AccountGroupClosure(AccountGroupClosureRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Initiates the closure of the account group specified by its ID.

Closure is a two-step process: the account group status changes to `CLOSING`, and once all preconditions are met it transitions to `CLOSED`. Subscribe to the `ACCOUNT_GROUP.CLOSING_INITIATED` and `ACCOUNT_GROUP.CLOSED` webhook events to track progress.

See the Closing accounts guide ([TOL](https://docs.upvest.co/products/tol/guides/accounts/accounts_close_accounts) / [BYOL](https://docs.upvest.co/products/byol/guides/accounts/accounts_close_accounts)) for preconditions and implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.AccountGroups.AccountGroupClosure(new AccountGroupClosureRequest
    {
        AccountGroupId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
}
catch (ApiException<AccountGroupClosureError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[AccountGroupClosureRequest](src/UpvestInvestmentApi/Requests/AccountGroups/AccountGroupClosureRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[AccountGroupClosureError](src/UpvestInvestmentApi/Errors/AccountGroupClosureError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AccountGroupCreateResponse&gt; CreateAccountGroup(CreateAccountGroupRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates an account group for a user or a business.

An account group aggregates the accounts within it for tax calculation and regulatory reporting purposes and holds positions in the form of cash; the official securities account number is assigned at account group level. The account group is created with status `PENDING_APPROVAL` and switches to `ACTIVE` once onboarding is complete.

See the Creating account groups guide ([TOL](https://docs.upvest.co/products/tol/guides/accounts/accounts_create_account_groups) / [BYOL](https://docs.upvest.co/products/byol/guides/accounts/accounts_create_account_groups)) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AccountGroups.CreateAccountGroup(new CreateAccountGroupRequest
    {
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new AccountGroupCreateUserRequest
        {
            UserId = Guid.Parse("413715f2-5401-4b97-8055-034a6b879f8c"),
            Type = Type13.Personal,
            SecuritiesAccountNumber = "12345689",
        },
    });
    // TODO: Handle 'response' of type AccountGroupCreateResponse
}
catch (ApiException<CreateAccountGroupError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateAccountGroupRequest](src/UpvestInvestmentApi/Requests/AccountGroups/CreateAccountGroupRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AccountGroupCreateResponse](src/UpvestInvestmentApi/Models/AnyOf/AccountGroupCreateResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateAccountGroupError](src/UpvestInvestmentApi/Errors/CreateAccountGroupError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AccountGroupsListResponse1&gt; ListAccountGroups(ListAccountGroupsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a paginated list of account groups.

Use the `offset` and `limit` query parameters to page through results; `meta.total_count` gives the total number of matching account groups. Both user and business account groups are returned.

See the Accounts overview ([TOL](https://docs.upvest.co/products/tol/guides/accounts/accounts_overview) / [BYOL](https://docs.upvest.co/products/byol/guides/accounts/accounts_overview) / [Omnibus](https://docs.upvest.co/products/omnibus/guides/accounts/accounts_overview)) for account group types and the account hierarchy.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AccountGroups.ListAccountGroups(new ListAccountGroupsRequest
    {
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type AccountGroupsListResponse1
}
catch (ApiException<ListAccountGroupsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListAccountGroupsRequest](src/UpvestInvestmentApi/Requests/AccountGroups/ListAccountGroupsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AccountGroupsListResponse1](src/UpvestInvestmentApi/Models/AccountGroupsListResponse1.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListAccountGroupsError](src/UpvestInvestmentApi/Errors/ListAccountGroupsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AccountGroupsListResponse2&gt; ListBusinessAccountGroups(ListBusinessAccountGroupsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Lists the account groups of a business specified by ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AccountGroups.ListBusinessAccountGroups(new ListBusinessAccountGroupsRequest
    {
        BusinessId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type AccountGroupsListResponse2
}
catch (ApiException<ListBusinessAccountGroupsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListBusinessAccountGroupsRequest](src/UpvestInvestmentApi/Requests/AccountGroups/ListBusinessAccountGroupsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AccountGroupsListResponse2](src/UpvestInvestmentApi/Models/AccountGroupsListResponse2.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListBusinessAccountGroupsError](src/UpvestInvestmentApi/Errors/ListBusinessAccountGroupsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AccountGroupsListResponse&gt; ListUserAccountGroups(ListUserAccountGroupsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Lists the account groups of a user specified by ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AccountGroups.ListUserAccountGroups(new ListUserAccountGroupsRequest
    {
        UserId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type AccountGroupsListResponse
}
catch (ApiException<ListUserAccountGroupsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListUserAccountGroupsRequest](src/UpvestInvestmentApi/Requests/AccountGroups/ListUserAccountGroupsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AccountGroupsListResponse](src/UpvestInvestmentApi/Models/AccountGroupsListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListUserAccountGroupsError](src/UpvestInvestmentApi/Errors/ListUserAccountGroupsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AccountGroupRetrieveResponse&gt; RetrieveAccountGroup(RetrieveAccountGroupRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the account group specified by its ID, including its type, status, and securities account number.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AccountGroups.RetrieveAccountGroup(new RetrieveAccountGroupRequest
    {
        AccountGroupId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type AccountGroupRetrieveResponse
}
catch (ApiException<RetrieveAccountGroupError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveAccountGroupRequest](src/UpvestInvestmentApi/Requests/AccountGroups/RetrieveAccountGroupRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AccountGroupRetrieveResponse](src/UpvestInvestmentApi/Models/AnyOf/AccountGroupRetrieveResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveAccountGroupError](src/UpvestInvestmentApi/Errors/RetrieveAccountGroupError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## AccountsApi

> Source: [AccountsApi](src/UpvestInvestmentApi/Api/AccountsApi.cs)

<details>
<summary><code>Task AccountClosure(AccountClosureRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Initiates the closure of the account specified by its ID.

Closure is a two-step process: the account status changes to `CLOSING`, and once all preconditions are met the account transitions to `CLOSED`. While in `CLOSING`, only sell orders and transfers of positions out of the account are permitted. Subscribe to the `ACCOUNT.CLOSING_INITIATED` and `ACCOUNT.CLOSED` webhook events to track progress.

See the Closing accounts guide ([TOL](https://docs.upvest.co/products/tol/guides/accounts/accounts_close_accounts) / [BYOL](https://docs.upvest.co/products/byol/guides/accounts/accounts_close_accounts)) for preconditions and implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.AccountsApi.AccountClosure(new AccountClosureRequest
    {
        AccountId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
}
catch (ApiException<AccountClosureError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[AccountClosureRequest](src/UpvestInvestmentApi/Requests/AccountsApi/AccountClosureRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[AccountClosureError](src/UpvestInvestmentApi/Errors/AccountClosureError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AccountCreateResponse&gt; CreateAccount(CreateAccountRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates an account for a user or a business within an existing account group.

The account is created with status `PENDING_APPROVAL` and switches to `ACTIVE` once the owner's onboarding is complete; subscribe to the `ACCOUNT.ACTIVATED` webhook event to be notified. An account cannot exist without an account group and holds positions in the form of units.

For a `JOINT` account group, `user_id` must be one of its 2 owners; either owner can be used. The account is shared by both owners and its `users` list both of them with type `OWNER`. A second owner whose `OWNER` role is still `PENDING` is not yet a member of the account group, and the request returns `404`.

See the Creating accounts guide ([TOL](https://docs.upvest.co/products/tol/guides/accounts/accounts_create_accounts) / [BYOL](https://docs.upvest.co/products/byol/guides/accounts/accounts_create_accounts)) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AccountsApi.CreateAccount(new CreateAccountRequest
    {
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new AccountCreateUserRequest
        {
            UserId = Guid.Parse("413715f2-5401-4b97-8055-034a6b879f8c"),
            AccountGroupId = Guid.Parse("fa2414ed-8d62-46fd-85ed-565a340c81d6"),
            Type = Type16.Trading,
            Name = "Main account",
        },
    });
    // TODO: Handle 'response' of type AccountCreateResponse
}
catch (ApiException<CreateAccountError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateAccountRequest](src/UpvestInvestmentApi/Requests/AccountsApi/CreateAccountRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AccountCreateResponse](src/UpvestInvestmentApi/Models/AnyOf/AccountCreateResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateAccountError](src/UpvestInvestmentApi/Errors/CreateAccountError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AccountsListResponse1&gt; ListAccounts(ListAccountsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a paginated list of accounts.

Use the `offset` and `limit` query parameters to page through results; `meta.total_count` gives the total number of matching accounts. Both user and business accounts are returned.

See the Accounts overview ([TOL](https://docs.upvest.co/products/tol/guides/accounts/accounts_overview) / [BYOL](https://docs.upvest.co/products/byol/guides/accounts/accounts_overview) / [Omnibus](https://docs.upvest.co/products/omnibus/guides/accounts/accounts_overview)) for account types and the account hierarchy.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AccountsApi.ListAccounts(new ListAccountsRequest
    {
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type AccountsListResponse1
}
catch (ApiException<ListAccountsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListAccountsRequest](src/UpvestInvestmentApi/Requests/AccountsApi/ListAccountsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AccountsListResponse1](src/UpvestInvestmentApi/Models/AccountsListResponse1.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListAccountsError](src/UpvestInvestmentApi/Errors/ListAccountsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AccountsListResponse2&gt; ListBusinessAccounts(ListBusinessAccountsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Lists the accounts of a business specified by ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AccountsApi.ListBusinessAccounts(new ListBusinessAccountsRequest
    {
        BusinessId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type AccountsListResponse2
}
catch (ApiException<ListBusinessAccountsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListBusinessAccountsRequest](src/UpvestInvestmentApi/Requests/AccountsApi/ListBusinessAccountsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AccountsListResponse2](src/UpvestInvestmentApi/Models/AccountsListResponse2.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListBusinessAccountsError](src/UpvestInvestmentApi/Errors/ListBusinessAccountsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AccountsListResponse&gt; ListUserAccounts(ListUserAccountsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Lists the accounts of a user specified by ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AccountsApi.ListUserAccounts(new ListUserAccountsRequest
    {
        UserId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type AccountsListResponse
}
catch (ApiException<ListUserAccountsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListUserAccountsRequest](src/UpvestInvestmentApi/Requests/AccountsApi/ListUserAccountsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AccountsListResponse](src/UpvestInvestmentApi/Models/AccountsListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListUserAccountsError](src/UpvestInvestmentApi/Errors/ListUserAccountsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AccountRetrieveResponse&gt; RetrieveAccount(RetrieveAccountRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the account specified by its ID, including its type, status, and the account group it belongs to.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AccountsApi.RetrieveAccount(new RetrieveAccountRequest
    {
        AccountId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type AccountRetrieveResponse
}
catch (ApiException<RetrieveAccountError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveAccountRequest](src/UpvestInvestmentApi/Requests/AccountsApi/RetrieveAccountRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AccountRetrieveResponse](src/UpvestInvestmentApi/Models/AnyOf/AccountRetrieveResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveAccountError](src/UpvestInvestmentApi/Errors/RetrieveAccountError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AccountUpdateResponse&gt; UpdateAccount(UpdateAccountRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Updates the account specified by its ID.

Only the account `name` can be updated. Returns the full updated account object.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.AccountsApi.UpdateAccount(new UpdateAccountRequest
    {
        AccountId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new AccountUpdateRequest { Name = "Main account" },
    });
    // TODO: Handle 'response' of type AccountUpdateResponse
}
catch (ApiException<UpdateAccountError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateAccountRequest](src/UpvestInvestmentApi/Requests/AccountsApi/UpdateAccountRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AccountUpdateResponse](src/UpvestInvestmentApi/Models/AnyOf/AccountUpdateResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[UpdateAccountError](src/UpvestInvestmentApi/Errors/UpdateAccountError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## BusinessChecks

> Source: [BusinessChecks](src/UpvestInvestmentApi/Api/BusinessChecks.cs)

<details>
<summary><code>Task&lt;BusinessCheckCreateResponse&gt; CreateBusinessCheck(CreateBusinessCheckRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates a new check for a business specified by ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.BusinessChecks.CreateBusinessCheck(new CreateBusinessCheckRequest
    {
        BusinessId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new BusinessCheckKnowYourBusinessCreateRequest
        {
            Type = "KYB",
            OriginallyConfirmedAt = DateTimeOffset.Parse("2020-08-24T14:15:22Z"),
            CheckConfirmedAt = DateTimeOffset.Parse("2024-08-24T14:15:22Z"),
            DataDownloadLink = "https://bucket.customer.com/por/kyb.zip",
        },
    });
    // TODO: Handle 'response' of type BusinessCheckCreateResponse
}
catch (ApiException<CreateBusinessCheckError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateBusinessCheckRequest](src/UpvestInvestmentApi/Requests/BusinessChecks/CreateBusinessCheckRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[BusinessCheckCreateResponse](src/UpvestInvestmentApi/Models/BusinessCheckCreateResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateBusinessCheckError](src/UpvestInvestmentApi/Errors/CreateBusinessCheckError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;BusinessCheckListResponse&gt; ListBusinessChecks(ListBusinessChecksRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Lists all checks for a business specified by ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.BusinessChecks.ListBusinessChecks(new ListBusinessChecksRequest
    {
        BusinessId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type BusinessCheckListResponse
}
catch (ApiException<ListBusinessChecksError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListBusinessChecksRequest](src/UpvestInvestmentApi/Requests/BusinessChecks/ListBusinessChecksRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[BusinessCheckListResponse](src/UpvestInvestmentApi/Models/BusinessCheckListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListBusinessChecksError](src/UpvestInvestmentApi/Errors/ListBusinessChecksError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;BusinessCheck&gt; RetrieveBusinessCheck(RetrieveBusinessCheckRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Retrieves a check for a business specified by its ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.BusinessChecks.RetrieveBusinessCheck(new RetrieveBusinessCheckRequest
    {
        BusinessId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        CheckId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type BusinessCheck
}
catch (ApiException<RetrieveBusinessCheckError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveBusinessCheckRequest](src/UpvestInvestmentApi/Requests/BusinessChecks/RetrieveBusinessCheckRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[BusinessCheck](src/UpvestInvestmentApi/Models/AnyOf/BusinessCheck.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveBusinessCheckError](src/UpvestInvestmentApi/Errors/RetrieveBusinessCheckError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Businesses

> Source: [Businesses](src/UpvestInvestmentApi/Api/Businesses.cs)

<details>
<summary><code>Task BusinessDataChange(BusinessDataChangeRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Requests a data change for a business specified by ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.Businesses.BusinessDataChange(new BusinessDataChangeRequest
    {
        BusinessId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new BusinessCompanyUpdateRequest { ContactEmail = "acme.corporation@example.com" },
    });
}
catch (ApiException<BusinessDataChangeError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[BusinessDataChangeRequest](src/UpvestInvestmentApi/Requests/Businesses/BusinessDataChangeRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[BusinessDataChangeError](src/UpvestInvestmentApi/Errors/BusinessDataChangeError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;BusinessCreateRequest1&gt; CreateBusiness(CreateBusinessRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates a business.

Supports both corporate and sole trader business types, each with a different set of required fields.

See the Business accounts guide ([TOL](https://docs.upvest.co/products/tol/guides/accounts/businesses_overview) / [BYOL](https://docs.upvest.co/products/byol/guides/accounts/businesses_overview)) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Businesses.CreateBusiness(new CreateBusinessRequest
    {
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new BusinessCompanyCreateRequest
        {
            ContactEmail = "acme.corporation@example.com",
            RegisteredAddress = new Address2
            {
                AddressLine1 = "110",
                AddressLine2 = "Schonhauser Allee",
                Postcode = "101110",
                Country = Country.De,
                State = "BE",
                City = "Berlin",
            },
            RegistrationNumber = "111221111",
            TaxInformation = new TaxInformation
            {
                TaxCountryCode = TaxCountryCode.De,
                TaxIdentificationType = TaxIdentificationType.Steuernummer,
                TaxIdentificationNumber = "12345678901",
                IsResidentInMultipleTaxJurisdictions = false,
                IsSubjectToFatca = false,
            },
            Identification = new Identification8
            {
                CompanyName = "Acme Corporation",
                IncorporationDate = "2000-10-10",
                DistrictCourt = "Berlin Charlottenburg",
                LegalDesignation = LegalDesignation.GesellschaftMitBeschraenkterHaftung,
                LegalEntityIdentifier = "213800K98H63P249S632",
                CommonReportingStandards = new CommonReportingStandards
                {
                    IsPassiveNonFinancialEntity = false,
                    IsFinancialInstitution = false,
                },
            },
            TermsAndConditions = new TermsAndConditions5
            {
                ConsentDocumentId = Guid.Parse("6a163d14-5b3d-48be-ac90-43314e96be71"),
                ConfirmedAt = DateTimeOffset.Parse("2024-10-24T14:14:22Z"),
            },
            DataPrivacyAndSharingAgreement = new DataPrivacyAndSharingAgreement5
            {
                ConsentDocumentId = Guid.Parse("fa2227c3-2b29-47e1-84da-996d09517edc"),
                ConfirmedAt = DateTimeOffset.Parse("2024-10-24T14:16:22Z"),
            },
        },
    });
    // TODO: Handle 'response' of type BusinessCreateRequest1
}
catch (ApiException<CreateBusinessError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateBusinessRequest](src/UpvestInvestmentApi/Requests/Businesses/CreateBusinessRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[BusinessCreateRequest1](src/UpvestInvestmentApi/Models/AnyOf/BusinessCreateRequest1.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateBusinessError](src/UpvestInvestmentApi/Errors/CreateBusinessError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;BusinessesListResponse&gt; ListBusinesses(ListBusinessesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a paginated list of all businesses.

Use `offset` and `limit` to paginate through results, and `sort`/`order` to control the ordering by `created_at` or `updated_at`.

See the Business accounts guide ([TOL](https://docs.upvest.co/products/tol/guides/accounts/businesses_overview) / [BYOL](https://docs.upvest.co/products/byol/guides/accounts/businesses_overview)) for business account types.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Businesses.ListBusinesses(new ListBusinessesRequest
    {
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type BusinessesListResponse
}
catch (ApiException<ListBusinessesError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListBusinessesRequest](src/UpvestInvestmentApi/Requests/Businesses/ListBusinessesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[BusinessesListResponse](src/UpvestInvestmentApi/Models/BusinessesListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListBusinessesError](src/UpvestInvestmentApi/Errors/ListBusinessesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;BusinessesResponse2&gt; RetrieveBusiness(RetrieveBusinessRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the business identified by `business_id`, including profile and status details

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Businesses.RetrieveBusiness(new RetrieveBusinessRequest
    {
        BusinessId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type BusinessesResponse2
}
catch (ApiException<RetrieveBusinessError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveBusinessRequest](src/UpvestInvestmentApi/Requests/Businesses/RetrieveBusinessRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[BusinessesResponse2](src/UpvestInvestmentApi/Models/AnyOf/BusinessesResponse2.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveBusinessError](src/UpvestInvestmentApi/Errors/RetrieveBusinessError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## CashBalanceTransfers

> Source: [CashBalanceTransfers](src/UpvestInvestmentApi/Api/CashBalanceTransfers.cs)

<details>
<summary><code>Task CancelCashBalanceTransfer(CancelCashBalanceTransferRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Cancels a cash balance transfer specified by its ID. It is only possible to cancel a transfer while it has the status `ISSUED`.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.CashBalanceTransfers.CancelCashBalanceTransfer(new CancelCashBalanceTransferRequest
    {
        CashBalanceTransferId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
}
catch (ApiException<CancelCashBalanceTransferError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CancelCashBalanceTransferRequest](src/UpvestInvestmentApi/Requests/CashBalanceTransfers/CancelCashBalanceTransferRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CancelCashBalanceTransferError](src/UpvestInvestmentApi/Errors/CancelCashBalanceTransferError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PaymentsCashBalanceTransfer&gt; CreateCashBalanceTransfer(CreateCashBalanceTransferRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Create an internal cash balance transfer between two account groups belonging to the same tenant. The cash leaves the source account group and arrives at the target account group as a single operation, with no external bank transfer. Only settled cash denominated in the same currency (EUR) can be transferred. Both account groups must be of the same type, and the type must be one of `PERSONAL`, `CHILD`, `BUSINESS`, or `JOINT`. Both account groups must have exactly the same owners: for a `JOINT` account group, the same two owners must hold both.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.CashBalanceTransfers.CreateCashBalanceTransfer(new CreateCashBalanceTransferRequest
    {
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new PaymentsCashBalanceTransferCreateRequest
        {
            SourceAccountGroupId = Guid.Parse("2596db3b-0d03-4651-9eda-970910479dfb"),
            TargetAccountGroupId = Guid.Parse("e56c14b3-8370-4c04-bc67-7092f7ec113c"),
            Amount = "200.00",
            Currency = Currency.Eur,
        },
    });
    // TODO: Handle 'response' of type PaymentsCashBalanceTransfer
}
catch (ApiException<CreateCashBalanceTransferError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateCashBalanceTransferRequest](src/UpvestInvestmentApi/Requests/CashBalanceTransfers/CreateCashBalanceTransferRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PaymentsCashBalanceTransfer](src/UpvestInvestmentApi/Models/PaymentsCashBalanceTransfer.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateCashBalanceTransferError](src/UpvestInvestmentApi/Errors/CreateCashBalanceTransferError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;BusinessCashBalanceTransfersListResponse&gt; ListBusinessCashBalanceTransfers(ListBusinessCashBalanceTransfersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the list of cash balance transfers of a business specified by ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.CashBalanceTransfers.ListBusinessCashBalanceTransfers(
        new ListBusinessCashBalanceTransfersRequest
        {
            BusinessId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
            Sort = Sort4.Id,
            UpvestApiVersion = UpvestApiVersion._1,
        });
    // TODO: Handle 'response' of type BusinessCashBalanceTransfersListResponse
}
catch (ApiException<ListBusinessCashBalanceTransfersError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListBusinessCashBalanceTransfersRequest](src/UpvestInvestmentApi/Requests/CashBalanceTransfers/ListBusinessCashBalanceTransfersRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[BusinessCashBalanceTransfersListResponse](src/UpvestInvestmentApi/Models/BusinessCashBalanceTransfersListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListBusinessCashBalanceTransfersError](src/UpvestInvestmentApi/Errors/ListBusinessCashBalanceTransfersError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CashBalanceTransfersListResponse&gt; ListCashBalanceTransfers(ListCashBalanceTransfersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a paginated list of all cash balance transfers initiated by the client, across all account groups and users.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.CashBalanceTransfers.ListCashBalanceTransfers(new ListCashBalanceTransfersRequest
    {
        Sort = Sort4.Id,
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type CashBalanceTransfersListResponse
}
catch (ApiException<ListCashBalanceTransfersError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListCashBalanceTransfersRequest](src/UpvestInvestmentApi/Requests/CashBalanceTransfers/ListCashBalanceTransfersRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CashBalanceTransfersListResponse](src/UpvestInvestmentApi/Models/CashBalanceTransfersListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListCashBalanceTransfersError](src/UpvestInvestmentApi/Errors/ListCashBalanceTransfersError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;UserCashBalanceTransfersListResponse&gt; ListUserCashBalanceTransfers(ListUserCashBalanceTransfersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the list of cash balance transfers of a user specified by ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.CashBalanceTransfers.ListUserCashBalanceTransfers(
        new ListUserCashBalanceTransfersRequest
        {
            UserId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
            Sort = Sort4.Id,
            UpvestApiVersion = UpvestApiVersion._1,
        });
    // TODO: Handle 'response' of type UserCashBalanceTransfersListResponse
}
catch (ApiException<ListUserCashBalanceTransfersError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListUserCashBalanceTransfersRequest](src/UpvestInvestmentApi/Requests/CashBalanceTransfers/ListUserCashBalanceTransfersRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[UserCashBalanceTransfersListResponse](src/UpvestInvestmentApi/Models/UserCashBalanceTransfersListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListUserCashBalanceTransfersError](src/UpvestInvestmentApi/Errors/ListUserCashBalanceTransfersError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PaymentsCashBalanceTransfer&gt; RetrieveCashBalanceTransfer(RetrieveCashBalanceTransferRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Retrieve a cash balance transfer by its ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.CashBalanceTransfers.RetrieveCashBalanceTransfer(new RetrieveCashBalanceTransferRequest
    {
        CashBalanceTransferId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type PaymentsCashBalanceTransfer
}
catch (ApiException<RetrieveCashBalanceTransferError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveCashBalanceTransferRequest](src/UpvestInvestmentApi/Requests/CashBalanceTransfers/RetrieveCashBalanceTransferRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PaymentsCashBalanceTransfer](src/UpvestInvestmentApi/Models/PaymentsCashBalanceTransfer.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveCashBalanceTransferError](src/UpvestInvestmentApi/Errors/RetrieveCashBalanceTransferError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## CashBalances

> Source: [CashBalances](src/UpvestInvestmentApi/Api/CashBalances.cs)

<details>
<summary><code>Task&lt;AccountGroupsPaymentsCashBalanceResponse&gt; RetrieveCashBalance(RetrieveCashBalanceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

**Deprecated.** Use `GET /account_groups/{account_group_id}/payments/cash_balances/{currency}` instead.

Returns the account group's cash balance.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.CashBalances.RetrieveCashBalance(new RetrieveCashBalanceRequest
    {
        AccountGroupId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type AccountGroupsPaymentsCashBalanceResponse
}
catch (ApiException<RetrieveCashBalanceError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveCashBalanceRequest](src/UpvestInvestmentApi/Requests/CashBalances/RetrieveCashBalanceRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AccountGroupsPaymentsCashBalanceResponse](src/UpvestInvestmentApi/Models/AccountGroupsPaymentsCashBalanceResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveCashBalanceError](src/UpvestInvestmentApi/Errors/RetrieveCashBalanceError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AccountGroupsPaymentsCashBalancesResponse&gt; RetrieveCashBalanceWithCurrency(RetrieveCashBalanceWithCurrencyRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the account group's cash balance for the given `currency`.

See the Cash balances guide ([TOL](https://docs.upvest.co/products/tol/guides/payments/cash_balances/cash_balances_retrieving) / [BYOL](https://docs.upvest.co/products/byol/guides/payments/cash_balances/cash_balances_retrieving)) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.CashBalances.RetrieveCashBalanceWithCurrency(new RetrieveCashBalanceWithCurrencyRequest
    {
        AccountGroupId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        Currency = Currency1.Eur,
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type AccountGroupsPaymentsCashBalancesResponse
}
catch (ApiException<RetrieveCashBalanceWithCurrencyError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveCashBalanceWithCurrencyRequest](src/UpvestInvestmentApi/Requests/CashBalances/RetrieveCashBalanceWithCurrencyRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AccountGroupsPaymentsCashBalancesResponse](src/UpvestInvestmentApi/Models/AccountGroupsPaymentsCashBalancesResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveCashBalanceWithCurrencyError](src/UpvestInvestmentApi/Errors/RetrieveCashBalanceWithCurrencyError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CashBalancesRetrieveResponse&gt; RetrieveCashBalances(RetrieveCashBalancesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the list of cash balances held by the account group.

See the Cash balances guide ([TOL](https://docs.upvest.co/products/tol/guides/payments/cash_balances/cash_balances_intro) / [BYOL](https://docs.upvest.co/products/byol/guides/payments/cash_balances/cash_balances_intro)) for how `balance`, `locked_for_trading`, `pending_settlement`, `available_for_withdrawal`, and `available_for_trading` relate to each other.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.CashBalances.RetrieveCashBalances(new RetrieveCashBalancesRequest
    {
        AccountGroupId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type CashBalancesRetrieveResponse
}
catch (ApiException<RetrieveCashBalancesError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveCashBalancesRequest](src/UpvestInvestmentApi/Requests/CashBalances/RetrieveCashBalancesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CashBalancesRetrieveResponse](src/UpvestInvestmentApi/Models/CashBalancesRetrieveResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveCashBalancesError](src/UpvestInvestmentApi/Errors/RetrieveCashBalancesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## CreditFundings

> Source: [CreditFundings](src/UpvestInvestmentApi/Api/CreditFundings.cs)

<details>
<summary><code>Task&lt;PaymentsCreditFundingsListResponse&gt; ListCreditFundings(ListCreditFundingsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a paginated list of credit fundings for the account group specified by its ID. A credit funding represents an incoming SEPA Credit Transfer that has been received and applied to the account group.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.CreditFundings.ListCreditFundings(new ListCreditFundingsRequest
    {
        AccountGroupId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        Sort = Sort9.CreatedAt,
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type PaymentsCreditFundingsListResponse
}
catch (ApiException<ListCreditFundingsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListCreditFundingsRequest](src/UpvestInvestmentApi/Requests/CreditFundings/ListCreditFundingsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PaymentsCreditFundingsListResponse](src/UpvestInvestmentApi/Models/PaymentsCreditFundingsListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListCreditFundingsError](src/UpvestInvestmentApi/Errors/ListCreditFundingsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PaymentsCreditFundingsResponse&gt; RetrieveCreditFunding(RetrieveCreditFundingRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the credit funding specified by its ID, including its status, cash amount, and counterparty details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.CreditFundings.RetrieveCreditFunding(new RetrieveCreditFundingRequest
    {
        CreditFundingId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type PaymentsCreditFundingsResponse
}
catch (ApiException<RetrieveCreditFundingError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveCreditFundingRequest](src/UpvestInvestmentApi/Requests/CreditFundings/RetrieveCreditFundingRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PaymentsCreditFundingsResponse](src/UpvestInvestmentApi/Models/PaymentsCreditFundingsResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveCreditFundingError](src/UpvestInvestmentApi/Errors/RetrieveCreditFundingError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AccountGroupsPaymentsCreditFundingDetailsResponse&gt; RetrieveFundingDetails(RetrieveFundingDetailsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the virtual bank account details needed to fund an account group via SEPA Credit Transfer. Clients should present these details to end users so they can initiate the bank transfer.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.CreditFundings.RetrieveFundingDetails(new RetrieveFundingDetailsRequest
    {
        AccountGroupId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type AccountGroupsPaymentsCreditFundingDetailsResponse
}
catch (ApiException<RetrieveFundingDetailsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveFundingDetailsRequest](src/UpvestInvestmentApi/Requests/CreditFundings/RetrieveFundingDetailsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AccountGroupsPaymentsCreditFundingDetailsResponse](src/UpvestInvestmentApi/Models/AccountGroupsPaymentsCreditFundingDetailsResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveFundingDetailsError](src/UpvestInvestmentApi/Errors/RetrieveFundingDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## DirectDebits

> Source: [DirectDebits](src/UpvestInvestmentApi/Api/DirectDebits.cs)

<details>
<summary><code>Task&lt;PaymentsDirectDebitsResponse&gt; CreateDirectDebit(CreateDirectDebitRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Trigger a direct debit.

**Deprecation notice:** The `user_id` field is deprecated, optional, and will be removed in a future version. For business account direct debits, ownership is determined by the mandate linked to the business.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.DirectDebits.CreateDirectDebit(new CreateDirectDebitRequest
    {
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new PaymentsDirectDebitCreateRequest
        {
            UserId = Guid.Parse("83d83ec2-d2ca-49ff-bbea-b92b5c3be202"),
            AccountGroupId = Guid.Parse("1ea60f56-b67b-61fc-829a-0242ac130003"),
            MandateId = Guid.Parse("95b8304e-19fc-4cd9-8e50-82532e6b8d8c"),
            CashAmount = "200.00",
            Currency = Currency.Eur,
            RemittanceInformation = "payment for green energy portfolio",
            PurposeCode = "OTHR",
        },
    });
    // TODO: Handle 'response' of type PaymentsDirectDebitsResponse
}
catch (ApiException<CreateDirectDebitError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateDirectDebitRequest](src/UpvestInvestmentApi/Requests/DirectDebits/CreateDirectDebitRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PaymentsDirectDebitsResponse](src/UpvestInvestmentApi/Models/PaymentsDirectDebitsResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateDirectDebitError](src/UpvestInvestmentApi/Errors/CreateDirectDebitError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PaymentsDirectDebitsListResponse&gt; ListDirectDebits(ListDirectDebitsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a paginated list of direct debits for the account group specified by its ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.DirectDebits.ListDirectDebits(new ListDirectDebitsRequest
    {
        AccountGroupId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        Sort = Sort4.Id,
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type PaymentsDirectDebitsListResponse
}
catch (ApiException<ListDirectDebitsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListDirectDebitsRequest](src/UpvestInvestmentApi/Requests/DirectDebits/ListDirectDebitsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PaymentsDirectDebitsListResponse](src/UpvestInvestmentApi/Models/PaymentsDirectDebitsListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListDirectDebitsError](src/UpvestInvestmentApi/Errors/ListDirectDebitsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PaymentsDirectDebitsResponse&gt; RetrieveDirectDebit(RetrieveDirectDebitRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the direct debit specified by its ID, including its current status, cash amount, mandate reference, and any cancellation reason.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.DirectDebits.RetrieveDirectDebit(new RetrieveDirectDebitRequest
    {
        DirectDebitId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type PaymentsDirectDebitsResponse
}
catch (ApiException<RetrieveDirectDebitError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveDirectDebitRequest](src/UpvestInvestmentApi/Requests/DirectDebits/RetrieveDirectDebitRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PaymentsDirectDebitsResponse](src/UpvestInvestmentApi/Models/PaymentsDirectDebitsResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveDirectDebitError](src/UpvestInvestmentApi/Errors/RetrieveDirectDebitError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Fees

> Source: [Fees](src/UpvestInvestmentApi/Api/Fees.cs)

<details>
<summary><code>Task&lt;FeeCollection&gt; CreateFeeCollection(CreateFeeCollectionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates a fee collection for a fee amount you have already calculated.

The account must not be in `PENDING_APPROVAL` or `CLOSED` status; a request against an account in either status is rejected with a `400` response. Set `type` to `SERVICE_FEE` for collections that follow your normal fee cadence.

See the Fee collection guide ([TOL](https://docs.upvest.co/products/tol/guides/fees/fees_collection) / [BYOL](https://docs.upvest.co/products/byol/guides/fees/fees_collection)) for the collection lifecycle and webhook events.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Fees.CreateFeeCollection(new CreateFeeCollectionRequest
    {
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new FeeCollectionCreateRequest
        {
            AccountId = Guid.Parse("689f7566-2ca3-4007-b99d-e501be8c7783"),
            Type = Type37.ServiceFee,
            CollectionAmount = "12.41",
            Currency = Currency.Eur,
            PeriodStart = DateTimeOffset.Parse("2022-11-01T00:00:00Z"),
            PeriodEnd = DateTimeOffset.Parse("2022-11-30T00:00:00Z"),
        },
    });
    // TODO: Handle 'response' of type FeeCollection
}
catch (ApiException<CreateFeeCollectionError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateFeeCollectionRequest](src/UpvestInvestmentApi/Requests/Fees/CreateFeeCollectionRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FeeCollection](src/UpvestInvestmentApi/Models/FeeCollection.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateFeeCollectionError](src/UpvestInvestmentApi/Errors/CreateFeeCollectionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;FeeCollectionListResponse&gt; ListFeeCollections(ListFeeCollectionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the list of fee collections.

Use the `offset` and `limit` query parameters to page through results; `meta.total_count` gives the total number of matching fee collections. Narrow the result set with the `account_id` and `account_group_id` query parameters.

See the Fee collection guide ([TOL](https://docs.upvest.co/products/tol/guides/fees/fees_collection) / [BYOL](https://docs.upvest.co/products/byol/guides/fees/fees_collection)) for the collection lifecycle and webhook events.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Fees.ListFeeCollections(new ListFeeCollectionsRequest
    {
        AccountId = Guid.Parse("413715f2-5401-4b97-8055-034a6b879f8c"),
        AccountGroupId = Guid.Parse("72da9e41-9926-419f-976e-4c8069a04249"),
        Sort = Sort1.CreatedAt,
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type FeeCollectionListResponse
}
catch (ApiException<ListFeeCollectionsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListFeeCollectionsRequest](src/UpvestInvestmentApi/Requests/Fees/ListFeeCollectionsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FeeCollectionListResponse](src/UpvestInvestmentApi/Models/FeeCollectionListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListFeeCollectionsError](src/UpvestInvestmentApi/Errors/ListFeeCollectionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;FeeCollection&gt; RetrieveFeeCollection(RetrieveFeeCollectionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the fee collection identified by `fee_collection_id`, including its status and the amount processed so far.

A fee collection moves through `PROCESSING`, then either `FINALISED` once the fees have been collected from the account and transferred to you, or `CANCELLED`.

See the Fee collection guide ([TOL](https://docs.upvest.co/products/tol/guides/fees/fees_collection) / [BYOL](https://docs.upvest.co/products/byol/guides/fees/fees_collection)) for the collection lifecycle and webhook events.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Fees.RetrieveFeeCollection(new RetrieveFeeCollectionRequest
    {
        FeeCollectionId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type FeeCollection
}
catch (ApiException<RetrieveFeeCollectionError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveFeeCollectionRequest](src/UpvestInvestmentApi/Requests/Fees/RetrieveFeeCollectionRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FeeCollection](src/UpvestInvestmentApi/Models/FeeCollection.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveFeeCollectionError](src/UpvestInvestmentApi/Errors/RetrieveFeeCollectionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## FeesConfigurations

> Source: [FeesConfigurations](src/UpvestInvestmentApi/Api/FeesConfigurations.cs)

<details>
<summary><code>Task&lt;FeeConfiguration3&gt; CreateFeeConfiguration(CreateFeeConfigurationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Assigns a fee model to an account so that fees are calculated for that account.

Fee models are set up by Upvest from your requirements and identified by the `fee_model_id` Upvest provides. Every account that is to pay fees needs a fee configuration.

See the Fee model and configuration guide ([TOL](https://docs.upvest.co/products/tol/guides/fees/fees_model_configuration) / [BYOL](https://docs.upvest.co/products/byol/guides/fees/fees_model_configuration)) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.FeesConfigurations.CreateFeeConfiguration(new CreateFeeConfigurationRequest
    {
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new FeeConfigurationCreateRequest1
        {
            AccountId = Guid.Parse("7524949b-31fd-497e-ad92-f52de45341d1"),
            FeeModelId = Guid.Parse("1df86975-06f4-484d-935e-46b54bab2f6c"),
        },
    });
    // TODO: Handle 'response' of type FeeConfiguration3
}
catch (ApiException<CreateFeeConfigurationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateFeeConfigurationRequest](src/UpvestInvestmentApi/Requests/FeesConfigurations/CreateFeeConfigurationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FeeConfiguration3](src/UpvestInvestmentApi/Models/FeeConfiguration3.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateFeeConfigurationError](src/UpvestInvestmentApi/Errors/CreateFeeConfigurationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;FeeConfiguration3&gt; RetrieveFeeConfigurations(RetrieveFeeConfigurationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the fee configuration of the account identified by `account_id`.

See the Fee model and configuration guide ([TOL](https://docs.upvest.co/products/tol/guides/fees/fees_model_configuration) / [BYOL](https://docs.upvest.co/products/byol/guides/fees/fees_model_configuration)) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.FeesConfigurations.RetrieveFeeConfigurations(new RetrieveFeeConfigurationsRequest
    {
        AccountId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type FeeConfiguration3
}
catch (ApiException<RetrieveFeeConfigurationsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveFeeConfigurationsRequest](src/UpvestInvestmentApi/Requests/FeesConfigurations/RetrieveFeeConfigurationsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FeeConfiguration3](src/UpvestInvestmentApi/Models/FeeConfiguration3.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveFeeConfigurationsError](src/UpvestInvestmentApi/Errors/RetrieveFeeConfigurationsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;FeeConfiguration3&gt; UpdateFeeConfiguration(UpdateFeeConfigurationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Updates the fee configuration of the account identified by `account_id`.

Only the last fee configuration submitted on a given day is used to calculate that day's fees.

See the Fee model and configuration guide ([TOL](https://docs.upvest.co/products/tol/guides/fees/fees_model_configuration) / [BYOL](https://docs.upvest.co/products/byol/guides/fees/fees_model_configuration)) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.FeesConfigurations.UpdateFeeConfiguration(new UpdateFeeConfigurationRequest
    {
        AccountId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new FeeConfigurationUpdateRequest { FeeModelId = Guid.Parse("1df86975-06f4-484d-935e-46b54bab2f6c") },
    });
    // TODO: Handle 'response' of type FeeConfiguration3
}
catch (ApiException<UpdateFeeConfigurationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateFeeConfigurationRequest](src/UpvestInvestmentApi/Requests/FeesConfigurations/UpdateFeeConfigurationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FeeConfiguration3](src/UpvestInvestmentApi/Models/FeeConfiguration3.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[UpdateFeeConfigurationError](src/UpvestInvestmentApi/Errors/UpdateFeeConfigurationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Files

> Source: [Files](src/UpvestInvestmentApi/Api/Files.cs)

<details>
<summary><code>Task&lt;FilesMetadata&gt; FetchingFileMetadata(FetchingFileMetadataRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the metadata of the file identified by `folder` and `file_name`, together with a signed URL for downloading it.

Downloading a file is a two-step process: request the metadata here, then fetch the file from the returned `signed_url`. The signed URL is a one-time link that expires after 15 minutes, so download the file shortly after requesting it. Set `redirect=1` to have the API respond with an HTTP redirect to the download location instead of returning the URL in the body.

See the file retrieval guide ([TOL](https://docs.upvest.co/products/tol/guides/files/retrieving_data) / [BYOL](https://docs.upvest.co/products/byol/guides/files/retrieving_data) / [Omnibus](https://docs.upvest.co/products/omnibus/guides/files/retrieving_data)) for the download process.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Files.FetchingFileMetadata(new FetchingFileMetadataRequest
    {
        Folder = "booking_references",
        FileName = "list.txt",
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type FilesMetadata
}
catch (ApiException<FetchingFileMetadataError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[FetchingFileMetadataRequest](src/UpvestInvestmentApi/Requests/Files/FetchingFileMetadataRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FilesMetadata](src/UpvestInvestmentApi/Models/FilesMetadata.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[FetchingFileMetadataError](src/UpvestInvestmentApi/Errors/FetchingFileMetadataError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Isa

> Source: [Isa](src/UpvestInvestmentApi/Api/Isa.cs)

<details>
<summary><code>Task&lt;IsaTransfersResponse&gt; CreateIsaTransfer(CreateIsaTransferRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates an ISA transfer, moving all or part of an end user's existing ISA into an Upvest Stocks and Shares ISA while preserving their current-year allowance.

See the ISA transfers implementation guide ([TOL](https://docs.upvest.co/products/tol/guides/tax_wrappers/tax_wrappers_isa_transfers_implementation) / [BYOL](https://docs.upvest.co/products/byol/guides/tax_wrappers/tax_wrappers_isa_transfers_implementation)) for the required fields per transfer type.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Isa.CreateIsaTransfer(new CreateIsaTransferRequest
    {
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new TaxWrappersIsaCreateIsaTransferRequest
        {
            UserId = Guid.Parse("4b2e2e64-7544-4c3f-a98d-dfdc03d487aa"),
            AccountGroupId = Guid.Parse("79e9f9a2-dd29-4b54-9cca-b4c31956beb3"),
            CashAmount = "10000.00",
            Counterparty = new Counterparty2 { AccountNumber = "5WJSZB3C8" },
            CurrentYearSubscription = new CurrentYearSubscription
            {
                TaxYear = "2025/2026",
                CashAmount = "3000.00",
                FirstSubscriptionAt = DateTimeOffset.Parse("2025-09-14T12:10:00Z"),
            },
        },
    });
    // TODO: Handle 'response' of type IsaTransfersResponse
}
catch (ApiException<CreateIsaTransferError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateIsaTransferRequest](src/UpvestInvestmentApi/Requests/Isa/CreateIsaTransferRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[IsaTransfersResponse](src/UpvestInvestmentApi/Models/IsaTransfersResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateIsaTransferError](src/UpvestInvestmentApi/Errors/CreateIsaTransferError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;TaxWrappersIsaIsaWrapper&gt; CreateIsaWrapper(CreateIsaWrapperRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates an ISA tax wrapper for an account group, holding the business rules that apply to the tax-wrapped product.

The account group must have been created with `type` set to `ISA`. For a `STOCKS_AND_SHARES_ISA`, set `is_flexible` to indicate whether the end user may replace withdrawals within the same tax year without using up their annual allowance. A tax wrapper stays inactive until the end user's tax residency has been confirmed, and the ISA account group cannot become `ACTIVE` until the tax wrapper does.

See the ISA tax wrapper integration guide ([TOL](https://docs.upvest.co/products/tol/guides/tax_wrappers/pension_de/tax_wrappers/pension_de_isa_integration) / [BYOL](https://docs.upvest.co/products/byol/guides/tax_wrappers/pension_de/tax_wrappers/pension_de_isa_integration)) for the onboarding and activation sequence.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Isa.CreateIsaWrapper(new CreateIsaWrapperRequest
    {
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new TaxWrappersIsaCreateIsaWrapperRequest
        {
            AccountGroupId = Guid.Parse("0d68fea2-66e8-4ea8-b507-276e7a1eb4aa"),
            IsFlexible = true,
        },
    });
    // TODO: Handle 'response' of type TaxWrappersIsaIsaWrapper
}
catch (ApiException<CreateIsaWrapperError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateIsaWrapperRequest](src/UpvestInvestmentApi/Requests/Isa/CreateIsaWrapperRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[TaxWrappersIsaIsaWrapper](src/UpvestInvestmentApi/Models/TaxWrappersIsaIsaWrapper.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateIsaWrapperError](src/UpvestInvestmentApi/Errors/CreateIsaWrapperError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;TaxWrappersIsaRetrieveIsaAllowancesResponse&gt; RetrieveIsaAllowances(RetrieveIsaAllowancesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the ISA allowances of the tax wrapper identified by `tax_wrapper_id`.

An `ANNUAL` allowance covers one UK tax year, which runs from 6 April to 5 April and is identified in `yyyy/yyyy` form. Allowances expire at `valid_to` and do not roll over; a new allowance is created at the start of each tax year.

See the ISA tax wrapper integration guide ([TOL](https://docs.upvest.co/products/tol/guides/tax_wrappers/pension_de/tax_wrappers/pension_de_isa_integration) / [BYOL](https://docs.upvest.co/products/byol/guides/tax_wrappers/pension_de/tax_wrappers/pension_de_isa_integration)) for the onboarding and activation sequence.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Isa.RetrieveIsaAllowances(new RetrieveIsaAllowancesRequest
    {
        TaxWrapperId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type TaxWrappersIsaRetrieveIsaAllowancesResponse
}
catch (ApiException<RetrieveIsaAllowancesError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveIsaAllowancesRequest](src/UpvestInvestmentApi/Requests/Isa/RetrieveIsaAllowancesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[TaxWrappersIsaRetrieveIsaAllowancesResponse](src/UpvestInvestmentApi/Models/TaxWrappersIsaRetrieveIsaAllowancesResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveIsaAllowancesError](src/UpvestInvestmentApi/Errors/RetrieveIsaAllowancesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Instruments

> Source: [Instruments](src/UpvestInvestmentApi/Api/Instruments.cs)

<details>
<summary><code>Task&lt;InstrumentsListResponse&gt; ListInstruments(ListInstrumentsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the list of instruments available on the Upvest platform.

Narrow the list with the `trading_status` query parameter, and page through results with `offset` and `limit`; `meta.total_count` gives the total number of matching instruments. The instrument universe reflects onboarding, delisting, and trading bans as they occur.

See the instruments guide ([TOL](https://docs.upvest.co/products/tol/guides/instruments/implementing_instruments) / [BYOL](https://docs.upvest.co/products/byol/guides/instruments/implementing_instruments) / [Omnibus](https://docs.upvest.co/products/omnibus/guides/instruments/implementing_instruments)) for instrument onboarding, delisting, and trading bans.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Instruments.ListInstruments(new ListInstrumentsRequest
    {
        TradingStatus = InstrumentTradingStatus.Active,
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type InstrumentsListResponse
}
catch (ApiException<ListInstrumentsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListInstrumentsRequest](src/UpvestInvestmentApi/Requests/Instruments/ListInstrumentsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[InstrumentsListResponse](src/UpvestInvestmentApi/Models/InstrumentsListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListInstrumentsError](src/UpvestInvestmentApi/Errors/ListInstrumentsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;InstrumentsResponse&gt; RetrieveInstrument(RetrieveInstrumentRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the instrument identified by `instrument_id`, including its identifiers, name, trading status, and whether it supports fractional investing.

See the instruments guide ([TOL](https://docs.upvest.co/products/tol/guides/instruments/implementing_instruments) / [BYOL](https://docs.upvest.co/products/byol/guides/instruments/implementing_instruments) / [Omnibus](https://docs.upvest.co/products/omnibus/guides/instruments/implementing_instruments)) for instrument onboarding, delisting, and trading bans.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Instruments.RetrieveInstrument(new RetrieveInstrumentRequest
    {
        InstrumentId = "some example string",
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type InstrumentsResponse
}
catch (ApiException<RetrieveInstrumentError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveInstrumentRequest](src/UpvestInvestmentApi/Requests/Instruments/RetrieveInstrumentRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[InstrumentsResponse](src/UpvestInvestmentApi/Models/InstrumentsResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveInstrumentError](src/UpvestInvestmentApi/Errors/RetrieveInstrumentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Liquidations

> Source: [Liquidations](src/UpvestInvestmentApi/Api/Liquidations.cs)

<details>
<summary><code>Task CancelAccountLiquidation(CancelAccountLiquidationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Cancels a pending account liquidation. Only liquidations in the `NEW` status can be cancelled.

See the Liquidations guide ([TOL](https://docs.upvest.co/products/tol/guides/liquidations) / [BYOL](https://docs.upvest.co/products/byol/guides/liquidations)) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.Liquidations.CancelAccountLiquidation(new CancelAccountLiquidationRequest
    {
        AccountId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        AccountLiquidationId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
}
catch (ApiException<CancelAccountLiquidationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CancelAccountLiquidationRequest](src/UpvestInvestmentApi/Requests/Liquidations/CancelAccountLiquidationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CancelAccountLiquidationError](src/UpvestInvestmentApi/Errors/CancelAccountLiquidationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AccountLiquidation&gt; CreateAccountLiquidation(CreateAccountLiquidationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Initiates a full liquidation of an investment account, placing sell orders for all held positions and converting the proceeds to cash.

Exactly one of `user_id` or `business_id` must be provided in the request body.

See the Liquidations guide ([TOL](https://docs.upvest.co/products/tol/guides/liquidations) / [BYOL](https://docs.upvest.co/products/byol/guides/liquidations)) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Liquidations.CreateAccountLiquidation(new CreateAccountLiquidationRequest
    {
        AccountId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new AccountLiquidationRequest { UserId = Guid.Parse("084a00a8-4a37-4d2d-b276-71ec5e2be0e3") },
    });
    // TODO: Handle 'response' of type AccountLiquidation
}
catch (ApiException<CreateAccountLiquidationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateAccountLiquidationRequest](src/UpvestInvestmentApi/Requests/Liquidations/CreateAccountLiquidationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AccountLiquidation](src/UpvestInvestmentApi/Models/AccountLiquidation.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateAccountLiquidationError](src/UpvestInvestmentApi/Errors/CreateAccountLiquidationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PortfoliosOrdersListResponse1&gt; ListAccountsLiquidations(ListAccountsLiquidationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a paginated list of account liquidation requests for the authenticated client.

See the Liquidations guide ([TOL](https://docs.upvest.co/products/tol/guides/liquidations) / [BYOL](https://docs.upvest.co/products/byol/guides/liquidations)) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Liquidations.ListAccountsLiquidations(new ListAccountsLiquidationsRequest
    {
        AccountId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        StartDate = "2022-10-14T10:10:10Z",
        EndDate = "2022-10-14T10:10:10Z",
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type PortfoliosOrdersListResponse1
}
catch (ApiException<ListAccountsLiquidationsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListAccountsLiquidationsRequest](src/UpvestInvestmentApi/Requests/Liquidations/ListAccountsLiquidationsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PortfoliosOrdersListResponse1](src/UpvestInvestmentApi/Models/PortfoliosOrdersListResponse1.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListAccountsLiquidationsError](src/UpvestInvestmentApi/Errors/ListAccountsLiquidationsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AccountLiquidation&gt; RetrieveAccountLiquidation(RetrieveAccountLiquidationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Retrieves an account liquidation by its ID, including the status of each individual sell order.

See the Liquidations guide ([TOL](https://docs.upvest.co/products/tol/guides/liquidations) / [BYOL](https://docs.upvest.co/products/byol/guides/liquidations)) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Liquidations.RetrieveAccountLiquidation(new RetrieveAccountLiquidationRequest
    {
        AccountId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        AccountLiquidationId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type AccountLiquidation
}
catch (ApiException<RetrieveAccountLiquidationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveAccountLiquidationRequest](src/UpvestInvestmentApi/Requests/Liquidations/RetrieveAccountLiquidationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AccountLiquidation](src/UpvestInvestmentApi/Models/AccountLiquidation.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveAccountLiquidationError](src/UpvestInvestmentApi/Errors/RetrieveAccountLiquidationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Mandates

> Source: [Mandates](src/UpvestInvestmentApi/Api/Mandates.cs)

<details>
<summary><code>Task&lt;DirectDebitMandate&gt; CreateMandate(CreateMandateRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Create a mandate.

Supports both user and business accounts. Provide `user_id` for user flows or `business_id` for business flows — exactly one must be specified.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Mandates.CreateMandate(new CreateMandateRequest
    {
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new MandateCreateRequest
        {
            UserId = Guid.Parse("83d83ec2-d2ca-49ff-bbea-b92b5c3be202"),
            Iban = "DE89000000000000000000",
            Bic = "ABCDEXXX",
            ConfirmedAt = DateTimeOffset.Parse("2021-12-08T08:38:48.021Z"),
        },
    });
    // TODO: Handle 'response' of type DirectDebitMandate
}
catch (ApiException<CreateMandateError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateMandateRequest](src/UpvestInvestmentApi/Requests/Mandates/CreateMandateRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[DirectDebitMandate](src/UpvestInvestmentApi/Models/DirectDebitMandate.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateMandateError](src/UpvestInvestmentApi/Errors/CreateMandateError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task DeleteMandate(DeleteMandateRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Deletes the direct debit mandate specified by its ID. Deletion permanently removes the mandate; associated direct debits already in progress are not affected.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.Mandates.DeleteMandate(new DeleteMandateRequest
    {
        MandateId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
}
catch (ApiException<DeleteMandateError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[DeleteMandateRequest](src/UpvestInvestmentApi/Requests/Mandates/DeleteMandateRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[DeleteMandateError](src/UpvestInvestmentApi/Errors/DeleteMandateError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;MandatesListBusinessResponse&gt; ListBusinessMandates(ListBusinessMandatesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a paginated list of direct debit mandates for the business specified by its ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Mandates.ListBusinessMandates(new ListBusinessMandatesRequest
    {
        BusinessId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        Sort = Sort4.Id,
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type MandatesListBusinessResponse
}
catch (ApiException<ListBusinessMandatesError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListBusinessMandatesRequest](src/UpvestInvestmentApi/Requests/Mandates/ListBusinessMandatesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[MandatesListBusinessResponse](src/UpvestInvestmentApi/Models/MandatesListBusinessResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListBusinessMandatesError](src/UpvestInvestmentApi/Errors/ListBusinessMandatesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;MandatesListResponse&gt; ListMandates(ListMandatesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a paginated list of direct debit mandates for the user specified by their ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Mandates.ListMandates(new ListMandatesRequest
    {
        UserId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        Sort = Sort4.Id,
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type MandatesListResponse
}
catch (ApiException<ListMandatesError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListMandatesRequest](src/UpvestInvestmentApi/Requests/Mandates/ListMandatesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[MandatesListResponse](src/UpvestInvestmentApi/Models/MandatesListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListMandatesError](src/UpvestInvestmentApi/Errors/ListMandatesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;DirectDebitMandate&gt; RetrieveMandate(RetrieveMandateRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Retrieve a direct debit mandate.

The response contains either `user_id` or `business_id` depending on whether the mandate belongs to a user or business account.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Mandates.RetrieveMandate(new RetrieveMandateRequest
    {
        MandateId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type DirectDebitMandate
}
catch (ApiException<RetrieveMandateError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveMandateRequest](src/UpvestInvestmentApi/Requests/Mandates/RetrieveMandateRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[DirectDebitMandate](src/UpvestInvestmentApi/Models/DirectDebitMandate.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveMandateError](src/UpvestInvestmentApi/Errors/RetrieveMandateError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Orders

> Source: [Orders](src/UpvestInvestmentApi/Api/Orders.cs)

<details>
<summary><code>Task&lt;OrderCancelResponse&gt; CancelOrder(CancelOrderRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Cancels an order specified by its ID. It is possible to cancel an order in the `NEW` or `PROCESSING` status. Once a cancellation has been accepted, the further processing steps take place asynchronously and depending on the respective order status.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Orders.CancelOrder(new CancelOrderRequest
    {
        OrderId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type OrderCancelResponse
}
catch (ApiException<CancelOrderError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CancelOrderRequest](src/UpvestInvestmentApi/Requests/Orders/CancelOrderRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[OrderCancelResponse](src/UpvestInvestmentApi/Models/OrderCancelResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CancelOrderError](src/UpvestInvestmentApi/Errors/CancelOrderError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;OrdersListResponse&gt; ListAccountOrders(ListAccountOrdersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a paginated list of orders for the account specified by its ID, including their statuses, executions, and fee configurations.

See the Orders guide ([TOL](https://docs.upvest.co/products/tol/guides/orders) / [BYOL](https://docs.upvest.co/products/byol/guides/orders) / [Omnibus](https://docs.upvest.co/products/omnibus/guides/orders)) for order lifecycle details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Orders.ListAccountOrders(new ListAccountOrdersRequest
    {
        AccountId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        DateCreatedFrom = DateTimeOffset.Parse("2022-10-14T10:10:10Z"),
        DateCreatedTo = DateTimeOffset.Parse("2022-10-14T10:10:10Z"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type OrdersListResponse
}
catch (ApiException<ListAccountOrdersError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListAccountOrdersRequest](src/UpvestInvestmentApi/Requests/Orders/ListAccountOrdersRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[OrdersListResponse](src/UpvestInvestmentApi/Models/OrdersListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListAccountOrdersError](src/UpvestInvestmentApi/Errors/ListAccountOrdersError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Order39&gt; PlaceOrder(PlaceOrderRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Places a new order for an instrument. After the request is accepted, the order is processed asynchronously — use the returned `id` to poll for status or subscribe to order webhook events.

See the Orders guide ([TOL](https://docs.upvest.co/products/tol/guides/orders) / [BYOL](https://docs.upvest.co/products/byol/guides/orders) / [Omnibus](https://docs.upvest.co/products/omnibus/guides/orders)) for order lifecycle details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Orders.PlaceOrder(new PlaceOrderRequest
    {
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new OrderPlaceRequest
        {
            UserId = Guid.Parse("2dedfeb0-58cd-44f2-ae08-0e41fe0413d9"),
            AccountId = Guid.Parse("debf2026-f2da-4ff0-bb84-92e45babb1e3"),
            CashAmount = "1000",
            Currency = Currency29.Eur,
            Side = Side.Buy,
            InstrumentId = "US0378331005",
            OrderType = OrderType.Market,
            UserInstrumentFitAcknowledgement = true,
            LimitPrice = "",
            StopPrice = "",
        },
    });
    // TODO: Handle 'response' of type Order39
}
catch (ApiException<PlaceOrderError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[PlaceOrderRequest](src/UpvestInvestmentApi/Requests/Orders/PlaceOrderRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Order39](src/UpvestInvestmentApi/Models/Order39.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[PlaceOrderError](src/UpvestInvestmentApi/Errors/PlaceOrderError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Order39&gt; RetrieveOrder(RetrieveOrderRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the order specified by its ID, including its current status, executions, fee configuration, and any cancellation reason.

See the Orders guide ([TOL](https://docs.upvest.co/products/tol/guides/orders) / [BYOL](https://docs.upvest.co/products/byol/guides/orders) / [Omnibus](https://docs.upvest.co/products/omnibus/guides/orders)) for order lifecycle details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Orders.RetrieveOrder(new RetrieveOrderRequest
    {
        OrderId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type Order39
}
catch (ApiException<RetrieveOrderError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveOrderRequest](src/UpvestInvestmentApi/Requests/Orders/RetrieveOrderRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Order39](src/UpvestInvestmentApi/Models/Order39.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveOrderError](src/UpvestInvestmentApi/Errors/RetrieveOrderError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;OrderExecution&gt; RetrieveOrderExecution(RetrieveOrderExecutionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the order execution specified by its ID. An execution represents a single trade fill within an order; an order may have multiple executions if it is partially filled across several trades.

See the Orders guide ([TOL](https://docs.upvest.co/products/tol/guides/orders) / [BYOL](https://docs.upvest.co/products/byol/guides/orders) / [Omnibus](https://docs.upvest.co/products/omnibus/guides/orders)) for execution lifecycle details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Orders.RetrieveOrderExecution(new RetrieveOrderExecutionRequest
    {
        ExecutionId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        OrderId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type OrderExecution
}
catch (ApiException<RetrieveOrderExecutionError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveOrderExecutionRequest](src/UpvestInvestmentApi/Requests/Orders/RetrieveOrderExecutionRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[OrderExecution](src/UpvestInvestmentApi/Models/OrderExecution.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveOrderExecutionError](src/UpvestInvestmentApi/Errors/RetrieveOrderExecutionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Portfolios

> Source: [Portfolios](src/UpvestInvestmentApi/Api/Portfolios.cs)

<details>
<summary><code>Task CancelPortfoliosOrder(CancelPortfoliosOrderRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Cancel portfolios order. Cancellations may not be possible - in rare situations, some individual orders within portfolios order may already have been filled. In this case, cancellation could result in a mix of cancelled and filled orders.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.Portfolios.CancelPortfoliosOrder(new CancelPortfoliosOrderRequest
    {
        PortfolioOrderId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
}
catch (ApiException<CancelPortfoliosOrderError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CancelPortfoliosOrderRequest](src/UpvestInvestmentApi/Requests/Portfolios/CancelPortfoliosOrderRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CancelPortfoliosOrderError](src/UpvestInvestmentApi/Errors/CancelPortfoliosOrderError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PortfoliosAllocation&gt; CreatePortfoliosAllocation(CreatePortfoliosAllocationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates a named portfolio allocation specifying a set of instrument weights.

The `allocation` array must contain at least one instrument entry. Weights are expressed as percentages and must sum to 100.

See the Portfolios guide ([TOL](https://docs.upvest.co/products/tol/guides/portfolios) / [BYOL](https://docs.upvest.co/products/byol/guides/portfolios)) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Portfolios.CreatePortfoliosAllocation(new CreatePortfoliosAllocationRequest
    {
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type PortfoliosAllocation
}
catch (ApiException<CreatePortfoliosAllocationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreatePortfoliosAllocationRequest](src/UpvestInvestmentApi/Requests/Portfolios/CreatePortfoliosAllocationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PortfoliosAllocation](src/UpvestInvestmentApi/Models/PortfoliosAllocation.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreatePortfoliosAllocationError](src/UpvestInvestmentApi/Errors/CreatePortfoliosAllocationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PortfoliosConfiguration&gt; CreatePortfoliosConfiguration(CreatePortfoliosConfigurationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates a portfolio configuration for an investment account, associating it with a target allocation and optional rebalancing strategies.

Only one active configuration per account is permitted.

See the Portfolios guide ([TOL](https://docs.upvest.co/products/tol/guides/portfolios) / [BYOL](https://docs.upvest.co/products/byol/guides/portfolios)) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Portfolios.CreatePortfoliosConfiguration(new CreatePortfoliosConfigurationRequest
    {
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new PortfoliosConfigurationCreateRequest
        {
            AccountId = Guid.Parse("f2f7d2c7-d79b-4de2-ae9b-d01646259f9e"),
            AllocationId = Guid.Parse("eb68abce-29f4-483f-a384-7f243e77851f"),
        },
    });
    // TODO: Handle 'response' of type PortfoliosConfiguration
}
catch (ApiException<CreatePortfoliosConfigurationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreatePortfoliosConfigurationRequest](src/UpvestInvestmentApi/Requests/Portfolios/CreatePortfoliosConfigurationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PortfoliosConfiguration](src/UpvestInvestmentApi/Models/PortfoliosConfiguration.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreatePortfoliosConfigurationError](src/UpvestInvestmentApi/Errors/CreatePortfoliosConfigurationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PortfoliosOrder&gt; CreatePortfoliosOrder(CreatePortfoliosOrderRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Places a buy or sell portfolio order for the specified account, distributing the cash amount across instruments according to the account's allocation weights.

One underlying instrument order is generated per instrument in the allocation.

See the Portfolios guide ([TOL](https://docs.upvest.co/products/tol/guides/portfolios) / [BYOL](https://docs.upvest.co/products/byol/guides/portfolios)) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Portfolios.CreatePortfoliosOrder(new CreatePortfoliosOrderRequest
    {
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new PortfoliosOrderPlaceRequest
        {
            UserId = Guid.Parse("4b9732bd-7496-4e91-8a5f-6360479d7fed"),
            AccountId = Guid.Parse("00ef0be8-d564-43af-b3c7-11b7a2188030"),
            CashAmount = "100.00",
            Currency = Currency.Eur,
            Side = Side15.Buy,
        },
    });
    // TODO: Handle 'response' of type PortfoliosOrder
}
catch (ApiException<CreatePortfoliosOrderError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreatePortfoliosOrderRequest](src/UpvestInvestmentApi/Requests/Portfolios/CreatePortfoliosOrderRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PortfoliosOrder](src/UpvestInvestmentApi/Models/PortfoliosOrder.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreatePortfoliosOrderError](src/UpvestInvestmentApi/Errors/CreatePortfoliosOrderError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task DeletePortfoliosConfiguration(DeletePortfoliosConfigurationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Delete portfolios configuration (hard delete)

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.Portfolios.DeletePortfoliosConfiguration(new DeletePortfoliosConfigurationRequest
    {
        AccountId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
}
catch (ApiException<DeletePortfoliosConfigurationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[DeletePortfoliosConfigurationRequest](src/UpvestInvestmentApi/Requests/Portfolios/DeletePortfoliosConfigurationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[DeletePortfoliosConfigurationError](src/UpvestInvestmentApi/Errors/DeletePortfoliosConfigurationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PortfoliosAllocationAccountsListResponse&gt; ListPortfoliosAllocationAccounts(ListPortfoliosAllocationAccountsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a paginated list of accounts associated with a specific portfolio allocation.

See the Portfolios guide ([TOL](https://docs.upvest.co/products/tol/guides/portfolios) / [BYOL](https://docs.upvest.co/products/byol/guides/portfolios)) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Portfolios.ListPortfoliosAllocationAccounts(new ListPortfoliosAllocationAccountsRequest
    {
        AllocationId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type PortfoliosAllocationAccountsListResponse
}
catch (ApiException<ListPortfoliosAllocationAccountsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListPortfoliosAllocationAccountsRequest](src/UpvestInvestmentApi/Requests/Portfolios/ListPortfoliosAllocationAccountsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PortfoliosAllocationAccountsListResponse](src/UpvestInvestmentApi/Models/PortfoliosAllocationAccountsListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListPortfoliosAllocationAccountsError](src/UpvestInvestmentApi/Errors/ListPortfoliosAllocationAccountsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PortfoliosAllocationsListResponse&gt; ListPortfoliosAllocations(ListPortfoliosAllocationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a paginated list of portfolio allocations for the authenticated client.

Allocations define the target instrument weights that portfolio configurations use to invest and rebalance.

See the Portfolios guide ([TOL](https://docs.upvest.co/products/tol/guides/portfolios) / [BYOL](https://docs.upvest.co/products/byol/guides/portfolios)) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Portfolios.ListPortfoliosAllocations(new ListPortfoliosAllocationsRequest
    {
        StartDate = "2022-10-14T10:10:10Z",
        EndDate = "2022-10-14T10:10:10Z",
        InstrumentIds = "bf72bdc1-b342-494f-9739-b27ae9011b86,dcbe2cf4-4f37-4fe5-9393-4fb52bb87fab",
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type PortfoliosAllocationsListResponse
}
catch (ApiException<ListPortfoliosAllocationsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListPortfoliosAllocationsRequest](src/UpvestInvestmentApi/Requests/Portfolios/ListPortfoliosAllocationsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PortfoliosAllocationsListResponse](src/UpvestInvestmentApi/Models/PortfoliosAllocationsListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListPortfoliosAllocationsError](src/UpvestInvestmentApi/Errors/ListPortfoliosAllocationsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PortfoliosConfigurationsListResponse&gt; ListPortfoliosConfigurations(ListPortfoliosConfigurationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a paginated list of portfolio configurations for the authenticated client.

Each configuration links an account to an allocation and defines which rebalancing strategies apply to that account.

See the Portfolios guide ([TOL](https://docs.upvest.co/products/tol/guides/portfolios) / [BYOL](https://docs.upvest.co/products/byol/guides/portfolios)) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Portfolios.ListPortfoliosConfigurations(new ListPortfoliosConfigurationsRequest
    {
        StartDate = "2022-10-14T10:10:10Z",
        EndDate = "2022-10-14T10:10:10Z",
        AccountId = "3ada8e9e-82c4-4c78-a43d-a691b1636509",
        AllocationId = "f6c2b02a-3214-4a40-82ae-6c76df50bc8c",
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type PortfoliosConfigurationsListResponse
}
catch (ApiException<ListPortfoliosConfigurationsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListPortfoliosConfigurationsRequest](src/UpvestInvestmentApi/Requests/Portfolios/ListPortfoliosConfigurationsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PortfoliosConfigurationsListResponse](src/UpvestInvestmentApi/Models/PortfoliosConfigurationsListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListPortfoliosConfigurationsError](src/UpvestInvestmentApi/Errors/ListPortfoliosConfigurationsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PortfoliosOrdersListResponse&gt; ListPortfoliosOrders(ListPortfoliosOrdersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a paginated list of portfolio orders for the authenticated client.

Portfolio orders represent buy or sell instructions that invest or withdraw a cash amount across all instruments in the account's current allocation.

See the Portfolios guide ([TOL](https://docs.upvest.co/products/tol/guides/portfolios) / [BYOL](https://docs.upvest.co/products/byol/guides/portfolios)) for order lifecycle details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Portfolios.ListPortfoliosOrders(new ListPortfoliosOrdersRequest
    {
        StartDate = "2022-10-14T10:10:10Z",
        EndDate = "2022-10-14T10:10:10Z",
        AllocationId = Guid.Parse("f96eaefd-b4c6-477a-9bbe-c744bf26172f"),
        AccountId = Guid.Parse("2c865aab-6737-4b0e-9154-69a4622b2727"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type PortfoliosOrdersListResponse
}
catch (ApiException<ListPortfoliosOrdersError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListPortfoliosOrdersRequest](src/UpvestInvestmentApi/Requests/Portfolios/ListPortfoliosOrdersRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PortfoliosOrdersListResponse](src/UpvestInvestmentApi/Models/PortfoliosOrdersListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListPortfoliosOrdersError](src/UpvestInvestmentApi/Errors/ListPortfoliosOrdersError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PortfoliosAllocation&gt; RetrievePortfoliosAllocation(RetrievePortfoliosAllocationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Retrieves a portfolio allocation by its ID, including its name, instrument weights, and associated rebalancing strategy IDs.

See the Portfolios guide ([TOL](https://docs.upvest.co/products/tol/guides/portfolios) / [BYOL](https://docs.upvest.co/products/byol/guides/portfolios)) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Portfolios.RetrievePortfoliosAllocation(new RetrievePortfoliosAllocationRequest
    {
        AllocationId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type PortfoliosAllocation
}
catch (ApiException<RetrievePortfoliosAllocationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrievePortfoliosAllocationRequest](src/UpvestInvestmentApi/Requests/Portfolios/RetrievePortfoliosAllocationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PortfoliosAllocation](src/UpvestInvestmentApi/Models/PortfoliosAllocation.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrievePortfoliosAllocationError](src/UpvestInvestmentApi/Errors/RetrievePortfoliosAllocationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PortfoliosConfiguration&gt; RetrievePortfoliosConfiguration(RetrievePortfoliosConfigurationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Retrieves a portfolio configuration by its ID, including the linked allocation and any associated rebalancing strategies.

See the Portfolios guide ([TOL](https://docs.upvest.co/products/tol/guides/portfolios) / [BYOL](https://docs.upvest.co/products/byol/guides/portfolios)) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Portfolios.RetrievePortfoliosConfiguration(new RetrievePortfoliosConfigurationRequest
    {
        AccountId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type PortfoliosConfiguration
}
catch (ApiException<RetrievePortfoliosConfigurationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrievePortfoliosConfigurationRequest](src/UpvestInvestmentApi/Requests/Portfolios/RetrievePortfoliosConfigurationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PortfoliosConfiguration](src/UpvestInvestmentApi/Models/PortfoliosConfiguration.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrievePortfoliosConfigurationError](src/UpvestInvestmentApi/Errors/RetrievePortfoliosConfigurationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PortfoliosOrder&gt; RetrievePortfoliosOrder(RetrievePortfoliosOrderRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Retrieves a portfolio order by its ID, including the status and details of each underlying instrument order.

See the Portfolios guide ([TOL](https://docs.upvest.co/products/tol/guides/portfolios) / [BYOL](https://docs.upvest.co/products/byol/guides/portfolios)) for order lifecycle details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Portfolios.RetrievePortfoliosOrder(new RetrievePortfoliosOrderRequest
    {
        PortfolioOrderId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type PortfoliosOrder
}
catch (ApiException<RetrievePortfoliosOrderError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrievePortfoliosOrderRequest](src/UpvestInvestmentApi/Requests/Portfolios/RetrievePortfoliosOrderRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PortfoliosOrder](src/UpvestInvestmentApi/Models/PortfoliosOrder.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrievePortfoliosOrderError](src/UpvestInvestmentApi/Errors/RetrievePortfoliosOrderError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PortfoliosAllocation&gt; UpdatePortfoliosAllocation(UpdatePortfoliosAllocationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Updates the name and/or instrument weights of an existing portfolio allocation.

Accounts with a portfolio configuration referencing this allocation will use the new weights on their next rebalancing.

See the Portfolios guide ([TOL](https://docs.upvest.co/products/tol/guides/portfolios) / [BYOL](https://docs.upvest.co/products/byol/guides/portfolios)) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Portfolios.UpdatePortfoliosAllocation(new UpdatePortfoliosAllocationRequest
    {
        AllocationId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type PortfoliosAllocation
}
catch (ApiException<UpdatePortfoliosAllocationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdatePortfoliosAllocationRequest](src/UpvestInvestmentApi/Requests/Portfolios/UpdatePortfoliosAllocationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PortfoliosAllocation](src/UpvestInvestmentApi/Models/PortfoliosAllocation.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[UpdatePortfoliosAllocationError](src/UpvestInvestmentApi/Errors/UpdatePortfoliosAllocationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PortfoliosConfiguration&gt; UpdatePortfoliosConfiguration(UpdatePortfoliosConfigurationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Updates the allocation or rebalancing strategies of an existing portfolio configuration.

See the Portfolios guide ([TOL](https://docs.upvest.co/products/tol/guides/portfolios) / [BYOL](https://docs.upvest.co/products/byol/guides/portfolios)) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Portfolios.UpdatePortfoliosConfiguration(new UpdatePortfoliosConfigurationRequest
    {
        AccountId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new PortfoliosConfigurationUpdateRequest
        {
            AllocationId = Guid.Parse("359e9c9e-b91c-4853-8674-e6657af609fc"),
        },
    });
    // TODO: Handle 'response' of type PortfoliosConfiguration
}
catch (ApiException<UpdatePortfoliosConfigurationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdatePortfoliosConfigurationRequest](src/UpvestInvestmentApi/Requests/Portfolios/UpdatePortfoliosConfigurationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PortfoliosConfiguration](src/UpvestInvestmentApi/Models/PortfoliosConfiguration.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[UpdatePortfoliosConfigurationError](src/UpvestInvestmentApi/Errors/UpdatePortfoliosConfigurationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## PortfoliosRebalancing

> Source: [PortfoliosRebalancing](src/UpvestInvestmentApi/Api/PortfoliosRebalancing.cs)

<details>
<summary><code>Task&lt;PortfoliosRebalancingExecutionOrderListResponse&gt; ListPortfolioRebalancingExecutionOrders(ListPortfolioRebalancingExecutionOrdersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

List portfolio rebalancing execution orders

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.PortfoliosRebalancing.ListPortfolioRebalancingExecutionOrders(
        new ListPortfolioRebalancingExecutionOrdersRequest
        {
            ExecutionId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
            StartDate = "2022-10-14T10:10:10Z",
            EndDate = "2022-10-14T10:10:10Z",
            UpvestApiVersion = UpvestApiVersion._1,
        });
    // TODO: Handle 'response' of type PortfoliosRebalancingExecutionOrderListResponse
}
catch (ApiException<ListPortfolioRebalancingExecutionOrdersError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListPortfolioRebalancingExecutionOrdersRequest](src/UpvestInvestmentApi/Requests/PortfoliosRebalancing/ListPortfolioRebalancingExecutionOrdersRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PortfoliosRebalancingExecutionOrderListResponse](src/UpvestInvestmentApi/Models/PortfoliosRebalancingExecutionOrderListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListPortfolioRebalancingExecutionOrdersError](src/UpvestInvestmentApi/Errors/ListPortfolioRebalancingExecutionOrdersError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PortfoliosRebalancingExecution&gt; RetrievePortfoliosRebalancingExecution(RetrievePortfoliosRebalancingExecutionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Retrieve portfolios rebalancing execution

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.PortfoliosRebalancing.RetrievePortfoliosRebalancingExecution(
        new RetrievePortfoliosRebalancingExecutionRequest
        {
            ExecutionId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
            UpvestApiVersion = UpvestApiVersion._1,
        });
    // TODO: Handle 'response' of type PortfoliosRebalancingExecution
}
catch (ApiException<RetrievePortfoliosRebalancingExecutionError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrievePortfoliosRebalancingExecutionRequest](src/UpvestInvestmentApi/Requests/PortfoliosRebalancing/RetrievePortfoliosRebalancingExecutionRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PortfoliosRebalancingExecution](src/UpvestInvestmentApi/Models/PortfoliosRebalancingExecution.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrievePortfoliosRebalancingExecutionError](src/UpvestInvestmentApi/Errors/RetrievePortfoliosRebalancingExecutionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;TriggerPortfolioRebalancingResponse&gt; TriggerPortfolioRebalancing(TriggerPortfolioRebalancingOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Triggers an immediate rebalancing execution for all accounts linked to the specified allocation.

The rebalancing adjusts each account's positions to match the current target allocation weights. In rare situations, individual orders within the rebalancing may not be cancellable once submitted.

See the Portfolios rebalancing guide ([TOL](https://docs.upvest.co/products/tol/guides/portfolios/rebalancing/rebalancing) / [BYOL](https://docs.upvest.co/products/byol/guides/portfolios/rebalancing/rebalancing)) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.PortfoliosRebalancing.TriggerPortfolioRebalancing(
        new TriggerPortfolioRebalancingOperationRequest
        {
            IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
            UpvestApiVersion = UpvestApiVersion._1,
            Body = new Accounts
            {
                AccountsValue = [
                    Guid.Parse("43801b85-bbcf-41c7-8389-b018082a5ec5"),
                    Guid.Parse("20151679-c159-4f16-b8a2-267b3d968c6f"),
                ],
            },
        });
    // TODO: Handle 'response' of type TriggerPortfolioRebalancingResponse
}
catch (ApiException<TriggerPortfolioRebalancingError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[TriggerPortfolioRebalancingOperationRequest](src/UpvestInvestmentApi/Requests/PortfoliosRebalancing/TriggerPortfolioRebalancingOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[TriggerPortfolioRebalancingResponse](src/UpvestInvestmentApi/Models/TriggerPortfolioRebalancingResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[TriggerPortfolioRebalancingError](src/UpvestInvestmentApi/Errors/TriggerPortfolioRebalancingError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Positions

> Source: [Positions](src/UpvestInvestmentApi/Api/Positions.cs)

<details>
<summary><code>Task&lt;PositionsListResponse&gt; ListPositions(ListPositionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the list of positions held by the account.

Use the `offset` and `limit` query parameters to page through results; `meta.total_count` gives the total number of matching positions.

See the Positions guide ([TOL](https://docs.upvest.co/products/tol/guides/positions/retrieving_positions) / [BYOL](https://docs.upvest.co/products/byol/guides/positions/retrieving_positions)) for how to interpret the `quantity`, `locked_for_trading`, `pending_settlement`, `available_for_trading`, `available_for_instruction`, and `settled_quantity` fields.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Positions.ListPositions(new ListPositionsRequest
    {
        AccountId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type PositionsListResponse
}
catch (ApiException<ListPositionsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListPositionsRequest](src/UpvestInvestmentApi/Requests/Positions/ListPositionsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PositionsListResponse](src/UpvestInvestmentApi/Models/PositionsListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListPositionsError](src/UpvestInvestmentApi/Errors/ListPositionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AccountsPositionsResponse&gt; RetrievePosition(RetrievePositionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the account's position in the given instrument.

See the Positions guide ([TOL](https://docs.upvest.co/products/tol/guides/positions/interpreting_positions) / [BYOL](https://docs.upvest.co/products/byol/guides/positions/interpreting_positions)) for how to interpret the `quantity`, `locked_for_trading`, `pending_settlement`, `available_for_trading`, `available_for_instruction`, and `settled_quantity` fields.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Positions.RetrievePosition(new RetrievePositionRequest
    {
        InstrumentId = "some example string",
        AccountId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type AccountsPositionsResponse
}
catch (ApiException<RetrievePositionError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrievePositionRequest](src/UpvestInvestmentApi/Requests/Positions/RetrievePositionRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AccountsPositionsResponse](src/UpvestInvestmentApi/Models/AccountsPositionsResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrievePositionError](src/UpvestInvestmentApi/Errors/RetrievePositionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## PriceData

> Source: [PriceData](src/UpvestInvestmentApi/Api/PriceData.cs)

<details>
<summary><code>Task&lt;InstrumentsVenuesPricesLatestResponse&gt; RetrieveInstrumentLatestPrice(RetrieveInstrumentLatestPriceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the instrument's latest price as available at the specified venue.

**NOTE**: Please note that in live mode we provide the latest prices that we receive from our data provider. However, it is to be expected that such updates will only take place on trading days.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.PriceData.RetrieveInstrumentLatestPrice(new RetrieveInstrumentLatestPriceRequest
    {
        InstrumentId = "some example string",
        VenueId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        PriceQuality = PriceQuality1.HighestAvailable,
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type InstrumentsVenuesPricesLatestResponse
}
catch (ApiException<RetrieveInstrumentLatestPriceError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveInstrumentLatestPriceRequest](src/UpvestInvestmentApi/Requests/PriceData/RetrieveInstrumentLatestPriceRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[InstrumentsVenuesPricesLatestResponse](src/UpvestInvestmentApi/Models/InstrumentsVenuesPricesLatestResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveInstrumentLatestPriceError](src/UpvestInvestmentApi/Errors/RetrieveInstrumentLatestPriceError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;InstrumentsVenuesPricesOhlcResponse&gt; RetrieveInstrumentPricesOhlc(RetrieveInstrumentPricesOhlcRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns OHLC prices for the instrument at the specified venue for the chosen time period.

If requested interval is `1d`, then the response also includes days with 0 volume. In these cases `open`, `high`, `low` are empty (`""`), but `close` is provided. If requested interval is smaller than `1d`, then the intervals with 0 volume are omitted from the response.

**NOTE**: Please note that in live mode we provide the latest prices that we receive from our data provider. However, it is to be expected that such updates will only take place on trading days.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.PriceData.RetrieveInstrumentPricesOhlc(new RetrieveInstrumentPricesOhlcRequest
    {
        InstrumentId = "some example string",
        VenueId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        StartDate = DateTimeOffset.Parse("2023-11-01T00:00:00Z"),
        EndDate = DateTimeOffset.Parse("2023-11-15T00:00:00Z"),
        AdjustedFor = AdjustedFor.None,
        Interval = "4h",
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type InstrumentsVenuesPricesOhlcResponse
}
catch (ApiException<RetrieveInstrumentPricesOhlcError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveInstrumentPricesOhlcRequest](src/UpvestInvestmentApi/Requests/PriceData/RetrieveInstrumentPricesOhlcRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[InstrumentsVenuesPricesOhlcResponse](src/UpvestInvestmentApi/Models/InstrumentsVenuesPricesOhlcResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveInstrumentPricesOhlcError](src/UpvestInvestmentApi/Errors/RetrieveInstrumentPricesOhlcError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;InstrumentsVenuesResponse&gt; RetrieveInstrumentVenues(RetrieveInstrumentVenuesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

The venues where the instrument is traded and for which the price data is available.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.PriceData.RetrieveInstrumentVenues(new RetrieveInstrumentVenuesRequest
    {
        InstrumentId = "some example string",
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type InstrumentsVenuesResponse
}
catch (ApiException<RetrieveInstrumentVenuesError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveInstrumentVenuesRequest](src/UpvestInvestmentApi/Requests/PriceData/RetrieveInstrumentVenuesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[InstrumentsVenuesResponse](src/UpvestInvestmentApi/Models/InstrumentsVenuesResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveInstrumentVenuesError](src/UpvestInvestmentApi/Errors/RetrieveInstrumentVenuesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## ReferenceAccounts

> Source: [ReferenceAccounts](src/UpvestInvestmentApi/Api/ReferenceAccounts.cs)

<details>
<summary><code>Task&lt;ReferenceAccount&gt; CreateReferenceAccount(CreateReferenceAccountRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates a new reference account for a user or business specified by ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReferenceAccounts.CreateReferenceAccount(new CreateReferenceAccountRequest
    {
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new ReferenceAccountCreateRequest
        {
            UserId = Guid.Parse("83d83ec2-d2ca-49ff-bbea-b92b5c3be202"),
            AccountOwner = "Max Mustermann",
            Name = "Max's Reference Account",
            Iban = "DE02100500000054540402",
            Bic = "BELADEBE",
            ConfirmedAt = DateTimeOffset.Parse("2020-08-23T14:15:22Z"),
        },
    });
    // TODO: Handle 'response' of type ReferenceAccount
}
catch (ApiException<CreateReferenceAccountError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateReferenceAccountRequest](src/UpvestInvestmentApi/Requests/ReferenceAccounts/CreateReferenceAccountRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ReferenceAccount](src/UpvestInvestmentApi/Models/ReferenceAccount.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateReferenceAccountError](src/UpvestInvestmentApi/Errors/CreateReferenceAccountError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task DeleteReferenceAccount(DeleteReferenceAccountRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Deletes the reference account specified by its ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.ReferenceAccounts.DeleteReferenceAccount(new DeleteReferenceAccountRequest
    {
        ReferenceAccountId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
}
catch (ApiException<DeleteReferenceAccountError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[DeleteReferenceAccountRequest](src/UpvestInvestmentApi/Requests/ReferenceAccounts/DeleteReferenceAccountRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[DeleteReferenceAccountError](src/UpvestInvestmentApi/Errors/DeleteReferenceAccountError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;BusinessReferenceAccountsListResponse&gt; ListBusinessReferenceAccounts(ListBusinessReferenceAccountsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the list of reference accounts for a business specified by ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReferenceAccounts.ListBusinessReferenceAccounts(new ListBusinessReferenceAccountsRequest
    {
        BusinessId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        Sort = Sort4.Id,
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type BusinessReferenceAccountsListResponse
}
catch (ApiException<ListBusinessReferenceAccountsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListBusinessReferenceAccountsRequest](src/UpvestInvestmentApi/Requests/ReferenceAccounts/ListBusinessReferenceAccountsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[BusinessReferenceAccountsListResponse](src/UpvestInvestmentApi/Models/BusinessReferenceAccountsListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListBusinessReferenceAccountsError](src/UpvestInvestmentApi/Errors/ListBusinessReferenceAccountsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;UsersListResponse1&gt; ListReferenceAccounts(ListReferenceAccountsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the list of reference accounts of a user specified by ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReferenceAccounts.ListReferenceAccounts(new ListReferenceAccountsRequest
    {
        UserId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        Sort = Sort4.Id,
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type UsersListResponse1
}
catch (ApiException<ListReferenceAccountsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListReferenceAccountsRequest](src/UpvestInvestmentApi/Requests/ReferenceAccounts/ListReferenceAccountsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[UsersListResponse1](src/UpvestInvestmentApi/Models/UsersListResponse1.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListReferenceAccountsError](src/UpvestInvestmentApi/Errors/ListReferenceAccountsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ReferenceAccount&gt; RetrieveReferenceAccount(RetrieveReferenceAccountRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Retrieves the reference account specified by its ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReferenceAccounts.RetrieveReferenceAccount(new RetrieveReferenceAccountRequest
    {
        ReferenceAccountId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type ReferenceAccount
}
catch (ApiException<RetrieveReferenceAccountError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveReferenceAccountRequest](src/UpvestInvestmentApi/Requests/ReferenceAccounts/RetrieveReferenceAccountRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ReferenceAccount](src/UpvestInvestmentApi/Models/ReferenceAccount.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveReferenceAccountError](src/UpvestInvestmentApi/Errors/RetrieveReferenceAccountError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Reports

> Source: [Reports](src/UpvestInvestmentApi/Api/Reports.cs)

<details>
<summary><code>Task&lt;ReportOrderExAnteCost&gt; CreateReport(CreateReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates a report from data the client submits, for either an end user or a business.

This is how clients supply the planned fee structure and order details that Upvest needs to produce a compliant MiFID II ex-ante cost report before an order is placed.

See the ex-ante cost report data submission guide ([TOL](https://docs.upvest.co/products/tol/guides/reports/ex-ante_reports_data) / [BYOL](https://docs.upvest.co/products/byol/guides/reports/ex-ante_reports_data)) for the required fee and order data.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Reports.CreateReport(new CreateReportRequest
    {
        UpvestApiVersion = UpvestApiVersion._1,
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        Body = new ReportOrderExAnteCostCreateRequestRegular
        {
            Type = "ORDER_EX_ANTE_COST",
            Order = new ExAnteCostBusinessOrder
            {
                BusinessId = Guid.Parse("d1a4be99-8bb6-4e78-b897-8168f6823ab5"),
                AccountId = Guid.Parse("c5034305-c441-4711-adbf-93cfbc13a695"),
                CashAmount = "1000.00",
                Currency = Currency.Eur,
                Side = Side8.Sell,
                InstrumentId = "LU0274208692",
                OrderType = OrderType4.Market,
            },
            Fees = [
                new AbsoluteFee4
                {
                    Type = FeeType8.TransactionFeeBuy,
                    ValueType = "ABSOLUTE",
                    CashAmount = "1.00",
                    Currency = Currency.Eur,
                },
                new TransactionFee
                {
                    Type = FeeType10.TransactionFeeSell,
                    TransactionFeeModelId = Guid.Parse("eb5ba93f-5dfe-4bf1-84da-0caacc80c111"),
                },
                new RelativeFee { Type = FeeType8.AnnualAumBasedFee, ValueType = "RELATIVE", Bps = "10" },
            ],
        },
    });
    // TODO: Handle 'response' of type ReportOrderExAnteCost
}
catch (ApiException<CreateReportError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateReportRequest](src/UpvestInvestmentApi/Requests/Reports/CreateReportRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ReportOrderExAnteCost](src/UpvestInvestmentApi/Models/AnyOf/ReportOrderExAnteCost.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateReportError](src/UpvestInvestmentApi/Errors/CreateReportError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;BusinessReportsListResponse&gt; ListBusinessReports(ListBusinessReportsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a paginated list of reports generated for the business identified by `business_id`.

Use the `offset` and `limit` query parameters to page through results; `meta.total_count` gives the total number of matching reports. Use `type` and `instrument` to filter results, and `start_date`/`end_date` to limit the range of report generation dates.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Reports.ListBusinessReports(new ListBusinessReportsRequest
    {
        BusinessId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        Type = ReportType.BuyOrder,
        Instrument = "uuid:ebabcf4d-61c3-4942-875c-e265a7c2d062",
        StartDate = DateTimeOffset.Parse("2020-08-21T00:00:00Z"),
        EndDate = DateTimeOffset.Parse("2020-09-25T00:00:00Z"),
        Sort = Sort4.Id,
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type BusinessReportsListResponse
}
catch (ApiException<ListBusinessReportsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListBusinessReportsRequest](src/UpvestInvestmentApi/Requests/Reports/ListBusinessReportsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[BusinessReportsListResponse](src/UpvestInvestmentApi/Models/BusinessReportsListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListBusinessReportsError](src/UpvestInvestmentApi/Errors/ListBusinessReportsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ReportsListResponse&gt; ListUserReports(ListUserReportsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the list of reports generated for the end user identified by `user_id`.

Narrow the list with the `type`, `instrument`, `start_date`, and `end_date` query parameters, and page through results with `offset` and `limit`; `meta.total_count` gives the total number of matching reports. Subscribe to the `REPORT.CREATED` webhook event to be notified as reports are generated, rather than polling this endpoint.

See the accessing end user reports guide ([TOL](https://docs.upvest.co/products/tol/guides/reports/user_reports_access) / [BYOL](https://docs.upvest.co/products/byol/guides/reports/user_reports_access)) for the available report types and query parameters.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Reports.ListUserReports(new ListUserReportsRequest
    {
        UserId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        Type = ReportType.BuyOrder,
        Instrument = "uuid:ebabcf4d-61c3-4942-875c-e265a7c2d062",
        StartDate = DateTimeOffset.Parse("2020-08-21T00:00:00Z"),
        EndDate = DateTimeOffset.Parse("2020-09-25T00:00:00Z"),
        Sort = Sort23.Id,
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type ReportsListResponse
}
catch (ApiException<ListUserReportsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListUserReportsRequest](src/UpvestInvestmentApi/Requests/Reports/ListUserReportsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ReportsListResponse](src/UpvestInvestmentApi/Models/ReportsListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListUserReportsError](src/UpvestInvestmentApi/Errors/ListUserReportsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Report&gt; RetrieveReport(RetrieveReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Retrieve a report for either a natural person or a business entity.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Reports.RetrieveReport(new RetrieveReportRequest
    {
        ReportId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type Report
}
catch (ApiException<RetrieveReportError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveReportRequest](src/UpvestInvestmentApi/Requests/Reports/RetrieveReportRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Report](src/UpvestInvestmentApi/Models/AnyOf/Report.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveReportError](src/UpvestInvestmentApi/Errors/RetrieveReportError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Returns

> Source: [Returns](src/UpvestInvestmentApi/Api/Returns.cs)

<details>
<summary><code>Task&lt;AccountReturnListResponse&gt; ListAccountReturns(ListAccountReturnsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the account's daily time-weighted return (TWR), which measures investment performance independently of deposits, withdrawals, and other external cash flows.

Use the `offset` and `limit` query parameters to page through results; `meta.total_count` gives the total number of matching returns.

See the Time-weighted returns guide ([TOL](https://docs.upvest.co/products/tol/guides/reports/account_reports_time-weighted-returns) / [BYOL](https://docs.upvest.co/products/byol/guides/reports/account_reports_time-weighted-returns)) for the calculation method.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Returns.ListAccountReturns(new ListAccountReturnsRequest
    {
        AccountId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        StartDate = "2023-08-15",
        EndDate = "2023-08-15",
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type AccountReturnListResponse
}
catch (ApiException<ListAccountReturnsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListAccountReturnsRequest](src/UpvestInvestmentApi/Requests/Returns/ListAccountReturnsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AccountReturnListResponse](src/UpvestInvestmentApi/Models/AccountReturnListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListAccountReturnsError](src/UpvestInvestmentApi/Errors/ListAccountReturnsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Roles

> Source: [Roles](src/UpvestInvestmentApi/Api/Roles.cs)

<details>
<summary><code>Task&lt;RoleCreateResponse&gt; CreateRole(CreateRoleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates a role, assigning a user to an account group or business entity.

The `entity_type` parameter determines whether `entity_id` refers to an account group or a business, and constrains which `role_type` values are valid.

See the User roles guide ([TOL](https://docs.upvest.co/products/tol/guides/users/users_onboarding_roles) / [BYOL](https://docs.upvest.co/products/byol/guides/users/users_onboarding_roles)) for role types and assignment rules.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Roles.CreateRole(new CreateRoleRequest
    {
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new AccountGroupRoleCreateRequest
        {
            UserId = Guid.Parse("9c36af78-91a0-4174-a515-fc81214e3dab"),
            EntityType = "ACCOUNT_GROUP",
            EntityId = Guid.Parse("413715f2-5401-4b97-8055-034a6b879f8c"),
            RoleType = RoleType2.Guardian,
            CustodyType = CustodyType.SoleCustody,
        },
    });
    // TODO: Handle 'response' of type RoleCreateResponse
}
catch (ApiException<CreateRoleError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateRoleRequest](src/UpvestInvestmentApi/Requests/Roles/CreateRoleRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[RoleCreateResponse](src/UpvestInvestmentApi/Models/AnyOf/RoleCreateResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateRoleError](src/UpvestInvestmentApi/Errors/CreateRoleError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;RolesListResponse&gt; ListRoles(ListRolesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a paginated list of roles.

Use the `offset` and `limit` query parameters to page through results; `meta.total_count` gives the total number of matching roles. Use `user_id` to filter by a specific user, `entity_id` to filter by account group or business, and `sort`/`order` to control the ordering by `created_at` or `updated_at`.

See the User roles guide ([TOL](https://docs.upvest.co/products/tol/guides/users/users_onboarding_roles) / [BYOL](https://docs.upvest.co/products/byol/guides/users/users_onboarding_roles)) for role types and assignment rules.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Roles.ListRoles(new ListRolesRequest
    {
        UserIdTemplate = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type RolesListResponse
}
catch (ApiException<ListRolesError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListRolesRequest](src/UpvestInvestmentApi/Requests/Roles/ListRolesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[RolesListResponse](src/UpvestInvestmentApi/Models/RolesListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListRolesError](src/UpvestInvestmentApi/Errors/ListRolesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;RoleRetrieveResponse&gt; RetrieveRole(RetrieveRoleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the role identified by `role_id`, including its status and entity assignment.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Roles.RetrieveRole(new RetrieveRoleRequest
    {
        RoleId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type RoleRetrieveResponse
}
catch (ApiException<RetrieveRoleError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveRoleRequest](src/UpvestInvestmentApi/Requests/Roles/RetrieveRoleRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[RoleRetrieveResponse](src/UpvestInvestmentApi/Models/AnyOf/RoleRetrieveResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveRoleError](src/UpvestInvestmentApi/Errors/RetrieveRoleError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task RoleDeactivation(RoleDeactivationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Deactivates the role specified by its ID. The role remains queryable with status `DEACTIVATED`.
Only roles whose `entity_type` is `BUSINESS` may be deactivated via this endpoint; account-group roles are rejected with `403 Forbidden`.
Deactivation is a terminal state; once deactivated, a role cannot be reactivated.
Deactivation is idempotent: calling this endpoint on an already-deactivated role returns `202 Accepted` without side effects.
A `ROLE.DEACTIVATED` webhook event is emitted on the first successful deactivation.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.Roles.RoleDeactivation(new RoleDeactivationRequest
    {
        RoleId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
}
catch (ApiException<RoleDeactivationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RoleDeactivationRequest](src/UpvestInvestmentApi/Requests/Roles/RoleDeactivationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RoleDeactivationError](src/UpvestInvestmentApi/Errors/RoleDeactivationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## SavingsPlans

> Source: [SavingsPlans](src/UpvestInvestmentApi/Api/SavingsPlans.cs)

<details>
<summary><code>Task&lt;SavingsPlanInstrument&gt; CreateSavingsPlan(CreateSavingsPlanRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates a recurring savings plan that automatically invests a fixed cash amount at a defined frequency.

Set `type` to `INSTRUMENT` to invest in a single instrument, or `PORTFOLIO` to distribute the investment across the account's portfolio allocation.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SavingsPlans.CreateSavingsPlan(new CreateSavingsPlanRequest
    {
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new SavingsPlanInstrument3
        {
            UserId = Guid.Parse("fc34d28e-38f5-49d2-92f6-82acb79098f4"),
            AccountId = Guid.Parse("00ef0be8-d564-43af-b3c7-11b7a2188030"),
            Name = "Instrument savings plan",
            Type = "INSTRUMENT",
            InstrumentId = "DE0007664005",
            InstrumentIdType = InstrumentIdType10.Isin,
            CashAmount = "100.00",
            Currency = Currency.Eur,
            StartDate = "2023-07-24",
            Period = Period1.Week,
            Interval = 2,
            FeeConfiguration = [
                new SavingsPlanFeeConfigurationOnlyForInstrument
                {
                    TransactionFeeModelId = Guid.Parse("3ae9403c-1611-46eb-84ee-e06a02bcfd08"),
                },
            ],
            Funding = new SavingsPlanFunding { MandateId = Guid.Parse("3ae9403c-1611-46eb-84ee-e06a02bcfd08") },
        },
    });
    // TODO: Handle 'response' of type SavingsPlanInstrument
}
catch (ApiException<CreateSavingsPlanError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateSavingsPlanRequest](src/UpvestInvestmentApi/Requests/SavingsPlans/CreateSavingsPlanRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SavingsPlanInstrument](src/UpvestInvestmentApi/Models/SavingsPlanInstrument.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateSavingsPlanError](src/UpvestInvestmentApi/Errors/CreateSavingsPlanError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task DeleteSavingsPlan(DeleteSavingsPlanRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Delete a savings plan specified by its ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.SavingsPlans.DeleteSavingsPlan(new DeleteSavingsPlanRequest
    {
        SavingsPlanId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
}
catch (ApiException<DeleteSavingsPlanError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[DeleteSavingsPlanRequest](src/UpvestInvestmentApi/Requests/SavingsPlans/DeleteSavingsPlanRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[DeleteSavingsPlanError](src/UpvestInvestmentApi/Errors/DeleteSavingsPlanError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task DeleteSavingsPlanExecution(DeleteSavingsPlanExecutionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Deletes a scheduled savings plan execution before it has been processed. Only executions in the `NEW` status can be deleted.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.SavingsPlans.DeleteSavingsPlanExecution(new DeleteSavingsPlanExecutionRequest
    {
        SavingsPlanId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        SavingsPlanExecutionId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
}
catch (ApiException<DeleteSavingsPlanExecutionError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[DeleteSavingsPlanExecutionRequest](src/UpvestInvestmentApi/Requests/SavingsPlans/DeleteSavingsPlanExecutionRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[DeleteSavingsPlanExecutionError](src/UpvestInvestmentApi/Errors/DeleteSavingsPlanExecutionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;SavingsPlanExecutionListResponse&gt; ListSavingsPlanExecutions(ListSavingsPlanExecutionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

List savings plan executions for a saving plan specified by its ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SavingsPlans.ListSavingsPlanExecutions(new ListSavingsPlanExecutionsRequest
    {
        SavingsPlanId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        StartDate = "2022-10-14T10:10:10Z",
        EndDate = "2022-10-14T10:10:10Z",
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type SavingsPlanExecutionListResponse
}
catch (ApiException<ListSavingsPlanExecutionsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListSavingsPlanExecutionsRequest](src/UpvestInvestmentApi/Requests/SavingsPlans/ListSavingsPlanExecutionsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SavingsPlanExecutionListResponse](src/UpvestInvestmentApi/Models/SavingsPlanExecutionListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListSavingsPlanExecutionsError](src/UpvestInvestmentApi/Errors/ListSavingsPlanExecutionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;SavingsPlanListResponse&gt; ListSavingsPlans(ListSavingsPlansRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a paginated list of savings plans for the authenticated client.

Savings plans can be of type `INSTRUMENT` (recurring buy of a single instrument) or `PORTFOLIO` (recurring investment distributed across the account's portfolio allocation).

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SavingsPlans.ListSavingsPlans(new ListSavingsPlansRequest
    {
        AccountId = "3ada8e9e-82c4-4c78-a43d-a691b1636509",
        UserId = "996e5e2c-bb76-4a38-8d5c-ff43d86904da",
        InstrumentId = "FR0010524777",
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type SavingsPlanListResponse
}
catch (ApiException<ListSavingsPlansError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListSavingsPlansRequest](src/UpvestInvestmentApi/Requests/SavingsPlans/ListSavingsPlansRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SavingsPlanListResponse](src/UpvestInvestmentApi/Models/SavingsPlanListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListSavingsPlansError](src/UpvestInvestmentApi/Errors/ListSavingsPlansError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;SavingsPlanInstrument&gt; RetrieveSavingsPlan(RetrieveSavingsPlanRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Retrieve a savings plan specified by its ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SavingsPlans.RetrieveSavingsPlan(new RetrieveSavingsPlanRequest
    {
        SavingsPlanId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type SavingsPlanInstrument
}
catch (ApiException<RetrieveSavingsPlanError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveSavingsPlanRequest](src/UpvestInvestmentApi/Requests/SavingsPlans/RetrieveSavingsPlanRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SavingsPlanInstrument](src/UpvestInvestmentApi/Models/SavingsPlanInstrument.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveSavingsPlanError](src/UpvestInvestmentApi/Errors/RetrieveSavingsPlanError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;SavingsPlanExecution&gt; RetrieveSavingsPlanExecution(RetrieveSavingsPlanExecutionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Retrieves a single execution of a savings plan by its ID, including the order placed and its current status.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SavingsPlans.RetrieveSavingsPlanExecution(new RetrieveSavingsPlanExecutionRequest
    {
        SavingsPlanId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        SavingsPlanExecutionId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type SavingsPlanExecution
}
catch (ApiException<RetrieveSavingsPlanExecutionError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveSavingsPlanExecutionRequest](src/UpvestInvestmentApi/Requests/SavingsPlans/RetrieveSavingsPlanExecutionRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SavingsPlanExecution](src/UpvestInvestmentApi/Models/AnyOf/SavingsPlanExecution.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveSavingsPlanExecutionError](src/UpvestInvestmentApi/Errors/RetrieveSavingsPlanExecutionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;SavingsPlanInstrument&gt; UpdateSavingsPlan(UpdateSavingsPlanRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Updates the funding configuration of the savings plan specified by its ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SavingsPlans.UpdateSavingsPlan(new UpdateSavingsPlanRequest
    {
        SavingsPlanId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new SavingsPlanUpdateRequest
        {
            Funding = new SavingsPlanFunding { MandateId = Guid.Parse("3ae9403c-1611-46eb-84ee-e06a02bcfd08") },
        },
    });
    // TODO: Handle 'response' of type SavingsPlanInstrument
}
catch (ApiException<UpdateSavingsPlanError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateSavingsPlanRequest](src/UpvestInvestmentApi/Requests/SavingsPlans/UpdateSavingsPlanRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SavingsPlanInstrument](src/UpvestInvestmentApi/Models/SavingsPlanInstrument.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[UpdateSavingsPlanError](src/UpvestInvestmentApi/Errors/UpdateSavingsPlanError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## SecuritiesTransfers

> Source: [SecuritiesTransfers](src/UpvestInvestmentApi/Api/SecuritiesTransfers.cs)

<details>
<summary><code>Task&lt;SecuritiesTransfersResponse&gt; CreateSecuritiesTransfer(CreateSecuritiesTransferRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates a securities transfer, moving a position in a single instrument between an Upvest account and an external custodian.

Set `direction` to `INCOMING` to move securities into an Upvest account, or `OUTGOING` to move them out to an external custodian. Only full units can be transferred — fractional quantities are not supported by the SWIFT messaging used for settlement. Unfulfilled incoming transfer requests are cancelled automatically after 30 days.

See the securities transfers guide ([TOL](https://docs.upvest.co/products/tol/guides/transfers/securities_transfers_overview) / [BYOL](https://docs.upvest.co/products/byol/guides/transfers/securities_transfers_overview) / [Omnibus](https://docs.upvest.co/products/omnibus/guides/transfers/securities_transfers_overview)) for the transfer stages and settlement details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SecuritiesTransfers.CreateSecuritiesTransfer(new CreateSecuritiesTransferRequest
    {
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new TransfersSecuritiesTransferCreateRequest
        {
            Direction = Direction1.Incoming,
            InstrumentId = "US0378331005",
            Quantity = "10",
            UserId = Guid.Parse("7e9a0529-d289-4f4a-ae01-c2cd013d582e"),
            AccountId = Guid.Parse("d396b7c3-aa67-488a-8e39-4a1a7cbeb9f4"),
            Counterparty = new SecuritiesTransferCounterpartyBic
            {
                Type = "BIC",
                Id = "DUMBZZ33XXX",
                AccountNumber = "1234567891",
                Name = "Max Mustermann",
            },
            OrderDate = DateTimeOffset.Parse("2024-01-20T00:00:00Z"),
        },
    });
    // TODO: Handle 'response' of type SecuritiesTransfersResponse
}
catch (ApiException<CreateSecuritiesTransferError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateSecuritiesTransferRequest](src/UpvestInvestmentApi/Requests/SecuritiesTransfers/CreateSecuritiesTransferRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SecuritiesTransfersResponse](src/UpvestInvestmentApi/Models/SecuritiesTransfersResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateSecuritiesTransferError](src/UpvestInvestmentApi/Errors/CreateSecuritiesTransferError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;SecurityTransfersListResponse&gt; ListSecuritiesTransfers(ListSecuritiesTransfersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the list of securities transfers.

Restrict the list to one direction with the `direction` query parameter, and page through results with the `offset` and `limit` query parameters; `meta.total_count` gives the total number of matching transfers.

See the securities transfers guide ([TOL](https://docs.upvest.co/products/tol/guides/transfers/securities_transfers_overview) / [BYOL](https://docs.upvest.co/products/byol/guides/transfers/securities_transfers_overview) / [Omnibus](https://docs.upvest.co/products/omnibus/guides/transfers/securities_transfers_overview)) for the transfer stages and settlement details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.SecuritiesTransfers.ListSecuritiesTransfers(new ListSecuritiesTransfersRequest
    {
        Direction = Direction.Incoming,
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type SecurityTransfersListResponse
}
catch (ApiException<ListSecuritiesTransfersError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListSecuritiesTransfersRequest](src/UpvestInvestmentApi/Requests/SecuritiesTransfers/ListSecuritiesTransfersRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SecurityTransfersListResponse](src/UpvestInvestmentApi/Models/SecurityTransfersListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListSecuritiesTransfersError](src/UpvestInvestmentApi/Errors/ListSecuritiesTransfersError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## TaxExemptions

> Source: [TaxExemptions](src/UpvestInvestmentApi/Api/TaxExemptions.cs)

<details>
<summary><code>Task&lt;WebhookTaxExemptionCreatedTaxExemption&gt; CreateTaxExemption(CreateTaxExemptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates a tax exemption order for end users who are resident in Germany for tax purposes.

Upvest must hold the end user's Tax Identification Number before an exemption can be created. The request is processed asynchronously: the exemption is created with status `NEW` and moves to `ACTIVE`, which is signalled by a `TAX_EXEMPTION` webhook event. A single exemption covers exactly one `user_ids` entry and an allowance of up to €1,000 per tax year; a joint exemption requires exactly two entries and covers up to €2,000.

See the [Creating a tax exemption order guide](https://docs.upvest.co/products/tol/guides/taxes/tax_exemptions_creating) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.TaxExemptions.CreateTaxExemption(new CreateTaxExemptionRequest
    {
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new TaxesTaxExemptionsCreateRequest
        {
            UserIds = [Guid.Parse("70fd317b-81e1-4f21-9f7e-3b5cb4dfe686")],
            TaxExemptionDetails = new TaxExemptionRequestGermanTaxExemptionDetails
            {
                TaxExemptionType = TaxExemptionType.Single,
                TaxExemptionAmount = new TaxExemptionCreateRequestTaxExemptionDetailsAmount
                {
                    Amount = "1000",
                    Currency = Currency.Eur,
                },
            },
            Country = "DE",
            ValidToDate = DateTimeOffset.Parse("2026-12-31T00:00:00Z"),
        },
    });
    // TODO: Handle 'response' of type WebhookTaxExemptionCreatedTaxExemption
}
catch (ApiException<CreateTaxExemptionError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateTaxExemptionRequest](src/UpvestInvestmentApi/Requests/TaxExemptions/CreateTaxExemptionRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[WebhookTaxExemptionCreatedTaxExemption](src/UpvestInvestmentApi/Models/WebhookTaxExemptionCreatedTaxExemption.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateTaxExemptionError](src/UpvestInvestmentApi/Errors/CreateTaxExemptionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task DeleteTaxExemption(DeleteTaxExemptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Deletes the tax exemption order identified by `tax_exemption_id` and stops it renewing in subsequent tax years.

Deletion succeeds only while none of the associated end users have claimed an exemption amount in the current tax year. If any amount has already been used, the exemption remains active and the request fails.

See the [Deleting a tax exemption order guide](https://docs.upvest.co/products/tol/guides/taxes/tax_exemptions_deleting) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.TaxExemptions.DeleteTaxExemption(new DeleteTaxExemptionRequest
    {
        TaxExemptionId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
}
catch (ApiException<DeleteTaxExemptionError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[DeleteTaxExemptionRequest](src/UpvestInvestmentApi/Requests/TaxExemptions/DeleteTaxExemptionRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[DeleteTaxExemptionError](src/UpvestInvestmentApi/Errors/DeleteTaxExemptionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;WebhookTaxExemptionCreatedTaxExemption&gt; RetrieveTaxExemptionById(RetrieveTaxExemptionByIdRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the tax exemption order identified by `tax_exemption_id`, including its status and the allowance used and remaining for the tax year.

See the [Retrieving tax exemption orders guide](https://docs.upvest.co/products/tol/guides/taxes/tax_exemptions_get) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.TaxExemptions.RetrieveTaxExemptionById(new RetrieveTaxExemptionByIdRequest
    {
        TaxExemptionId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type WebhookTaxExemptionCreatedTaxExemption
}
catch (ApiException<RetrieveTaxExemptionByIdError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveTaxExemptionByIdRequest](src/UpvestInvestmentApi/Requests/TaxExemptions/RetrieveTaxExemptionByIdRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[WebhookTaxExemptionCreatedTaxExemption](src/UpvestInvestmentApi/Models/WebhookTaxExemptionCreatedTaxExemption.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveTaxExemptionByIdError](src/UpvestInvestmentApi/Errors/RetrieveTaxExemptionByIdError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;TaxExemptionRetrieveForUserResponse&gt; RetrieveTaxExemptionsForUser(RetrieveTaxExemptionsForUserRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the tax exemption orders of the end user identified by `user_id`.

Use the `offset` and `limit` query parameters to page through results; `meta.total_count` gives the total number of matching tax exemptions.

See the [Retrieving tax exemption orders guide](https://docs.upvest.co/products/tol/guides/taxes/tax_exemptions_get) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.TaxExemptions.RetrieveTaxExemptionsForUser(new RetrieveTaxExemptionsForUserRequest
    {
        UserId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type TaxExemptionRetrieveForUserResponse
}
catch (ApiException<RetrieveTaxExemptionsForUserError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveTaxExemptionsForUserRequest](src/UpvestInvestmentApi/Requests/TaxExemptions/RetrieveTaxExemptionsForUserRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[TaxExemptionRetrieveForUserResponse](src/UpvestInvestmentApi/Models/TaxExemptionRetrieveForUserResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveTaxExemptionsForUserError](src/UpvestInvestmentApi/Errors/RetrieveTaxExemptionsForUserError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;WebhookTaxExemptionCreatedTaxExemption&gt; UpdateTaxExemption(UpdateTaxExemptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Updates the tax exemption order identified by `tax_exemption_id`.

See the [Updating a tax exemption guide](https://docs.upvest.co/products/tol/guides/taxes/tax_exemptions_update) for the rules governing reduction, increase, and cancellation of an exemption.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.TaxExemptions.UpdateTaxExemption(new UpdateTaxExemptionRequest
    {
        TaxExemptionId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new TaxesTaxExemptionsUpdateRequest
        {
            UserIds = [Guid.Parse("70fd317b-81e1-4f21-9f7e-3b5cb4dfe686")],
            TaxExemptionDetails = new TaxExemptionRequestGermanTaxExemptionDetails
            {
                TaxExemptionType = TaxExemptionType.Single,
                TaxExemptionAmount = new TaxExemptionCreateRequestTaxExemptionDetailsAmount
                {
                    Amount = "955",
                    Currency = Currency.Eur,
                },
            },
            Country = "DE",
            ValidToDate = DateTimeOffset.Parse("2026-12-31T00:00:00Z"),
        },
    });
    // TODO: Handle 'response' of type WebhookTaxExemptionCreatedTaxExemption
}
catch (ApiException<UpdateTaxExemptionError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateTaxExemptionRequest](src/UpvestInvestmentApi/Requests/TaxExemptions/UpdateTaxExemptionRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[WebhookTaxExemptionCreatedTaxExemption](src/UpvestInvestmentApi/Models/WebhookTaxExemptionCreatedTaxExemption.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[UpdateTaxExemptionError](src/UpvestInvestmentApi/Errors/UpdateTaxExemptionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## TaxResidencies

> Source: [TaxResidencies](src/UpvestInvestmentApi/Api/TaxResidencies.cs)

<details>
<summary><code>Task&lt;TaxResidencyRecord&gt; RetrieveTaxResidencies(RetrieveTaxResidenciesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the tax residencies currently on file for the user identified by `user_id`.

See the User tax onboarding guide ([TOL](https://docs.upvest.co/products/tol/guides/users/users_tax_onboarding) / [BYOL](https://docs.upvest.co/products/byol/guides/users/users_tax_onboarding)) for tax residency requirements.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.TaxResidencies.RetrieveTaxResidencies(new RetrieveTaxResidenciesRequest
    {
        UserId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type TaxResidencyRecord
}
catch (ApiException<RetrieveTaxResidenciesError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveTaxResidenciesRequest](src/UpvestInvestmentApi/Requests/TaxResidencies/RetrieveTaxResidenciesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[TaxResidencyRecord](src/UpvestInvestmentApi/Models/TaxResidencyRecord.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveTaxResidenciesError](src/UpvestInvestmentApi/Errors/RetrieveTaxResidenciesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;TaxResidencyRecord&gt; SetTaxResidencies(SetTaxResidenciesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Records the tax residencies for the user identified by `user_id`, replacing any previously submitted set.

See the User tax onboarding guide ([TOL](https://docs.upvest.co/products/tol/guides/users/users_tax_onboarding) / [BYOL](https://docs.upvest.co/products/byol/guides/users/users_tax_onboarding)) for tax residency requirements.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.TaxResidencies.SetTaxResidencies(new SetTaxResidenciesRequest
    {
        UserId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new TaxResidenciesSetRequest
        {
            TaxResidencies = [
                new WithTaxIdentifierNumber { Country = Country.De, TaxIdentifierNumber = "12345678901" },
            ],
        },
    });
    // TODO: Handle 'response' of type TaxResidencyRecord
}
catch (ApiException<SetTaxResidenciesError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[SetTaxResidenciesRequest](src/UpvestInvestmentApi/Requests/TaxResidencies/SetTaxResidenciesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[TaxResidencyRecord](src/UpvestInvestmentApi/Models/TaxResidencyRecord.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[SetTaxResidenciesError](src/UpvestInvestmentApi/Errors/SetTaxResidenciesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Tests

> Source: [Tests](src/UpvestInvestmentApi/Api/Tests.cs)

<details>
<summary><code>Task&lt;PaymentsBankTransactionCreateResponse&gt; CreateBankTransaction(CreateBankTransactionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Trigger a bank transaction for testing purposes. This can be used to simulate a money transfer for various flows which need cash settlements on one of our bank accounts.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Tests.CreateBankTransaction(new CreateBankTransactionRequest
    {
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new PaymentsBankTransactionCreateRequest
        {
            Account = new Account29 { Iban = "NL70ABNA0106295004" },
            Amount = "13.37",
            Currency = BankTransactionCurrency.Eur,
            RemittanceInformation = "remittance-info",
            ClientReference = "client-reference",
            CounterpartyName = "counterparty-name",
            CounterpartyAccount = new CounterpartyAccount { Iban = "DE95500105173934555844" },
            CounterpartyAgent = new CounterpartyAgent { Bic = "DEUTDEFF" },
            VirtualBankAccountId = Guid.Parse("f7b3b3b3-7b3b-4b3b-8b3b-3b3b3b3b3b3b"),
            PurposeCode = "OTHR",
        },
    });
    // TODO: Handle 'response' of type PaymentsBankTransactionCreateResponse
}
catch (ApiException<CreateBankTransactionError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateBankTransactionRequest](src/UpvestInvestmentApi/Requests/Tests/CreateBankTransactionRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PaymentsBankTransactionCreateResponse](src/UpvestInvestmentApi/Models/PaymentsBankTransactionCreateResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateBankTransactionError](src/UpvestInvestmentApi/Errors/CreateBankTransactionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## TopUps

> Source: [TopUps](src/UpvestInvestmentApi/Api/TopUps.cs)

<details>
<summary><code>Task CancelTopup(CancelTopupRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Cancels a top-up specified by its ID. It is only possible to cancel a top-up if it has the status `CONFIRMED`.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.TopUps.CancelTopup(new CancelTopupRequest
    {
        TopupId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
}
catch (ApiException<CancelTopupError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CancelTopupRequest](src/UpvestInvestmentApi/Requests/TopUps/CancelTopupRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CancelTopupError](src/UpvestInvestmentApi/Errors/CancelTopupError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PaymentsTopupsResponse&gt; CreateTopup(CreateTopupRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates a top-up request for an account group and returns a `settlement_reference`. The end user must then send a SEPA Credit Transfer including that reference to complete the funding.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.TopUps.CreateTopup(new CreateTopupRequest
    {
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new PaymentsTopUpCreateRequest
        {
            AccountGroupId = Guid.Parse("1ea60f56-b67b-61fc-829a-0242ac130003"),
            CashAmount = "200.00",
            Currency = Currency.Eur,
        },
    });
    // TODO: Handle 'response' of type PaymentsTopupsResponse
}
catch (ApiException<CreateTopupError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateTopupRequest](src/UpvestInvestmentApi/Requests/TopUps/CreateTopupRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PaymentsTopupsResponse](src/UpvestInvestmentApi/Models/PaymentsTopupsResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateTopupError](src/UpvestInvestmentApi/Errors/CreateTopupError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PaymentsTopUpsListResponse&gt; ListTopups(ListTopupsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a list of top-ups.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.TopUps.ListTopups(new ListTopupsRequest
    {
        AccountGroupId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        Sort = Sort4.Id,
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type PaymentsTopUpsListResponse
}
catch (ApiException<ListTopupsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListTopupsRequest](src/UpvestInvestmentApi/Requests/TopUps/ListTopupsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PaymentsTopUpsListResponse](src/UpvestInvestmentApi/Models/PaymentsTopUpsListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListTopupsError](src/UpvestInvestmentApi/Errors/ListTopupsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PaymentsTopupsResponse&gt; RetrieveTopup(RetrieveTopupRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a top-up specified by its ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.TopUps.RetrieveTopup(new RetrieveTopupRequest
    {
        TopupId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type PaymentsTopupsResponse
}
catch (ApiException<RetrieveTopupError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveTopupRequest](src/UpvestInvestmentApi/Requests/TopUps/RetrieveTopupRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PaymentsTopupsResponse](src/UpvestInvestmentApi/Models/PaymentsTopupsResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveTopupError](src/UpvestInvestmentApi/Errors/RetrieveTopupError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## TransactionFeesConfigurations

> Source: [TransactionFeesConfigurations](src/UpvestInvestmentApi/Api/TransactionFeesConfigurations.cs)

<details>
<summary><code>Task&lt;TransactionFeeAccountGroupConfiguration&gt; CreateTransactionFeeAccountGroupConfiguration(CreateTransactionFeeAccountGroupConfigurationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Assigns a transaction fee model to an account group for a transaction category.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.TransactionFeesConfigurations.CreateTransactionFeeAccountGroupConfiguration(
        new CreateTransactionFeeAccountGroupConfigurationRequest
        {
            UpvestApiVersion = UpvestApiVersion._1,
            Body = new TransactionFeeAccountGroupConfigurationCreateRequest
            {
                FeeModelId = Guid.Parse("eb5ba93f-5dfe-4bf1-8571-4da0caacc80c"),
                AccountGroupId = Guid.Parse("7524949b-31fd-497e-ad92-f52de45341d1"),
                TransactionCategory = TransactionCategory.PensionDeContribution,
            },
        });
    // TODO: Handle 'response' of type TransactionFeeAccountGroupConfiguration
}
catch (ApiException<CreateTransactionFeeAccountGroupConfigurationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateTransactionFeeAccountGroupConfigurationRequest](src/UpvestInvestmentApi/Requests/TransactionFeesConfigurations/CreateTransactionFeeAccountGroupConfigurationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[TransactionFeeAccountGroupConfiguration](src/UpvestInvestmentApi/Models/TransactionFeeAccountGroupConfiguration.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateTransactionFeeAccountGroupConfigurationError](src/UpvestInvestmentApi/Errors/CreateTransactionFeeAccountGroupConfigurationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task DeleteTransactionFeeAccountGroupConfiguration(DeleteTransactionFeeAccountGroupConfigurationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Removes a transaction fee configuration from an account group. Fee intakes already executed under the deleted configuration are unaffected.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.TransactionFeesConfigurations.DeleteTransactionFeeAccountGroupConfiguration(
        new DeleteTransactionFeeAccountGroupConfigurationRequest
        {
            AccountGroupId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
            Id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
            UpvestApiVersion = UpvestApiVersion._1,
        });
}
catch (ApiException<DeleteTransactionFeeAccountGroupConfigurationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[DeleteTransactionFeeAccountGroupConfigurationRequest](src/UpvestInvestmentApi/Requests/TransactionFeesConfigurations/DeleteTransactionFeeAccountGroupConfigurationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[DeleteTransactionFeeAccountGroupConfigurationError](src/UpvestInvestmentApi/Errors/DeleteTransactionFeeAccountGroupConfigurationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;TransactionFeeAccountGroupConfigurationsListResponse&gt; ListTransactionFeeAccountGroupConfigurations(ListTransactionFeeAccountGroupConfigurationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a paginated list of the transaction fee configurations assigned to the account group identified by `id`, with at most one configuration per `transaction_category`.

Returns an empty list if the account group has no configurations, and `404` if the account group does not exist.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.TransactionFeesConfigurations.ListTransactionFeeAccountGroupConfigurations(
        new ListTransactionFeeAccountGroupConfigurationsRequest
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
            UpvestApiVersion = UpvestApiVersion._1,
        });
    // TODO: Handle 'response' of type TransactionFeeAccountGroupConfigurationsListResponse
}
catch (ApiException<ListTransactionFeeAccountGroupConfigurationsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListTransactionFeeAccountGroupConfigurationsRequest](src/UpvestInvestmentApi/Requests/TransactionFeesConfigurations/ListTransactionFeeAccountGroupConfigurationsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[TransactionFeeAccountGroupConfigurationsListResponse](src/UpvestInvestmentApi/Models/TransactionFeeAccountGroupConfigurationsListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListTransactionFeeAccountGroupConfigurationsError](src/UpvestInvestmentApi/Errors/ListTransactionFeeAccountGroupConfigurationsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;TransactionFeeAccountGroupConfiguration&gt; UpdateTransactionFeeAccountGroupConfiguration(UpdateTransactionFeeAccountGroupConfigurationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Update the fee model assigned by an existing transaction fee account group configuration.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.TransactionFeesConfigurations.UpdateTransactionFeeAccountGroupConfiguration(
        new UpdateTransactionFeeAccountGroupConfigurationRequest
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
            UpvestApiVersion = UpvestApiVersion._1,
            Body = new TransactionFeeAccountGroupConfigurationUpdateRequest
            {
                FeeModelId = Guid.Parse("eb5ba93f-5dfe-4bf1-8571-4da0caacc80c"),
            },
        });
    // TODO: Handle 'response' of type TransactionFeeAccountGroupConfiguration
}
catch (ApiException<UpdateTransactionFeeAccountGroupConfigurationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateTransactionFeeAccountGroupConfigurationRequest](src/UpvestInvestmentApi/Requests/TransactionFeesConfigurations/UpdateTransactionFeeAccountGroupConfigurationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[TransactionFeeAccountGroupConfiguration](src/UpvestInvestmentApi/Models/TransactionFeeAccountGroupConfiguration.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[UpdateTransactionFeeAccountGroupConfigurationError](src/UpvestInvestmentApi/Errors/UpdateTransactionFeeAccountGroupConfigurationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## TransactionFeesModels

> Source: [TransactionFeesModels](src/UpvestInvestmentApi/Api/TransactionFeesModels.cs)

<details>
<summary><code>Task&lt;FeeConfiguration&gt; CreateTransactionFeeModel(CreateTransactionFeeModelRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates a transaction fee model that defines how per-order transaction fees are calculated — either as fixed cash amounts (`ABSOLUTE`) or in basis points of the order value (`RELATIVE`), with one or more tiers based on the order's cash amount.

Fee models are immutable once created; to change a fee structure, create a new model. Apply a model to an order by referencing its ID in the `fee_configuration` object of the order request.

See the Building transaction fees guide ([TOL](https://docs.upvest.co/products/tol/guides/fees/fees_transaction_fees_building) / [BYOL](https://docs.upvest.co/products/byol/guides/fees/fees_transaction_fees_building)) for implementation details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.TransactionFeesModels.CreateTransactionFeeModel(new CreateTransactionFeeModelRequest
    {
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new FeeConfigurationCreateRequest
        {
            Label = "transaction fee buy - new year promotion",
            Currency = Currency.Eur,
            ChargeMethod = FeeChargeMethod1.ChargedByClient,
            ValueType = ValueTypeEnum.Absolute,
            BaseAmountScope = BaseAmountScope.GrossAmount,
            Tiers = [
                new AbsoluteTransactionFeeTier { TierId = "0", BaseAmountFrom = "0", FeeAmount = "10" },
                new AbsoluteTransactionFeeTier { TierId = "1", BaseAmountFrom = "2000", FeeAmount = "12" },
                new AbsoluteTransactionFeeTier { TierId = "2", BaseAmountFrom = "4000", FeeAmount = "14" },
            ],
        },
    });
    // TODO: Handle 'response' of type FeeConfiguration
}
catch (ApiException<CreateTransactionFeeModelError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateTransactionFeeModelRequest](src/UpvestInvestmentApi/Requests/TransactionFeesModels/CreateTransactionFeeModelRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FeeConfiguration](src/UpvestInvestmentApi/Models/FeeConfiguration.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateTransactionFeeModelError](src/UpvestInvestmentApi/Errors/CreateTransactionFeeModelError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;TransactionFeeModelsListResponse&gt; ListTransactionFeeModels(ListTransactionFeeModelsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a paginated list of the transaction fee models created for your client account.

Use the `offset` and `limit` query parameters to page through results; `meta.total_count` gives the total number of matching fee models.

See the Transaction fees guide ([TOL](https://docs.upvest.co/products/tol/guides/fees/fees_transaction_fees_overview) / [BYOL](https://docs.upvest.co/products/byol/guides/fees/fees_transaction_fees_overview)) for fee model concepts.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.TransactionFeesModels.ListTransactionFeeModels(new ListTransactionFeeModelsRequest
    {
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type TransactionFeeModelsListResponse
}
catch (ApiException<ListTransactionFeeModelsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListTransactionFeeModelsRequest](src/UpvestInvestmentApi/Requests/TransactionFeesModels/ListTransactionFeeModelsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[TransactionFeeModelsListResponse](src/UpvestInvestmentApi/Models/TransactionFeeModelsListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListTransactionFeeModelsError](src/UpvestInvestmentApi/Errors/ListTransactionFeeModelsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;FeeConfiguration&gt; RetrieveTransactionFeeModel(RetrieveTransactionFeeModelRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the transaction fee model with the given ID, including its currency, charge method, value type, and tier structure.

See the Transaction fees guide ([TOL](https://docs.upvest.co/products/tol/guides/fees/fees_transaction_fees_overview) / [BYOL](https://docs.upvest.co/products/byol/guides/fees/fees_transaction_fees_overview)) for fee model concepts.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.TransactionFeesModels.RetrieveTransactionFeeModel(new RetrieveTransactionFeeModelRequest
    {
        TransactionFeeModelId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type FeeConfiguration
}
catch (ApiException<RetrieveTransactionFeeModelError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveTransactionFeeModelRequest](src/UpvestInvestmentApi/Requests/TransactionFeesModels/RetrieveTransactionFeeModelRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FeeConfiguration](src/UpvestInvestmentApi/Models/FeeConfiguration.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveTransactionFeeModelError](src/UpvestInvestmentApi/Errors/RetrieveTransactionFeeModelError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Transactions

> Source: [Transactions](src/UpvestInvestmentApi/Api/Transactions.cs)

<details>
<summary><code>Task&lt;CashTransactionListResponse&gt; ListCashTransactions(ListCashTransactionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the list of cash transactions for an account group.

Cash movements are recorded at account group level, so this endpoint is filtered by `account_group_id` rather than by account. Restrict the period with the `start_date` and `end_date` query parameters, and page through results with `offset` and `limit`; `meta.total_count` gives the total number of matching transactions.

See the transactions reports guide ([TOL](https://docs.upvest.co/products/tol/guides/reports/account_reports_transactions) / [BYOL](https://docs.upvest.co/products/byol/guides/reports/account_reports_transactions) / [Omnibus](https://docs.upvest.co/products/omnibus/guides/reports/account_reports_transactions)) for the full list of transaction types.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Transactions.ListCashTransactions(new ListCashTransactionsRequest
    {
        AccountGroupId = Guid.Parse("413715f2-5401-4b97-8055-034a6b879f8c"),
        StartDate = DateTimeOffset.Parse("2023-01-03T00:00:00Z"),
        EndDate = DateTimeOffset.Parse("2023-01-11T00:00:00Z"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type CashTransactionListResponse
}
catch (ApiException<ListCashTransactionsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListCashTransactionsRequest](src/UpvestInvestmentApi/Requests/Transactions/ListCashTransactionsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CashTransactionListResponse](src/UpvestInvestmentApi/Models/CashTransactionListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListCashTransactionsError](src/UpvestInvestmentApi/Errors/ListCashTransactionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;SecurityTransactionListResponse&gt; ListSecuritiesTransactions(ListSecuritiesTransactionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the list of securities transactions for an account group or a single account.

Securities movements are recorded at account level, so this endpoint accepts both `account_group_id` and `account_id`. Restrict the period with the `start_date` and `end_date` query parameters, and page through results with `offset` and `limit`; `meta.total_count` gives the total number of matching transactions.

See the transactions reports guide ([TOL](https://docs.upvest.co/products/tol/guides/reports/account_reports_transactions) / [BYOL](https://docs.upvest.co/products/byol/guides/reports/account_reports_transactions) / [Omnibus](https://docs.upvest.co/products/omnibus/guides/reports/account_reports_transactions)) for the full list of transaction types.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Transactions.ListSecuritiesTransactions(new ListSecuritiesTransactionsRequest
    {
        AccountGroupId = Guid.Parse("413715f2-5401-4b97-8055-034a6b879f8c"),
        AccountId = Guid.Parse("413715f2-5401-4b97-8055-034a6b879f8c"),
        StartDate = DateTimeOffset.Parse("2023-01-03T00:00:00Z"),
        EndDate = DateTimeOffset.Parse("2023-01-11T00:00:00Z"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type SecurityTransactionListResponse
}
catch (ApiException<ListSecuritiesTransactionsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListSecuritiesTransactionsRequest](src/UpvestInvestmentApi/Requests/Transactions/ListSecuritiesTransactionsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SecurityTransactionListResponse](src/UpvestInvestmentApi/Models/SecurityTransactionListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListSecuritiesTransactionsError](src/UpvestInvestmentApi/Errors/ListSecuritiesTransactionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## UserChecks

> Source: [UserChecks](src/UpvestInvestmentApi/Api/UserChecks.cs)

<details>
<summary><code>Task&lt;UserCheckCreateResponse&gt; CreateUserCheck(CreateUserCheckRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates a new check for a user specified by ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.UserChecks.CreateUserCheck(new CreateUserCheckRequest
    {
        UserId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new UserCheckKnowYourCustomerCreateRequest
        {
            Type = "KYC",
            CheckConfirmedAt = DateTimeOffset.Parse("2019-08-24T14:15:22Z"),
            DataDownloadLink = "https://bucket.customer.com/ident/user3.zip",
            DocumentType = DocumentType3.IdCard,
            DocumentExpirationDate = DateTimeOffset.Parse("2030-01-01T00:00:00Z"),
            Nationality = "DE",
            Provider = "KYC provider",
            Method = Method.VideoId,
            ConfirmedAddress = new Address2
            {
                AddressLine1 = "Rosenweg 221",
                AddressLine2 = "apt. 33",
                Postcode = "45678",
                Country = Country.De,
                State = "BE",
                City = "Berlin",
            },
        },
    });
    // TODO: Handle 'response' of type UserCheckCreateResponse
}
catch (ApiException<CreateUserCheckError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateUserCheckRequest](src/UpvestInvestmentApi/Requests/UserChecks/CreateUserCheckRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[UserCheckCreateResponse](src/UpvestInvestmentApi/Models/UserCheckCreateResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateUserCheckError](src/UpvestInvestmentApi/Errors/CreateUserCheckError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;UserCheckListResponse&gt; ListUserChecks(ListUserChecksRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Lists all checks for a user specified by ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.UserChecks.ListUserChecks(new ListUserChecksRequest
    {
        UserId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type UserCheckListResponse
}
catch (ApiException<ListUserChecksError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListUserChecksRequest](src/UpvestInvestmentApi/Requests/UserChecks/ListUserChecksRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[UserCheckListResponse](src/UpvestInvestmentApi/Models/UserCheckListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListUserChecksError](src/UpvestInvestmentApi/Errors/ListUserChecksError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;UserCheck&gt; RetrieveUserCheck(RetrieveUserCheckRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Retrieves a check for a user specified by its ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.UserChecks.RetrieveUserCheck(new RetrieveUserCheckRequest
    {
        UserId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        CheckId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type UserCheck
}
catch (ApiException<RetrieveUserCheckError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveUserCheckRequest](src/UpvestInvestmentApi/Requests/UserChecks/RetrieveUserCheckRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[UserCheck](src/UpvestInvestmentApi/Models/AnyOf/UserCheck.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveUserCheckError](src/UpvestInvestmentApi/Errors/RetrieveUserCheckError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## UserIdentifiers

> Source: [UserIdentifiers](src/UpvestInvestmentApi/Api/UserIdentifiers.cs)

<details>
<summary><code>Task&lt;Identifier&gt; CreateIdentifier(CreateIdentifierRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates a new identifier for a user that will be used for transaction reporting obligations. This identifier is required before the user's `OWNER` role can become active if the user's nationalities do not allow reporting using the CONCAT format.

See the User identifiers guide ([TOL](https://docs.upvest.co/products/tol/guides/users/users_identifiers) / [BYOL](https://docs.upvest.co/products/byol/guides/users/users_identifiers)) for details.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.UserIdentifiers.CreateIdentifier(new CreateIdentifierRequest
    {
        UserId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new IdentifierCreateRequest
        {
            Type = Type7.NationalId,
            IssuingCountry = IssuingCountry.Pl,
            Identifier = "83053078917",
            IdentifierStandard = "PESEL",
        },
    });
    // TODO: Handle 'response' of type Identifier
}
catch (ApiException<CreateIdentifierError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateIdentifierRequest](src/UpvestInvestmentApi/Requests/UserIdentifiers/CreateIdentifierRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Identifier](src/UpvestInvestmentApi/Models/Identifier.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateIdentifierError](src/UpvestInvestmentApi/Errors/CreateIdentifierError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;IdentifiersListResponse&gt; ListUserIdentifiers(ListUserIdentifiersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Lists all existing identifiers of a user used for transaction reporting.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.UserIdentifiers.ListUserIdentifiers(new ListUserIdentifiersRequest
    {
        UserId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type IdentifiersListResponse
}
catch (ApiException<ListUserIdentifiersError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListUserIdentifiersRequest](src/UpvestInvestmentApi/Requests/UserIdentifiers/ListUserIdentifiersRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[IdentifiersListResponse](src/UpvestInvestmentApi/Models/IdentifiersListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListUserIdentifiersError](src/UpvestInvestmentApi/Errors/ListUserIdentifiersError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Identifier&gt; RetrieveIdentifier(RetrieveIdentifierRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns an existing identifier of a given user used for transaction reporting.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.UserIdentifiers.RetrieveIdentifier(new RetrieveIdentifierRequest
    {
        UserId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        IdentifierId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type Identifier
}
catch (ApiException<RetrieveIdentifierError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveIdentifierRequest](src/UpvestInvestmentApi/Requests/UserIdentifiers/RetrieveIdentifierRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Identifier](src/UpvestInvestmentApi/Models/Identifier.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveIdentifierError](src/UpvestInvestmentApi/Errors/RetrieveIdentifierError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Identifier&gt; UpdateIdentifier(UpdateIdentifierRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Updates an existing identifier of a given user used for transaction reporting.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.UserIdentifiers.UpdateIdentifier(new UpdateIdentifierRequest
    {
        UserId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        IdentifierId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new IdentifierUpdateRequest { Identifier = "83053078111" },
    });
    // TODO: Handle 'response' of type Identifier
}
catch (ApiException<UpdateIdentifierError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateIdentifierRequest](src/UpvestInvestmentApi/Requests/UserIdentifiers/UpdateIdentifierRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Identifier](src/UpvestInvestmentApi/Models/Identifier.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[UpdateIdentifierError](src/UpvestInvestmentApi/Errors/UpdateIdentifierError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Users

> Source: [Users](src/UpvestInvestmentApi/Api/Users.cs)

<details>
<summary><code>Task&lt;UserCreateRequest1&gt; CreateUser(CreateUserRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates a user.

The user must complete identity checks and provide any required identifiers before their role for an account group or business becomes active.

See the Creating a user guide ([TOL](https://docs.upvest.co/products/tol/guides/users/users_onboarding_create) / [BYOL](https://docs.upvest.co/products/byol/guides/users/users_onboarding_create)) for the full onboarding flow.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Users.CreateUser(new CreateUserRequest
    {
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new UserByolCreateRequest
        {
            FirstName = "Karl",
            MiddleName = "Maria",
            LastName = "Schmidt",
            Email = "karl.schmidt@example.com",
            Salutation = Salutation.SalutationMale,
            Title = Title.Dr,
            BirthDate = DateTimeOffset.Parse("1972-09-30T00:00:00Z"),
            BirthCity = "Berlin",
            BirthCountry = BirthCountry.De,
            BirthName = "Schmidt",
            Nationalities = [Nationality.De, Nationality.Au],
            Address = new Address
            {
                AddressLine1 = "Rosenweg 221",
                AddressLine2 = "apt. 33",
                Postcode = "45678",
                Country = Country.De,
                State = "BE",
                City = "Berlin",
            },
            PostalAddress = new Address
            {
                AddressLine1 = "Rosenweg 221",
                AddressLine2 = "apt. 33",
                Postcode = "45678",
                Country = Country.De,
                State = "BE",
                City = "Berlin",
            },
            Tags = [Tag.ClientEmployee],
        },
    });
    // TODO: Handle 'response' of type UserCreateRequest1
}
catch (ApiException<CreateUserError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateUserRequest](src/UpvestInvestmentApi/Requests/Users/CreateUserRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[UserCreateRequest1](src/UpvestInvestmentApi/Models/AnyOf/UserCreateRequest1.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateUserError](src/UpvestInvestmentApi/Errors/CreateUserError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;UsersListResponse&gt; ListUsers(ListUsersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a paginated list of users.

Use the `offset` and `limit` query parameters to page through results; `meta.total_count` gives the total number of matching users. Use `sort`/`order` to control ordering by `created_at` or `updated_at`.

See the User onboarding guide ([TOL](https://docs.upvest.co/products/tol/guides/users/users_onboarding_overview) / [BYOL](https://docs.upvest.co/products/byol/guides/users/users_onboarding_overview)) for the user lifecycle.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Users.ListUsers(new ListUsersRequest { UpvestApiVersion = UpvestApiVersion._1 });
    // TODO: Handle 'response' of type UsersListResponse
}
catch (ApiException<ListUsersError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListUsersRequest](src/UpvestInvestmentApi/Requests/Users/ListUsersRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[UsersListResponse](src/UpvestInvestmentApi/Models/UsersListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListUsersError](src/UpvestInvestmentApi/Errors/ListUsersError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task OffboardUser(OffboardUserRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Starts the user offboarding process in the background.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.Users.OffboardUser(new OffboardUserRequest
    {
        UserId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
}
catch (ApiException<OffboardUserError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[OffboardUserRequest](src/UpvestInvestmentApi/Requests/Users/OffboardUserRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[OffboardUserError](src/UpvestInvestmentApi/Errors/OffboardUserError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;UserGetResponse&gt; RetrieveUser(RetrieveUserRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the user identified by `user_id`, including profile and status details

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Users.RetrieveUser(new RetrieveUserRequest
    {
        UserId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type UserGetResponse
}
catch (ApiException<RetrieveUserError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveUserRequest](src/UpvestInvestmentApi/Requests/Users/RetrieveUserRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[UserGetResponse](src/UpvestInvestmentApi/Models/AnyOf/UserGetResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveUserError](src/UpvestInvestmentApi/Errors/RetrieveUserError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task UserDataChange(UserDataChangeOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Requests a data change for a user specified by ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.Users.UserDataChange(new UserDataChangeOperationRequest
    {
        UserId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new UserTolDataChangeRequestNameChange
        {
            FirstName = "Karl",
            LastName = "Schmidt",
            IssuanceDate = DateTimeOffset.Parse("2030-01-01T00:00:00Z"),
            DataDownloadLink = "https://bucket.customer.com/ident/user3.zip",
            DocumentType = DocumentType.IdCard,
        },
    });
}
catch (ApiException<UserDataChangeError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UserDataChangeOperationRequest](src/UpvestInvestmentApi/Requests/Users/UserDataChangeOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[UserDataChangeError](src/UpvestInvestmentApi/Errors/UserDataChangeError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Valuations

> Source: [Valuations](src/UpvestInvestmentApi/Api/Valuations.cs)

<details>
<summary><code>Task&lt;AccountValuation&gt; GetAccountValuation(GetAccountValuationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the account's current valuation, calculated from its current positions and the requested `price_quality`.

See the Account valuations guide ([TOL](https://docs.upvest.co/products/tol/guides/positions/valuations) / [BYOL](https://docs.upvest.co/products/byol/guides/positions/valuations)) for the difference between `EOD` and `HIGHEST_AVAILABLE` price quality.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Valuations.GetAccountValuation(new GetAccountValuationRequest
    {
        AccountId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        PriceQuality = PriceQuality3.Eod,
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type AccountValuation
}
catch (ApiException<GetAccountValuationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetAccountValuationRequest](src/UpvestInvestmentApi/Requests/Valuations/GetAccountValuationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AccountValuation](src/UpvestInvestmentApi/Models/AccountValuation.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[GetAccountValuationError](src/UpvestInvestmentApi/Errors/GetAccountValuationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AccountValuationListResponse&gt; ListAccountValuationHistory(ListAccountValuationHistoryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the account's historical end-of-day valuations.

Use the `offset` and `limit` query parameters to page through results; `meta.total_count` gives the total number of matching valuations.

See the Account valuations guide ([TOL](https://docs.upvest.co/products/tol/guides/positions/valuations) / [BYOL](https://docs.upvest.co/products/byol/guides/positions/valuations)) for how valuations are calculated.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Valuations.ListAccountValuationHistory(new ListAccountValuationHistoryRequest
    {
        AccountId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        StartDate = DateTimeOffset.Parse("2023-01-03T00:00:00Z"),
        EndDate = DateTimeOffset.Parse("2023-01-11T00:00:00Z"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type AccountValuationListResponse
}
catch (ApiException<ListAccountValuationHistoryError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListAccountValuationHistoryRequest](src/UpvestInvestmentApi/Requests/Valuations/ListAccountValuationHistoryRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AccountValuationListResponse](src/UpvestInvestmentApi/Models/AccountValuationListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListAccountValuationHistoryError](src/UpvestInvestmentApi/Errors/ListAccountValuationHistoryError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## VirtualBankAccounts

> Source: [VirtualBankAccounts](src/UpvestInvestmentApi/Api/VirtualBankAccounts.cs)

<details>
<summary><code>Task&lt;PaymentsVirtualBankAccountsResponse&gt; CreateVirtualBankAccount(CreateVirtualBankAccountRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates a virtual bank account for an account group. The virtual bank account provides an IBAN and BIC that end users can use to send SEPA Credit Transfers directly to their investment account.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.VirtualBankAccounts.CreateVirtualBankAccount(new CreateVirtualBankAccountRequest
    {
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new PaymentsVirtualBankAccountCreateRequest
        {
            AccountGroupId = Guid.Parse("f874a64a-ceaa-42b2-b59a-39d4f62166fb"),
            Name = "Max's Virtual Bank Account",
        },
    });
    // TODO: Handle 'response' of type PaymentsVirtualBankAccountsResponse
}
catch (ApiException<CreateVirtualBankAccountError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateVirtualBankAccountRequest](src/UpvestInvestmentApi/Requests/VirtualBankAccounts/CreateVirtualBankAccountRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PaymentsVirtualBankAccountsResponse](src/UpvestInvestmentApi/Models/PaymentsVirtualBankAccountsResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateVirtualBankAccountError](src/UpvestInvestmentApi/Errors/CreateVirtualBankAccountError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PaymentsVirtualBankAccountsListResponse&gt; ListVirtualBankAccounts(ListVirtualBankAccountsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a list of virtual bank accounts.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.VirtualBankAccounts.ListVirtualBankAccounts(new ListVirtualBankAccountsRequest
    {
        AccountGroupId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        Sort = Sort4.Id,
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type PaymentsVirtualBankAccountsListResponse
}
catch (ApiException<ListVirtualBankAccountsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListVirtualBankAccountsRequest](src/UpvestInvestmentApi/Requests/VirtualBankAccounts/ListVirtualBankAccountsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PaymentsVirtualBankAccountsListResponse](src/UpvestInvestmentApi/Models/PaymentsVirtualBankAccountsListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListVirtualBankAccountsError](src/UpvestInvestmentApi/Errors/ListVirtualBankAccountsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PaymentsVirtualBankAccountsResponse&gt; RetrieveVirtualBankAccount(RetrieveVirtualBankAccountRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a virtual bank account specified by its ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.VirtualBankAccounts.RetrieveVirtualBankAccount(new RetrieveVirtualBankAccountRequest
    {
        VirtualBankAccountId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type PaymentsVirtualBankAccountsResponse
}
catch (ApiException<RetrieveVirtualBankAccountError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveVirtualBankAccountRequest](src/UpvestInvestmentApi/Requests/VirtualBankAccounts/RetrieveVirtualBankAccountRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PaymentsVirtualBankAccountsResponse](src/UpvestInvestmentApi/Models/PaymentsVirtualBankAccountsResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveVirtualBankAccountError](src/UpvestInvestmentApi/Errors/RetrieveVirtualBankAccountError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## VirtualCashBalances

> Source: [VirtualCashBalances](src/UpvestInvestmentApi/Api/VirtualCashBalances.cs)

<details>
<summary><code>Task CancelVirtualCashDecrease(CancelVirtualCashDecreaseRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Cancels a virtual cash decrease specified by its ID. It is only possible to cancel a virtual cash decrease if it has the status `ISSUED` or `QUEUED`.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.VirtualCashBalances.CancelVirtualCashDecrease(new CancelVirtualCashDecreaseRequest
    {
        VirtualCashDecreaseId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
}
catch (ApiException<CancelVirtualCashDecreaseError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CancelVirtualCashDecreaseRequest](src/UpvestInvestmentApi/Requests/VirtualCashBalances/CancelVirtualCashDecreaseRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CancelVirtualCashDecreaseError](src/UpvestInvestmentApi/Errors/CancelVirtualCashDecreaseError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;VirtualCashBalanceVirtualCashDecrease&gt; CreateVirtualCashDecrease(CreateVirtualCashDecreaseRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Decreases an account group's virtual cash balance, for example after an order has settled or before a withdrawal.

If the account group does not yet have sufficient real cash, the decrease is queued with status `QUEUED` and confirmed automatically once funds arrive rather than being rejected. Requires the `Idempotency-Key` header to prevent duplicate decreases.

See the Virtual cash guide ([TOL](https://docs.upvest.co/products/tol/guides/virtual_cash/implementing_virtual_cash) / [BYOL](https://docs.upvest.co/products/byol/guides/virtual_cash/implementing_virtual_cash)) for supported use cases.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.VirtualCashBalances.CreateVirtualCashDecrease(new CreateVirtualCashDecreaseRequest
    {
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new VirtualCashBalanceVirtualCashDecreaseCreateRequest
        {
            AccountGroupId = Guid.Parse("2596db3b-0d03-4651-9eda-970910479dfb"),
            Amount = "200.00",
            Currency = Currency1.Eur,
        },
    });
    // TODO: Handle 'response' of type VirtualCashBalanceVirtualCashDecrease
}
catch (ApiException<CreateVirtualCashDecreaseError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateVirtualCashDecreaseRequest](src/UpvestInvestmentApi/Requests/VirtualCashBalances/CreateVirtualCashDecreaseRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[VirtualCashBalanceVirtualCashDecrease](src/UpvestInvestmentApi/Models/VirtualCashBalanceVirtualCashDecrease.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateVirtualCashDecreaseError](src/UpvestInvestmentApi/Errors/CreateVirtualCashDecreaseError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;VirtualCashBalanceVirtualCashIncrease&gt; CreateVirtualCashIncrease(CreateVirtualCashIncreaseRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Increases an account group's virtual cash balance, making the specified `amount` available for trading before the corresponding real cash has settled.

Requires the `Idempotency-Key` header to prevent duplicate increases.

See the Virtual cash guide ([TOL](https://docs.upvest.co/products/tol/guides/virtual_cash/implementing_virtual_cash) / [BYOL](https://docs.upvest.co/products/byol/guides/virtual_cash/implementing_virtual_cash)) for supported use cases.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.VirtualCashBalances.CreateVirtualCashIncrease(new CreateVirtualCashIncreaseRequest
    {
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new VirtualCashBalanceVirtualCashIncreaseCreateRequest
        {
            AccountGroupId = Guid.Parse("2596db3b-0d03-4651-9eda-970910479dfb"),
            Amount = "200.00",
            Currency = Currency1.Eur,
        },
    });
    // TODO: Handle 'response' of type VirtualCashBalanceVirtualCashIncrease
}
catch (ApiException<CreateVirtualCashIncreaseError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateVirtualCashIncreaseRequest](src/UpvestInvestmentApi/Requests/VirtualCashBalances/CreateVirtualCashIncreaseRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[VirtualCashBalanceVirtualCashIncrease](src/UpvestInvestmentApi/Models/VirtualCashBalanceVirtualCashIncrease.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateVirtualCashIncreaseError](src/UpvestInvestmentApi/Errors/CreateVirtualCashIncreaseError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## WebhookSubscriptions

> Source: [WebhookSubscriptions](src/UpvestInvestmentApi/Api/WebhookSubscriptions.cs)

<details>
<summary><code>Task&lt;Webhook&gt; CreateWebhook(CreateWebhookRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates a webhook subscription, registering a URL that the Investment API calls when the events you select occur.

The URL must use HTTPS, resolve to a DNS name rather than an IP address, serve TLS 1.2 or higher, and must not respond with a redirect. Set `type` to `ALL` to receive every event, optionally narrowing it with `exclude_type`, or list only the subscription types you want. Events are batched by size or by delay according to `config`.

See the implementing webhooks guide ([TOL](https://docs.upvest.co/products/tol/getting_started/implementing_webhooks) / [BYOL](https://docs.upvest.co/products/byol/getting_started/implementing_webhooks) / [Omnibus](https://docs.upvest.co/products/omnibus/getting_started/implementing_webhooks)) for handler requirements, subscription types, and batching.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WebhookSubscriptions.CreateWebhook(new CreateWebhookRequest
    {
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new WebhookCreateRequest
        {
            Title = "User webhook",
            Url = "https://tenant.tld/webhooks/users",
            Type = [TypeEnum.User],
            Config = new Config { Delay = "1s", MaxPackageSize = 51200 },
        },
    });
    // TODO: Handle 'response' of type Webhook
}
catch (ApiException<CreateWebhookError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateWebhookRequest](src/UpvestInvestmentApi/Requests/WebhookSubscriptions/CreateWebhookRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Webhook](src/UpvestInvestmentApi/Models/Webhook.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateWebhookError](src/UpvestInvestmentApi/Errors/CreateWebhookError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task DeleteWebhook(DeleteWebhookRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Deletes the webhook subscription identified by `webhook_id`, stopping all further deliveries to its URL.

See the implementing webhooks guide ([TOL](https://docs.upvest.co/products/tol/getting_started/implementing_webhooks) / [BYOL](https://docs.upvest.co/products/byol/getting_started/implementing_webhooks) / [Omnibus](https://docs.upvest.co/products/omnibus/getting_started/implementing_webhooks)) for handler requirements, subscription types, and batching.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.WebhookSubscriptions.DeleteWebhook(new DeleteWebhookRequest
    {
        WebhookId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
}
catch (ApiException<DeleteWebhookError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[DeleteWebhookRequest](src/UpvestInvestmentApi/Requests/WebhookSubscriptions/DeleteWebhookRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[DeleteWebhookError](src/UpvestInvestmentApi/Errors/DeleteWebhookError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AuthVerificationKeys&gt; GetJwks(GetJwksRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the set of public keys used to verify the signatures on webhook payloads, as a JSON Web Key Set.

Verify the signature of every webhook you receive against these keys before acting on it. Keys rotate, so fetch the current set rather than hard-coding a key.

See the implementing webhooks guide ([TOL](https://docs.upvest.co/products/tol/getting_started/implementing_webhooks) / [BYOL](https://docs.upvest.co/products/byol/getting_started/implementing_webhooks) / [Omnibus](https://docs.upvest.co/products/omnibus/getting_started/implementing_webhooks)) for handler requirements, subscription types, and batching.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WebhookSubscriptions.GetJwks(new GetJwksRequest
    {
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type AuthVerificationKeys
}
catch (ApiException<GetJwksError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetJwksRequest](src/UpvestInvestmentApi/Requests/WebhookSubscriptions/GetJwksRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AuthVerificationKeys](src/UpvestInvestmentApi/Models/AuthVerificationKeys.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[GetJwksError](src/UpvestInvestmentApi/Errors/GetJwksError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;WebhooksListResponse&gt; ListWebhooks(ListWebhooksRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the list of webhook subscriptions.

Use the `offset` and `limit` query parameters to page through results; `meta.total_count` gives the total number of matching subscriptions.

See the implementing webhooks guide ([TOL](https://docs.upvest.co/products/tol/getting_started/implementing_webhooks) / [BYOL](https://docs.upvest.co/products/byol/getting_started/implementing_webhooks) / [Omnibus](https://docs.upvest.co/products/omnibus/getting_started/implementing_webhooks)) for handler requirements, subscription types, and batching.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WebhookSubscriptions.ListWebhooks(new ListWebhooksRequest
    {
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type WebhooksListResponse
}
catch (ApiException<ListWebhooksError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListWebhooksRequest](src/UpvestInvestmentApi/Requests/WebhookSubscriptions/ListWebhooksRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[WebhooksListResponse](src/UpvestInvestmentApi/Models/WebhooksListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListWebhooksError](src/UpvestInvestmentApi/Errors/ListWebhooksError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Webhook&gt; RetrieveWebhook(RetrieveWebhookRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the webhook subscription identified by `webhook_id`, including the URL it calls, the subscription types it covers, and whether it is enabled.

See the implementing webhooks guide ([TOL](https://docs.upvest.co/products/tol/getting_started/implementing_webhooks) / [BYOL](https://docs.upvest.co/products/byol/getting_started/implementing_webhooks) / [Omnibus](https://docs.upvest.co/products/omnibus/getting_started/implementing_webhooks)) for handler requirements, subscription types, and batching.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WebhookSubscriptions.RetrieveWebhook(new RetrieveWebhookRequest
    {
        WebhookId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type Webhook
}
catch (ApiException<RetrieveWebhookError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveWebhookRequest](src/UpvestInvestmentApi/Requests/WebhookSubscriptions/RetrieveWebhookRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Webhook](src/UpvestInvestmentApi/Models/Webhook.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveWebhookError](src/UpvestInvestmentApi/Errors/RetrieveWebhookError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;WebhooksTestResponse&gt; TestWebhook(TestWebhookRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Sends test event data to the URL of the webhook subscription identified by `webhook_id`, so you can confirm your handler is reachable and responding correctly.

The response reports what your endpoint returned: its HTTP status, response headers, and body. Use it to verify a new subscription before relying on live events.

See the implementing webhooks guide ([TOL](https://docs.upvest.co/products/tol/getting_started/implementing_webhooks) / [BYOL](https://docs.upvest.co/products/byol/getting_started/implementing_webhooks) / [Omnibus](https://docs.upvest.co/products/omnibus/getting_started/implementing_webhooks)) for handler requirements, subscription types, and batching.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WebhookSubscriptions.TestWebhook(new TestWebhookRequest
    {
        WebhookId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type WebhooksTestResponse
}
catch (ApiException<TestWebhookError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[TestWebhookRequest](src/UpvestInvestmentApi/Requests/WebhookSubscriptions/TestWebhookRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[WebhooksTestResponse](src/UpvestInvestmentApi/Models/WebhooksTestResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[TestWebhookError](src/UpvestInvestmentApi/Errors/TestWebhookError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Webhook&gt; UpdateWebhook(UpdateWebhookRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Updates the webhook subscription identified by `webhook_id`.

Use this to change the callback URL, adjust which subscription types are delivered, or enable and disable delivery without deleting the subscription.

See the implementing webhooks guide ([TOL](https://docs.upvest.co/products/tol/getting_started/implementing_webhooks) / [BYOL](https://docs.upvest.co/products/byol/getting_started/implementing_webhooks) / [Omnibus](https://docs.upvest.co/products/omnibus/getting_started/implementing_webhooks)) for handler requirements, subscription types, and batching.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WebhookSubscriptions.UpdateWebhook(new UpdateWebhookRequest
    {
        WebhookId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new WebhookUpdateRequest { Url = "https://tenant.tld/webhooks/users", Type = [TypeEnum.User] },
    });
    // TODO: Handle 'response' of type Webhook
}
catch (ApiException<UpdateWebhookError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateWebhookRequest](src/UpvestInvestmentApi/Requests/WebhookSubscriptions/UpdateWebhookRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Webhook](src/UpvestInvestmentApi/Models/Webhook.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[UpdateWebhookError](src/UpvestInvestmentApi/Errors/UpdateWebhookError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Withdrawals

> Source: [Withdrawals](src/UpvestInvestmentApi/Api/Withdrawals.cs)

<details>
<summary><code>Task CancelCashWithdrawal(CancelCashWithdrawalRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Cancels a withdrawal specified by its ID. It is only possible to cancel a withdrawal if it has the status `NEW`.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.Withdrawals.CancelCashWithdrawal(new CancelCashWithdrawalRequest
    {
        WithdrawalId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
}
catch (ApiException<CancelCashWithdrawalError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CancelCashWithdrawalRequest](src/UpvestInvestmentApi/Requests/Withdrawals/CancelCashWithdrawalRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CancelCashWithdrawalError](src/UpvestInvestmentApi/Errors/CancelCashWithdrawalError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PaymentsWithdrawal&gt; CreateCashWithdrawal(CreateCashWithdrawalRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Trigger a withdrawal.

**Deprecation notice:** The `user_id` field is deprecated, optional, and will be removed in a future version. For business account withdrawals, ownership is determined by the reference account linked to the business.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Withdrawals.CreateCashWithdrawal(new CreateCashWithdrawalRequest
    {
        IdempotencyKey = Guid.Parse("ccb07f42-4104-44ad-8e1f-c660bb7b269c"),
        UpvestApiVersion = UpvestApiVersion._1,
        Body = new PaymentsWithdrawalCreateRequest
        {
            ReferenceAccountId = Guid.Parse("295378ec-036e-4f3f-ae5c-2be85c93e837"),
            AccountGroupId = Guid.Parse("2596db3b-0d03-4651-9eda-970910479dfb"),
            UserId = Guid.Parse("e56c14b3-8370-4c04-bc67-7092f7ec113c"),
            Amount = "200.00",
            Currency = Currency.Eur,
            RemittanceInformation = "Withdrawal",
            PurposeCode = "OTHR",
        },
    });
    // TODO: Handle 'response' of type PaymentsWithdrawal
}
catch (ApiException<CreateCashWithdrawalError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateCashWithdrawalRequest](src/UpvestInvestmentApi/Requests/Withdrawals/CreateCashWithdrawalRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PaymentsWithdrawal](src/UpvestInvestmentApi/Models/PaymentsWithdrawal.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[CreateCashWithdrawalError](src/UpvestInvestmentApi/Errors/CreateCashWithdrawalError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;WithdrawalsListResponse&gt; ListCashWithdrawals(ListCashWithdrawalsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a paginated list of cash withdrawals for the account group specified by its ID.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Withdrawals.ListCashWithdrawals(new ListCashWithdrawalsRequest
    {
        AccountGroupId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        Sort = Sort4.Id,
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type WithdrawalsListResponse
}
catch (ApiException<ListCashWithdrawalsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListCashWithdrawalsRequest](src/UpvestInvestmentApi/Requests/Withdrawals/ListCashWithdrawalsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[WithdrawalsListResponse](src/UpvestInvestmentApi/Models/WithdrawalsListResponse.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[ListCashWithdrawalsError](src/UpvestInvestmentApi/Errors/ListCashWithdrawalsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PaymentsWithdrawal&gt; RetrieveCashWithdrawal(RetrieveCashWithdrawalRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the cash withdrawal specified by its ID, including its current status, amount, and reference account.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Withdrawals.RetrieveCashWithdrawal(new RetrieveCashWithdrawalRequest
    {
        WithdrawalId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        UpvestApiVersion = UpvestApiVersion._1,
    });
    // TODO: Handle 'response' of type PaymentsWithdrawal
}
catch (ApiException<RetrieveCashWithdrawalError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RetrieveCashWithdrawalRequest](src/UpvestInvestmentApi/Requests/Withdrawals/RetrieveCashWithdrawalRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PaymentsWithdrawal](src/UpvestInvestmentApi/Models/PaymentsWithdrawal.cs)</code>

**OnError**: <code>[ApiException](src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs)&lt;[RetrieveCashWithdrawalError](src/UpvestInvestmentApi/Errors/RetrieveCashWithdrawalError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

