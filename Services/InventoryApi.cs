
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
        => apiClient.PostAsync<InventoryRequest, ApiResponse<InventoryResponse>>("inventory", request, ct);

    public Task<ApiResponse<InventoryResponse>?> UpdateAsync(InventoryRequest request, int Id, CancellationToken ct = default)
        => apiClient.PutAsync<InventoryRequest, ApiResponse<InventoryResponse>>($"inventory/{Id}", request, ct);

    public Task<ApiResponse<List<InventoryResponse>>> GetAllAsync(CancellationToken ct = default)
        => apiClient.GetAsync<ApiResponse<List<InventoryResponse>>>("inventory", ct);

    public Task<ApiResponse<InventoryResponse>?> GetByIdAsync(int Id, CancellationToken ct = default)
        => apiClient.GetByIdAsync<ApiResponse<InventoryResponse>>("inventory", Id, ct);

    public Task<ApiResponse<bool>?> DeleteAsync(int Id, CancellationToken ct = default)
        => apiClient.DeleteAsync<ApiResponse<bool>>($"inventory/{Id}", Id, ct);

    public Task<ApiResponse<List<InventoryLogDto>>> GetAllLogsAsync(int Id, CancellationToken ct = default)
        => apiClient.GetByIdAsync<ApiResponse<List<InventoryLogDto>>>("inventory/product-log", Id, ct);
}


