using System.Reflection.Metadata;
using System.Security.Claims;
using MoneySimplify.Api.Common.Api;
using MoneySimplify.Core.Handlers;
using MoneySimplify.Core.Models.Reports;
using MoneySimplify.Core.Requests.Reports;
using MoneySimplify.Core.Responses;

namespace MoneySimplify.Api.Endpoints.Reports;

public class GetFinancialSummaryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/summary", HandleAsync)
            .Produces<Response<FinancialSummary?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IReportHandler handler)
    {
        var request = new GetFinancialSummaryRequest
        {
            UserId = user.Identity?.Name ?? string.Empty
        };
        var result = await handler.GetFinancialSummaryReportAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
