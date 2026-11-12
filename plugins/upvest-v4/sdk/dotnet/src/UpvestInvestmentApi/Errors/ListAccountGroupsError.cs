using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using UpvestInvestmentApi.Core.ErrorResponse;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Errors;

public sealed class ListAccountGroupsError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private ListAccountGroupsError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static ListAccountGroupsError AsNoContent(RawError value) => new(Optional<RawError>.Some(value), default);

    private static ListAccountGroupsError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent([NotNullWhen(true)] out RawError? value) => _noContentValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<RawError, TResult> onNoContent, Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetNoContent(out var noContentValue) => onNoContent(noContentValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(ListAccountGroupsError)} holds no value.")
        };

    public void Match(Action<RawError> onNoContent, Action<RawError> otherwise)
    {
        if (TryGetNoContent(out var noContentValue)) onNoContent(noContentValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(ListAccountGroupsError)} holds no value.");
    }

    private static Task<ListAccountGroupsError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 401 or 403 or 406 or 429 or 500 or 503 or 504 => response.RawBody().As(AsNoContent),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<ListAccountGroupsError> Response { get; } = new(Create);
}
