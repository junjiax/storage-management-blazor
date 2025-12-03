using frontendblazor.Models;

namespace frontendblazor.Services;

public sealed class ProductApi
{
    private readonly ApiClient apiClient;

    public ProductApi(ApiClient apiClient)
    {
        this.apiClient = apiClient;
    }
    
    public Task<ApiResponse<ProductResponse>?> AddAsync(ProductRequest request, CancellationToken ct = default)
        => apiClient.PostAsync<ProductRequest, ApiResponse<ProductResponse>>("auth/login", request, ct);

    public Task<ApiResponse<ProductResponse>?> UpdateAsync(ProductRequest request, CancellationToken ct = default)
        => apiClient.PutAsync<ProductRequest, ApiResponse<ProductResponse>>("auth/login", request, ct);

    public Task<ApiResponse<ProductResponse>?> GetAllAsync(CancellationToken ct = default)
        => apiClient.GetAsync<ApiResponse<ProductResponse>>("Supplier", ct);

    public Task<ApiResponse<ProductResponse>?> GetByIdAsync(int id, CancellationToken ct = default)
        => apiClient.GetByIdAsync<ApiResponse<ProductResponse>>("Supplier", id, ct);

    public Task<ApiResponse<bool>?> DeleteAsync(int id, CancellationToken ct = default)
        => apiClient.DeleteAsync<ApiResponse<bool>>("Supplier", id, ct);
}


