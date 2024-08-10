using MoneySimplify.Core.Requests.Account;
using MoneySimplify.Core.Responses;

namespace MoneySimplify.Core.Handlers;

public interface IAccountHandler
{
    Task<Response<string>> LoginAsync(LoginRequest request);
    Task<Response<string>> RegisterAsync(RegisterRequest request);
    Task LogoutAsync();
}
