﻿using frontendblazor.Models;

namespace frontendblazor.Services;

public sealed class UserApi
{
    private readonly ApiClient apiClient;

    public UserApi(ApiClient apiClient)
    {
        this.apiClient = apiClient;
    }

    public Task<ApiResponse<UserResponse>?> AddAsync(CreateUserRequest request, CancellationToken ct = default)
        => apiClient.PostAsync<CreateUserRequest, ApiResponse<UserResponse>>("users", request, ct);

    public Task<ApiResponse<UserResponse>?> UpdateAsync(UpdateUserRequest request,int id ,CancellationToken ct = default)
        => apiClient.PutAsync<UpdateUserRequest, ApiResponse<UserResponse>>($"users/{id}", request, ct);
	
    public Task<ApiResponse<List<UserResponse>>?> GetAllAsync(CancellationToken ct = default)
    	=> apiClient.GetAsync<ApiResponse<List<UserResponse>>>("users", ct);
	
    public Task<ApiResponse<UserResponse>?> GetByIdAsync(int id, CancellationToken ct = default)
    	=> apiClient.GetByIdAsync<ApiResponse<UserResponse>>("users", id, ct);
	
    public Task<ApiResponse<bool>?> DeleteAsync(int id, CancellationToken ct = default)
        => apiClient.DeleteAsync<ApiResponse<bool>>("users", id, ct);
}

