using MoneySimplify.Core.Models;
using MoneySimplify.Core.Requests.Orders;
using MoneySimplify.Core.Responses;

namespace MoneySimplify.Core.Handlers;

public interface IOrderHandler
{
    Task<Response<Order?>> CreateOrderAsync(CreateOrderRequest request);
    Task<Response<Order?>> ConfirmOrderAsync(ConfirmOrderRequest request);
}
