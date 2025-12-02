using frontendblazor.Models;

namespace frontendblazor.Services;

public sealed class CustomerApi
{
    private readonly ApiClient apiClient;

    public CustomerApi(ApiClient apiClient)
    {
        this.apiClient = apiClient;
    }

    public Task<ApiResponse<CustomerResponse>?> AddAsync(CustomerRequest request, CancellationToken ct = default)
        => apiClient.PostAsync<CustomerRequest, ApiResponse<CustomerResponse>>("customer", request, ct);

    public Task<ApiResponse<CustomerResponse>?> UpdateAsync(CustomerRequest request,int id ,CancellationToken ct = default)
        => apiClient.PutAsync<CustomerRequest, ApiResponse<CustomerResponse>>($"customer/{id}", request, ct);
	public Task<ApiResponse<CustomerResponse>?> GetAllAsync(CancellationToken ct = default)
	=> apiClient.GetAsync<ApiResponse<CustomerResponse>>("customer", ct);
	public Task<ApiResponse<CustomerResponse>?> GetByIdAsync(int id, CancellationToken ct = default)
	=> apiClient.GetByIdAsync<ApiResponse<CustomerResponse>>("customer", id, ct);
	public Task<ApiResponse<bool>?> DeleteAsync(int id, CancellationToken ct = default)
    => apiClient.DeleteAsync<ApiResponse<bool>>("customer", id, ct);
}
