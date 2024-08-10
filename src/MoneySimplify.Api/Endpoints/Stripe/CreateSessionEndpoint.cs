using System.Security.Claims;
using MoneySimplify.Api.Common.Api;
using MoneySimplify.Core.Handlers;
using MoneySimplify.Core.Requests.Orders;
using MoneySimplify.Core.Requests.Stripe;
using MoneySimplify.Core.Responses;

namespace MoneySimplify.Api.Endpoints.Stripe;

public class CreateSessionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/session", HandleAsync)
            .Produces<Response<string?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IStripeHandler handler,
        CreateSessionRequest request)
    {
        request.UserId = user.Identity?.Name ?? string.Empty;

        var result = await handler.CreateSessionAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
