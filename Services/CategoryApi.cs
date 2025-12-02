using frontendblazor.Models;

namespace frontendblazor.Services;

public sealed class CategoryApi
{
    private readonly ApiClient apiClient;

    public CategoryApi(ApiClient apiClient)
    {
        this.apiClient = apiClient;
    }

    public Task<ApiResponse<AuthResponse>?> AddAsync(LoginRequest request, CancellationToken ct = default)
        => apiClient.PostAsync<LoginRequest, ApiResponse<AuthResponse>>("auth/login", request, ct);

    public Task<ApiResponse<AuthResponse>?> UpdateAsync(LoginRequest request, CancellationToken ct = default)
        => apiClient.PostAsync<LoginRequest, ApiResponse<AuthResponse>>("auth/login", request, ct);

    public Task<ApiResponse<AuthResponse>?> DeleteAsync(LoginRequest request, CancellationToken ct = default)
        => apiClient.PostAsync<LoginRequest, ApiResponse<AuthResponse>>("auth/login", request, ct);

    public Task<ApiResponse<AuthResponse>?> GetListAsync(LoginRequest request, CancellationToken ct = default)
        => apiClient.PostAsync<LoginRequest, ApiResponse<AuthResponse>>("auth/login", request, ct);

    public Task<ApiResponse<AuthResponse>?> GetByIdAsync(RegisterRequest request, CancellationToken ct = default)
        => apiClient.PostAsync<RegisterRequest, ApiResponse<AuthResponse>>("auth/register", request, ct);
}


