using frontendblazor.Models;

namespace frontendblazor.Services;

public sealed class InventoryApi
{
    private readonly ApiClient apiClient;

    public InventoryApi(ApiClient apiClient)
    {
        this.apiClient = apiClient;
    }

    public Task<ApiResponse<InventoryResponse>?> AddAsync(InventoryRequest request, CancellationToken ct = default)
        => apiClient.PostAsync<InventoryRequest, ApiResponse<InventoryResponse>>("auth/login", request, ct);

    public Task<ApiResponse<InventoryResponse>?> UpdateAsync(InventoryRequest request, CancellationToken ct = default)
        => apiClient.PostAsync<InventoryRequest, ApiResponse<InventoryResponse>>("auth/login", request, ct);

    public Task<ApiResponse<InventoryResponse>?> DeleteAsync(InventoryRequest request, CancellationToken ct = default)
        => apiClient.PostAsync<InventoryRequest, ApiResponse<InventoryResponse>>("auth/login", request, ct);

    public Task<ApiResponse<InventoryResponse>?> GetListAsync(InventoryRequest request, CancellationToken ct = default)
        => apiClient.PostAsync<InventoryRequest, ApiResponse<InventoryResponse>>("auth/login", request, ct);

    public Task<ApiResponse<InventoryResponse>?> GetByIdAsync(InventoryRequest request, CancellationToken ct = default)
        => apiClient.PostAsync<InventoryRequest, ApiResponse<InventoryResponse>>("auth/register", request, ct);
}


