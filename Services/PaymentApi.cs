using frontendblazor.Models;

namespace frontendblazor.Services;

public sealed class PaymentApi
{
    private readonly ApiClient apiClient;

    public PaymentApi(ApiClient apiClient)
    {
        this.apiClient = apiClient;
    }

    public Task<ApiResponse<VnPayUrlResponse>?> CreateVnPayPaymentUrlAsync(
        PaymentInformationDto request,
        CancellationToken ct = default
    )
    {
        return apiClient.PostAsync<PaymentInformationDto, ApiResponse<VnPayUrlResponse>>(
            "payment/create-vnpay",
            request,
            ct
        );
    }

}
