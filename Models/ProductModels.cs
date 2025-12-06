using System.Text.Json.Serialization;

namespace frontendblazor.Models;

public sealed record ProductRequest(
    [property: JsonPropertyName("categoryId")] string CategoryId,
    [property: JsonPropertyName("supplierId")] string SupplierId,
    [property: JsonPropertyName("productName")] string ProductName,
    [property: JsonPropertyName("barcode")] string Barcode,
    [property: JsonPropertyName("price")] string Price,
    [property: JsonPropertyName("unit")] string Unit
);

public sealed record ProductResponse
{
    [JsonPropertyName("productId")]
    public int ProductId { get; init; }

    [JsonPropertyName("categoryId")]
    public int CategoryId { get; init; }

    [JsonPropertyName("categoryName")]
    public string CategoryName { get; init; }

    [JsonPropertyName("supplierId")]
    public int SupplierId { get; init; }

    [JsonPropertyName("supplierName")]
    public string SupplierName { get; init; }

    [JsonPropertyName("productName")]
    public string ProductName { get; init; }

    [JsonPropertyName("barcode")]
    public string Barcode { get; init; }

    [JsonPropertyName("price")]
    public decimal Price { get; init; }

    [JsonPropertyName("unit")]
    public string Unit { get; init; }

    [JsonPropertyName("productImg")]
    public string ProductImg { get; init; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; init; }

};
