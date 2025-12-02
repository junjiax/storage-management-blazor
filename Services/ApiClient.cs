using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Components;

namespace frontendblazor.Services;

public sealed class ApiClient
{
    private readonly HttpClient httpClient;
    private readonly TokenStorage tokenStorage;
    private readonly NavigationManager navigationManager;
    private readonly ApiAuthStateProvider authStateProvider;

    public ApiClient(HttpClient httpClient, TokenStorage tokenStorage, NavigationManager navigationManager, ApiAuthStateProvider authStateProvider)
    {
        this.httpClient = httpClient;
        this.tokenStorage = tokenStorage;
        this.navigationManager = navigationManager;
        this.authStateProvider = authStateProvider;
    }

    private async Task AttachAuthAsync(HttpRequestMessage request)
    {
        var token = await tokenStorage.GetTokenAsync();
        if (!string.IsNullOrWhiteSpace(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }

    private static bool IsJwtExpired(string? token)
    {
        if (string.IsNullOrWhiteSpace(token) || token.Count(c => c == '.') != 2)
        {
            return false;
        }
        try
        {
            var parts = token.Split('.');
            var payload = parts[1];
            payload = payload.PadRight(payload.Length + ((4 - payload.Length % 4) % 4), '=');
            var json = Encoding.UTF8.GetString(Convert.FromBase64String(payload.Replace('-', '+').Replace('_', '/')));
            using var doc = JsonDocument.Parse(json);
            if (doc.RootElement.TryGetProperty("exp", out var expEl) && expEl.TryGetInt64(out var exp))
            {
                var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                return exp <= now;
            }
        }
        catch
        {
            // ignore parsing errors; treat as not expired
        }
        return false;
    }

    private async Task HandleUnauthorizedAsync()
    {
        await tokenStorage.ClearAsync();
        authStateProvider.NotifyUserLoggedOut();
        navigationManager.NavigateTo("/login");
    }

    public async Task<TResponse?> GetAsync<TResponse>(string path, CancellationToken ct = default)
    {
        using var req = new HttpRequestMessage(HttpMethod.Get, path);
        var token = await tokenStorage.GetTokenAsync();
        if (IsJwtExpired(token))
        {
            await HandleUnauthorizedAsync();
            return default;
        }
        await AttachAuthAsync(req);
        using var res = await httpClient.SendAsync(req, ct);
        if (res.StatusCode == System.Net.HttpStatusCode.Unauthorized || res.StatusCode == System.Net.HttpStatusCode.Forbidden)
        {
            await HandleUnauthorizedAsync();
            return default;
        }
        return await res.Content.ReadFromJsonAsync<TResponse>(cancellationToken: ct);
    }

    public async Task<TResponse?> PostAsync<TRequest, TResponse>(string path, TRequest body, CancellationToken ct = default)
    {
        using var req = new HttpRequestMessage(HttpMethod.Post, path)
        {
            Content = JsonContent.Create(body)
        };
        var token = await tokenStorage.GetTokenAsync();
        if (IsJwtExpired(token))
        {
            await HandleUnauthorizedAsync();
            return default;
        }
        await AttachAuthAsync(req);
        using var res = await httpClient.SendAsync(req, ct);
        if (res.StatusCode == System.Net.HttpStatusCode.Unauthorized || res.StatusCode == System.Net.HttpStatusCode.Forbidden)
        {
            await HandleUnauthorizedAsync();
            return default;
        }
        return await res.Content.ReadFromJsonAsync<TResponse>(cancellationToken: ct);
    }

     // GET BY ID
    public async Task<TResponse?> GetByIdAsync<TResponse>(string path, int id, CancellationToken ct = default)
    {
        return await GetAsync<TResponse>($"{path}/{id}", ct);
    }

    // PUT
    public async Task<TResponse?> PutAsync<TRequest, TResponse>(string path, TRequest body, CancellationToken ct = default)
    {
        using var req = new HttpRequestMessage(HttpMethod.Put, path)
        {
            Content = JsonContent.Create(body)
        };
        var token = await tokenStorage.GetTokenAsync();
        if (IsJwtExpired(token))
        {
            await HandleUnauthorizedAsync();
            return default;
        }
        await AttachAuthAsync(req);
        using var res = await httpClient.SendAsync(req, ct);
        if (res.StatusCode == System.Net.HttpStatusCode.Unauthorized || res.StatusCode == System.Net.HttpStatusCode.Forbidden)
        {
            await HandleUnauthorizedAsync();
            return default;
        }
        return await res.Content.ReadFromJsonAsync<TResponse>(cancellationToken: ct);
    }

        // DELETE
    public async Task<TResponse?> DeleteAsync<TResponse>(string path, int id, CancellationToken ct = default)
{
    using var req = new HttpRequestMessage(HttpMethod.Delete, $"{path}/{id}");

    // Lấy token
    var token = await tokenStorage.GetTokenAsync();
    if (IsJwtExpired(token))
    {
        await HandleUnauthorizedAsync();
        return default;
    }

    await AttachAuthAsync(req);

    // Gửi request
    using var res = await httpClient.SendAsync(req, ct);

    // Handle Unauthorized
    if (res.StatusCode == System.Net.HttpStatusCode.Unauthorized ||
        res.StatusCode == System.Net.HttpStatusCode.Forbidden)
    {
        await HandleUnauthorizedAsync();
        return default;
    }

    // Parse JSON từ response sang TResponse
    return await res.Content.ReadFromJsonAsync<TResponse>(cancellationToken: ct);
}
}


