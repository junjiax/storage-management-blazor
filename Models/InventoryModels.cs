
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace frontendblazor.Models;

public sealed record InventoryRequest
{
    [JsonPropertyName("productId")]
    public int ProductId { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }
}

public class InventoryLogDto
{
    [JsonPropertyName("type")]
    public string Type { get; set; }              // "nhập hàng" | "bán hàng"

    [JsonPropertyName("date")]
    public string Date { get; set; }              // dd/MM/yyyy

    [JsonPropertyName("quantity")]
    public int? Quantity { get; set; }          // "+num" hoặc "num"

    [JsonPropertyName("orderId")]
    public int? OrderId { get; set; }

    [JsonPropertyName("quantitySold")]
    public int? QuantitySold { get; set; }

    [JsonPropertyName("stockRemaining")]
    public int? StockRemaining { get; set; }
}

public sealed record InventoryResponse(
    [property: JsonPropertyName("inventoryId")] int InventoryId,
    [property: JsonPropertyName("productId")] int ProductId,
    [property: JsonPropertyName("productName")] string ProductName,
    [property: JsonPropertyName("quantity")] int Quantity,
    [property: JsonPropertyName("updatedAt")] DateTime UpdatedAt,
    [property: JsonPropertyName("productImg")] string? ProductImg,
    [property: JsonPropertyName("productPublicId")] string? ProductPublicId
);
