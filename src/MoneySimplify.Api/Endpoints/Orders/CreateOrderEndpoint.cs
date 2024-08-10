using System.Security.Claims;
using MoneySimplify.Api.Common.Api;
using MoneySimplify.Core.Handlers;
using MoneySimplify.Core.Models;
using MoneySimplify.Core.Requests.Orders;
using MoneySimplify.Core.Responses;

namespace MoneySimplify.Api.Endpoints.Orders;

public class CreateOrderEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .Produces<Response<Order?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IOrderHandler handler,
        CreateOrderRequest request)
    {
        request.UserId = user.Identity?.Name ?? string.Empty;

        var result = await handler.CreateOrderAsync(request);
        return result.IsSuccess
            ? TypedResults.Created("", result)
            : TypedResults.BadRequest(result);
    }
}
