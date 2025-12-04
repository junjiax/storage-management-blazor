
using System.Text.Json.Serialization;

namespace frontendblazor.Models;

public sealed record InventoryRequest(
    [property: JsonPropertyName("productId")] string ProductId,
    [property: JsonPropertyName("quantity")] string Quantity
);

public sealed record InventoryResponse(
    int InventoryId,
    int ProductId,
    string ProductName,
    int Quantity,
    DateTime UpdatedAt
);
