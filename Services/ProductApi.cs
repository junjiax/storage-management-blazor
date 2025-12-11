using frontendblazor.Models;

namespace frontendblazor.Services;

public sealed class ProductApi
{
    private readonly ApiClient apiClient;

    public ProductApi(ApiClient apiClient)
    {
        this.apiClient = apiClient;
    }

    public Task<ApiResponse<List<ProductResponse>>?> GetAllAsync(CancellationToken ct = default)
        => apiClient.GetAsync<ApiResponse<List<ProductResponse>>>("product", ct);

    public Task<ApiResponse<ProductResponse>?> GetByIdAsync(int id, CancellationToken ct = default)
        => apiClient.GetAsync<ApiResponse<ProductResponse>>($"product/{id}", ct);
}
