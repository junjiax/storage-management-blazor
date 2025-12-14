using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace frontendblazor.Models;

public sealed record CustomerRequest
{
   [Required(ErrorMessage = "Tên khách hàng là bắt buộc")]
   [JsonPropertyName("name")]
   public string Name { get; set; } = string.Empty;

   [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
   [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
   [JsonPropertyName("phone")]
   public string Phone { get; set; } = string.Empty;

   // [EmailAddress(ErrorMessage = "Email không hợp lệ")]
   [RegularExpression(@"^$|^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email không hợp lệ")]
   [JsonPropertyName("email")]
   public string Email { get; set; } = string.Empty;

   [JsonPropertyName("address")]
   public string Address { get; set; } = string.Empty;
}

public class CustomerInfo
{
   public string Name { get; set; } = "";
   public string Phone { get; set; } = "";
   public string Email { get; set; } = "";
   public string Address { get; set; } = "";
}

public sealed record CustomerResponse(
   int CustomerId,
   string Name,
   string Phone,
   string Email,
   string Address,
   DateTime CreatedAt
);

// public sealed record CustomerRequest(
//    string Name,
//    string Phone,
//    string Email,
//    string Address
// );

