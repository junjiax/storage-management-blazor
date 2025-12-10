using frontendblazor.Models;

namespace frontendblazor.Services;

public sealed class OrderApi
{
    private readonly ApiClient apiClient;

    public OrderApi(ApiClient apiClient)
    {
        this.apiClient = apiClient;
    }

    public Task<ApiResponse<List<OrderResponse>>?> GetAllAsync(CancellationToken ct = default)
    	=> apiClient.GetAsync<ApiResponse<List<OrderResponse>>>("orders", ct);

    public async Task<ApiResponse<OrderResponse>?> GetByIdAsync(int id)
    {
        return await apiClient.GetAsync<ApiResponse<OrderResponse>>($"orders/{id}");
    } 

    public async Task<ApiResponse<OrderResponse>?> AddAsync(AddOrderRequest request, CancellationToken ct = default)
    {
        return await apiClient.PostAsync<AddOrderRequest, ApiResponse<OrderResponse>>("orders", request, ct);
    }

   public Task<ApiResponse<OrderResponse>?> UpdateOrderStatusAndInventoryAsync(int id)
{
    return apiClient.PutAsync<object, ApiResponse<OrderResponse>>(
        $"orders/{id}",
        new { }
    );
}


    public Task<ApiResponse<OrderResponse>?> ExportOrderToPdfAndSendToEmailAsync(int id)
    => apiClient.PostAsync<object, ApiResponse<OrderResponse>>(
        $"orders/{id}/send-pdf",
        new { } 
    );
}

