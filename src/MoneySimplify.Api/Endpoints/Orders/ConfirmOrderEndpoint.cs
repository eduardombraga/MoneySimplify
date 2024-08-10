using System.Security.Claims;
using MoneySimplify.Api.Common.Api;
using MoneySimplify.Core.Handlers;
using MoneySimplify.Core.Models;
using MoneySimplify.Core.Requests.Orders;
using MoneySimplify.Core.Responses;

namespace MoneySimplify.Api.Endpoints.Orders;

public class ConfirmOrderEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/", HandleAsync)
            .Produces<Response<Order?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IOrderHandler handler,
        ConfirmOrderRequest request)
    {
        request.UserId = user.Identity?.Name ?? string.Empty;

        var result = await handler.ConfirmOrderAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
