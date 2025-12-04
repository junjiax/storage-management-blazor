
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

public sealed record ProductResponse(
    int ProductId,
    string CategoryId,
    string SupplierId,
    string ProductName,
    string Barcode,
    string Unit
);

