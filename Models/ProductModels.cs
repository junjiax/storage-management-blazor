
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
    [property: JsonPropertyName("productId")] int ProductId,
    [property: JsonPropertyName("categoryId")] int? CategoryId,
    [property: JsonPropertyName("categoryName")] string? CategoryName,
    [property: JsonPropertyName("supplierId")] int? SupplierId,
    [property: JsonPropertyName("supplierName")] string? SupplierName,
    [property: JsonPropertyName("productName")] string ProductName,
    [property: JsonPropertyName("barcode")] string? Barcode,
    [property: JsonPropertyName("price")] decimal Price,
    [property: JsonPropertyName("unit")] string Unit,
    [property: JsonPropertyName("productImg")] string? ProductImg,
    [property: JsonPropertyName("createdAt")] DateTime CreatedAt,
    [property: JsonPropertyName("currentStock")] int? CurrentStock
);


