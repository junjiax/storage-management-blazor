using frontendblazor.Models;

namespace frontendblazor.Services;

public sealed class CategoryApi
{
    private readonly ApiClient apiClient;

    public CategoryApi(ApiClient apiClient)
    {
        this.apiClient = apiClient;
    }

    public Task<ApiResponse<List<CategoryResponse>>?> GetAllAsync(CancellationToken ct = default)
        => apiClient.GetAsync<ApiResponse<List<CategoryResponse>>>("category", ct);
}


