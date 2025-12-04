using System.Text.Json.Serialization;

namespace frontendblazor.Models;

public sealed record InventoryRequest(
    [property: JsonPropertyName("productId")] string ProductId,
    [property: JsonPropertyName("quantity")] string Quantity
);

public sealed record InventoryResponse
{
    [JsonPropertyName("inventoryId")]
    public int InventoryId { get; init; }

    [JsonPropertyName("productId")]
    public int ProductId { get; init; }

    [JsonPropertyName("productName")]
    public string ProductName { get; init; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; init; }

    [JsonPropertyName("updatedAt")]
    public DateTime UpdatedAt { get; init; }
}


