using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace frontendblazor.Models;

public sealed record SupplierRequest
{
    [JsonPropertyName("name")]
    [Required(ErrorMessage = "Tên nhà cung cấp không được để trống")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("phone")]
    [RegularExpression(@"^\+?\d{9,15}$", ErrorMessage = "Số điện thoại không hợp lệ")]
    public string? Phone { get; set; }

    [JsonPropertyName("email")]
    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email không hợp lệ")]
    public string? Email { get; set; }

    [JsonPropertyName("address")]
    public string? Address { get; set; }
}
public sealed record SupplierResponse(int SupplierId, string Name,string? Phone, string? Email,string? Address);
