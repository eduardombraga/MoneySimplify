using MoneySimplify.Core.Requests.Stripe;
using MoneySimplify.Core.Responses;

namespace MoneySimplify.Core.Handlers;

public interface IStripeHandler
{
    Task<Response<string?>> CreateSessionAsync(CreateSessionRequest request);
}
