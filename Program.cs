using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using frontendblazor.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using frontendblazor;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Default HttpClient for app resources
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Local Storage DI cho Cart
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<CartService>();

// Auth + API DI
// API Dependency Injection
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

// AUTH API DI
builder.Services.AddScoped<AuthApi>();

// PRODUCT API DI
builder.Services.AddScoped<ProductApi>();

// CATEGORY API DI
builder.Services.AddScoped<CategoryApi>();

// SUPPLIER API DI
builder.Services.AddScoped<SupplierApi>();

// INVENTORY API DI
builder.Services.AddScoped<InventoryApi>();

// USER API DI

// ORDER API DI
builder.Services.AddScoped<OrderApi>();


// ORDER ITEM API DI

// PROMOTION API DI
builder.Services.AddScoped<PromotionApi>();

// PAYMENT API DI
builder.Services.AddScoped<PaymentApi>();

// CUSTOMER API DI
builder.Services.AddScoped<CustomerApi>();



await builder.Build().RunAsync();