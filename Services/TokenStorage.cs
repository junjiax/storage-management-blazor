using Microsoft.JSInterop;

namespace frontendblazor.Services;

public sealed class TokenStorage
{
    private readonly IJSRuntime jsRuntime;
    private const string TokenKey = "token";
    private const string UserInfoKey = "userInfo";
    public TokenStorage(IJSRuntime jsRuntime)
    {
        this.jsRuntime = jsRuntime;
    }

    public ValueTask SetTokenAsync(string token)
        => jsRuntime.InvokeVoidAsync("localStorage.setItem", TokenKey, token);

    public ValueTask SetUserInfoAsync(object userInfo)
        => jsRuntime.InvokeVoidAsync("localStorage.setItem", UserInfoKey, userInfo);
    public async Task<string?> GetTokenAsync()
        => await jsRuntime.InvokeAsync<string?>("localStorage.getItem", TokenKey);

    public ValueTask ClearAsync()
        => jsRuntime.InvokeVoidAsync("localStorage.removeItem", TokenKey);
}


