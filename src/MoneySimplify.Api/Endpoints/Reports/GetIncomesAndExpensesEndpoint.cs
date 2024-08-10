using System.Security.Claims;
using MoneySimplify.Api.Common.Api;
using MoneySimplify.Core.Handlers;
using MoneySimplify.Core.Models.Reports;
using MoneySimplify.Core.Requests.Reports;
using MoneySimplify.Core.Responses;

namespace MoneySimplify.Api.Endpoints.Reports;

public class GetIncomesAndExpensesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/incomes-expenses", HandleAsync)
            .Produces<Response<List<IncomesAndExpenses>?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IReportHandler handler)
    {
        var request = new GetIncomesAndExpensesRequest
        {
            UserId = user.Identity?.Name ?? string.Empty
        };
        var result = await handler.GetIncomesAndExpensesReportAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
