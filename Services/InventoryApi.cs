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
        => apiClient.PutAsync<InventoryRequest, ApiResponse<InventoryResponse>>("auth/login", request, ct);

    public Task<ApiResponse<List<InventoryResponse>>> GetAllAsync(CancellationToken ct = default)
        => apiClient.GetAsync<ApiResponse<List<InventoryResponse>>>("inventory", ct);

    public Task<ApiResponse<InventoryResponse>?> GetByIdAsync(int id, CancellationToken ct = default)
        => apiClient.GetByIdAsync<ApiResponse<InventoryResponse>>("Supplier", id, ct);

    public Task<ApiResponse<bool>?> DeleteAsync(int id, CancellationToken ct = default)
        => apiClient.DeleteAsync<ApiResponse<bool>>("Supplier", id, ct);

}


