using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace frontendblazor.Models;

using Microsoft.AspNetCore.Http;

public record ProductRequest
{
    [JsonPropertyName("categoryId")]
    [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn danh mục.")]
    public int CategoryId { get; set; }

    [JsonPropertyName("supplierId")]
    [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn nhà cung cấp.")]
    public int SupplierId { get; set; }

    [JsonPropertyName("productName")]
    [Required, MinLength(2)]
    public string ProductName { get; set; } = string.Empty;

    [JsonPropertyName("barcode")]
    [Required]
    public string Barcode { get; set; } = string.Empty;

    [JsonPropertyName("price")]
    [Range(1, double.MaxValue)]
    public decimal Price { get; set; }

    [JsonPropertyName("unit")]
    [Required]
    public string Unit { get; set; } = string.Empty;

    [JsonPropertyName("productImg")]
    public string ProductImg { get; set; } = string.Empty;
}

public record ProductResponse
{
    [JsonPropertyName("productId")]
    public int? ProductId { get; init; }

    [JsonPropertyName("categoryId")]
    public int? CategoryId { get; init; }

    [JsonPropertyName("categoryName")]
    public string? CategoryName { get; init; }

    [JsonPropertyName("supplierId")]
    public int? SupplierId { get; init; }

    [JsonPropertyName("supplierName")]
    public string? SupplierName { get; init; }

    [JsonPropertyName("productName")]
    public string ProductName { get; init; }

    [JsonPropertyName("barcode")]
    public string? Barcode { get; init; }

    [JsonPropertyName("price")]
    public decimal Price { get; init; }

    [JsonPropertyName("unit")]
    public string Unit { get; init; }

    [JsonPropertyName("productImg")]
    public string? ProductImg { get; init; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; init; }

    [JsonPropertyName("currentStock")]
    public int? CurrentStock { get; init; }

    [JsonPropertyName("productPublicId")]
    public string? ProductPublicId { get; init; }
}



