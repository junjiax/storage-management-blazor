using frontendblazor.Models;

namespace frontendblazor.Services;

public sealed class OrderApi
{
   private readonly ApiClient apiClient;

   public OrderApi(ApiClient apiClient)
   {
      this.apiClient = apiClient;
   }

   public Task<ApiResponse<OrderResponse>?> AddAsync(CreateOrderRequest request, CancellationToken ct = default)
       => apiClient.PostAsync<CreateOrderRequest, ApiResponse<OrderResponse>>("orders", request, ct);
   public Task<ApiResponse<OrderResponse>?> GetByIdAsync(string id, CancellationToken ct = default)
       => apiClient.GetAsync<ApiResponse<OrderResponse>>($"orders/{id}", ct);
   //public Task<ApiResponse<CustomerResponse>?> UpdateAsync(CustomerRequest request, int id, CancellationToken ct = default)
   //    => apiClient.PutAsync<CustomerRequest, ApiResponse<CustomerResponse>>($"customer/{id}", request, ct);

}
