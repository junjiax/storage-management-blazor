using frontendblazor.Models;

namespace frontendblazor.Services;

public sealed class PromotionApi
{
    private readonly ApiClient apiClient;

    public PromotionApi(ApiClient apiClient)
    {
        this.apiClient = apiClient;
    }

    public Task<ApiResponse<PromotionResponse>?> AddAsync(CreatePromotionRequest request, CancellationToken ct = default)
        => apiClient.PostAsync<CreatePromotionRequest, ApiResponse<PromotionResponse>>("promotion", request, ct);

    public Task<ApiResponse<PromotionResponse>?> UpdateAsync(UpdatePromotionRequest request,int id ,CancellationToken ct = default)
        => apiClient.PutAsync<UpdatePromotionRequest, ApiResponse<PromotionResponse>>($"promotion/{id}", request, ct);
	
    public Task<ApiResponse<PromotionResponse>?> GetAllAsync(CancellationToken ct = default)
	=> apiClient.GetAsync<ApiResponse<PromotionResponse>>("promotion", ct);
	
    public Task<ApiResponse<PromotionResponse>?> GetByIdAsync(int id, CancellationToken ct = default)
	=> apiClient.GetByIdAsync<ApiResponse<PromotionResponse>>("promotion", id, ct);
	
    public Task<ApiResponse<bool>?> DeleteAsync(int id, CancellationToken ct = default)
    => apiClient.DeleteAsync<ApiResponse<bool>>("promotion", id, ct);
}
