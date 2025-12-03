using frontendblazor.Models;

namespace frontendblazor.Services;

public sealed class CategoryApi
{
    private readonly ApiClient apiClient;

    public CategoryApi(ApiClient apiClient)
    {
        this.apiClient = apiClient;
    }

    public Task<ApiResponse<CategoryResponse>?> AddAsync(CategoryRequest request, CancellationToken ct = default)
        => apiClient.PostAsync<CategoryRequest, ApiResponse<CategoryResponse>>("auth/login", request, ct);

    public Task<ApiResponse<CategoryResponse>?> UpdateAsync(CategoryRequest request, CancellationToken ct = default)
        => apiClient.PutAsync<CategoryRequest, ApiResponse<CategoryResponse>>("auth/login", request, ct);

    public Task<ApiResponse<CategoryResponse>?> GetAllAsync(CancellationToken ct = default)
        => apiClient.GetAsync<ApiResponse<CategoryResponse>>("Supplier", ct);

    public Task<ApiResponse<CategoryResponse>?> GetByIdAsync(int id, CancellationToken ct = default)
        => apiClient.GetByIdAsync<ApiResponse<CategoryResponse>>("Supplier", id, ct);

    public Task<ApiResponse<bool>?> DeleteAsync(int id, CancellationToken ct = default)
        => apiClient.DeleteAsync<ApiResponse<bool>>("Supplier", id, ct);
}


