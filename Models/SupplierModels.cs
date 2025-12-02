using System.Text.Json.Serialization;

namespace frontendblazor.Models;
public sealed record SupplierRequest(
	[property: JsonPropertyName("name")] string Name,
	[property: JsonPropertyName("phone")] string? Phone,
	[property: JsonPropertyName("email")] string? Email,
	[property: JsonPropertyName("address")] string? Address
);

public sealed record SupplierResponse(int SupplierId, string Name,string? Phone, string? Email,string? Address);