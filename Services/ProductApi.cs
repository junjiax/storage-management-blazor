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
        => apiClient.PostAsync<ProductRequest, ApiResponse<ProductResponse>>("auth/login", request, ct);

    public Task<ApiResponse<ProductResponse>?> DeleteAsync(ProductRequest request, CancellationToken ct = default)
        => apiClient.PostAsync<ProductRequest, ApiResponse<ProductResponse>>("auth/login", request, ct);

    public Task<ApiResponse<ProductResponse>?> GetListAsync(ProductRequest request, CancellationToken ct = default)
        => apiClient.PostAsync<ProductRequest, ApiResponse<ProductResponse>>("auth/login", request, ct);

    public Task<ApiResponse<AuthResponse>?> GetByIdAsync(ProductRequest request, CancellationToken ct = default)
        => apiClient.PostAsync<ProductRequest, ApiResponse<AuthResponse>>("auth/register", request, ct);
}


