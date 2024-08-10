using MoneySimplify.Core.Models;
using MoneySimplify.Core.Requests.Categories;
using MoneySimplify.Core.Responses;

namespace MoneySimplify.Core.Handlers;

public interface ICategoryHandler
{
    Task<Response<Category?>> CreateAsync(CreateCategoryRequest request);
    Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request);
    Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request);
    Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request);
    Task<PagedResponse<List<Category>>> GetAllAsync(GetAllCategoriesRequest request);
}
