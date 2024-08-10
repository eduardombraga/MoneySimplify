namespace MoneySimplify.Core.Requests.Orders;

public class ConfirmOrderRequest : Request
{
    public string Number { get; set; } = string.Empty;
}
