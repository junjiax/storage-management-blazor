using frontendblazor.Models;

namespace frontendblazor.Services;

public sealed class SupplierApi
{
    private readonly ApiClient apiClient;

    public SupplierApi(ApiClient apiClient)
    {
        this.apiClient = apiClient;
    }

    public Task<ApiResponse<SupplierResponse>?> AddAsync(SupplierRequest request, CancellationToken ct = default)
        => apiClient.PostAsync<SupplierRequest, ApiResponse<SupplierResponse>>("Supplier", request, ct);

    public Task<ApiResponse<SupplierResponse>?> UpdateAsync(SupplierRequest request,int id ,CancellationToken ct = default)
        => apiClient.PutAsync<SupplierRequest, ApiResponse<SupplierResponse>>($"Supplier/{id}", request, ct);
	
    public Task<ApiResponse<SupplierResponse>?> GetAllAsync(CancellationToken ct = default)
	    => apiClient.GetAsync<ApiResponse<SupplierResponse>>("Supplier", ct);
	
    public Task<ApiResponse<SupplierResponse>?> GetByIdAsync(int id, CancellationToken ct = default)
	    => apiClient.GetByIdAsync<ApiResponse<SupplierResponse>>("Supplier", id, ct);
	
    public Task<ApiResponse<bool>?> DeleteAsync(int id, CancellationToken ct = default)
        => apiClient.DeleteAsync<ApiResponse<bool>>("Supplier", id, ct);
}
