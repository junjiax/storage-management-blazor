
using System.Text.Json.Serialization;

namespace frontendblazor.Models;

public sealed record InventoryRequest
{
    [JsonPropertyName("productId")]
    public int ProductId { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }
}

public sealed record InventoryLogResponse(
    int LogId,
    int InventoryId,
    int ChangeQuantity,
    string Note,
    string UpdatedAt
);


public sealed record InventoryResponse(
    [property: JsonPropertyName("inventoryId")] int InventoryId,
    [property: JsonPropertyName("productId")] int ProductId,
    [property: JsonPropertyName("productName")] string ProductName,
    [property: JsonPropertyName("quantity")] int Quantity,
    [property: JsonPropertyName("updatedAt")] DateTime UpdatedAt,
    [property: JsonPropertyName("productImg")] string? ProductImg,
    [property: JsonPropertyName("productPublicId")] string? ProductPublicId
);