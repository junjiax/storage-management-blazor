namespace frontendblazor.Components.Home;

public sealed record CategoryItemVm(int CategoryId, string CategoryName);

public sealed record ProductItemVm(
    int ProductId,          // 👈 THÊM DÒNG NÀY
    string Name,
    string ImageUrl,
    decimal Price,
    decimal? OldPrice = null,
    bool InStock = true,
    string? Badge = null
);
