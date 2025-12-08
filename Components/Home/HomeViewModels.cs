namespace frontendblazor.Components.Home;

public sealed record CategoryItemVm(int CategoryId, string CategoryName);

public sealed record ProductItemVm(
    string Name,
    string ImageUrl,
    decimal Price,
    decimal? OldPrice = null,
    bool InStock = true,
    string? Badge = null
);


