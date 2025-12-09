using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace frontendblazor.Models;

 public class CreateUserRequest
    {
        [Required (ErrorMessage = "Không được để trống username")]
        [JsonPropertyName("username")]
        public string Username { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        [Required (ErrorMessage = "Không được để trống password")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
        public string Password { get; set; } = string.Empty;

        [JsonPropertyName("fullName")]
        public string? FullName { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; } = "staff";
    }

    public class UpdateUserRequest
    {
        [JsonPropertyName("fullName")]
        public string? FullName { get; set; }

        [MinLengthIfNotEmpty(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự hoặc để trống")]
        [JsonPropertyName("password")]
        public string? Password { get; set; }
        [JsonPropertyName("role")]
        public string? Role { get; set; }
    }

    public class UserResponse
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; } = string.Empty;

        [JsonPropertyName("fullName")]
        public string? FullName { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; } = string.Empty;

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
    }

    // Custom attribute
public class MinLengthIfNotEmptyAttribute : ValidationAttribute
{
    private readonly int _minLength;

    public MinLengthIfNotEmptyAttribute(int minLength)
    {
        _minLength = minLength;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var str = value as string;
        if (string.IsNullOrEmpty(str))
        {
            return ValidationResult.Success; // rỗng => hợp lệ
        }

        return str.Length >= _minLength 
            ? ValidationResult.Success 
            : new ValidationResult(ErrorMessage);
    }
}