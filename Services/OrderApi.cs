using System.Net;
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

    public Task<ApiResponse<List<OrderResponse>>?> SearchAsync(
        string? keyword = null,
        string? status = null,
        DateTime? fromDate = null,
        DateTime? toDate = null,
        string sortOrder = "desc",
        CancellationToken ct = default
    )
    {
        var query = new List<string>();

        if (!string.IsNullOrWhiteSpace(keyword))
            query.Add($"keyword={WebUtility.UrlEncode(keyword)}");

        if (!string.IsNullOrWhiteSpace(status))
            query.Add($"status={status}");

        if (fromDate.HasValue)
            query.Add($"fromDate={fromDate.Value:yyyy-MM-dd}");

        if (toDate.HasValue)
            query.Add($"toDate={toDate.Value:yyyy-MM-dd}");

        query.Add($"sortOrder={sortOrder}");

        var url = "orders/search";

        if (query.Any())
            url += "?" + string.Join("&", query);

        return apiClient.GetAsync<ApiResponse<List<OrderResponse>>>(url, ct);
    }

    public Task<ApiResponse<List<OrderResponse>>?> GetByCustomerIdAsync(
        int customerId,
        CancellationToken ct = default
    )
        => apiClient.GetAsync<ApiResponse<List<OrderResponse>>>(
            $"orders/customer/{customerId}",
            ct
        );
}

