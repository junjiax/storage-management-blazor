using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using frontendblazor.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using frontendblazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Default HttpClient for app resources
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


// Auth + API DI
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<TokenStorage>();
builder.Services.AddScoped<ApiAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<ApiAuthStateProvider>());
builder.Services.AddScoped<ApiClient>(sp =>
{
    var backendBase = builder.Configuration["BackendBaseUrl"] ?? "http://localhost:5247/api/";
    var http = new HttpClient { BaseAddress = new Uri(backendBase) };
    return new ApiClient(
        http,
        sp.GetRequiredService<TokenStorage>(),
        sp.GetRequiredService<NavigationManager>(),
        sp.GetRequiredService<ApiAuthStateProvider>()
    );
});
builder.Services.AddScoped<AuthApi>();

// PRODUCT API DI

// CATEGORY API DI

// SUPPLIER API DI

// INVENTORY API DI

// USER API DI

// ORDER API DI

// ORDER ITEM API DI

// PROMOTION API DI

// PAYMENT API DI

// CUSTOMER API DI


await builder.Build().RunAsync();