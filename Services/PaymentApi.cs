using frontendblazor.Models;

namespace frontendblazor.Services;


public sealed class PaymentApi
{
   private readonly ApiClient apiClient;

   public PaymentApi(ApiClient apiClient)
   {
      this.apiClient = apiClient;
   }
   public Task<ApiResponse<PaymentUrlData>?> CreateVnPayAsync(PaymentInformationDto request, CancellationToken ct = default)
        => apiClient.PostAsync<PaymentInformationDto, ApiResponse<PaymentUrlData>>("payment/create-vnpay", request, ct);

   //public Task<ApiResponse<AuthResponse>?> LoginAsync(LoginRequest request, CancellationToken ct = default)
   //    => apiClient.PostAsync<LoginRequest, ApiResponse<AuthResponse>>("auth/login", request, ct);

   //public Task<ApiResponse<AuthResponse>?> RegisterAsync(RegisterRequest request, CancellationToken ct = default)
   //    => apiClient.PostAsync<RegisterRequest, ApiResponse<AuthResponse>>("auth/register", request, ct);
}