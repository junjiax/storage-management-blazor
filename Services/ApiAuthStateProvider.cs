using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace frontendblazor.Services;

public sealed class ApiAuthStateProvider : AuthenticationStateProvider
{
    private readonly TokenStorage tokenStorage;

    public ApiAuthStateProvider(TokenStorage tokenStorage)
    {
        this.tokenStorage = tokenStorage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await tokenStorage.GetTokenAsync();
        if (!string.IsNullOrWhiteSpace(token))
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "user"),
            }, "jwt");
            return new AuthenticationState(new ClaimsPrincipal(identity));
        }
        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }

    public void NotifyUserAuthenticated()
    {
        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "user") }, "jwt");
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
    }

    public void NotifyUserLoggedOut()
    {
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()))));
    }
}


