using System.Text.Json.Serialization;

namespace frontendblazor.Models;

public sealed record LoginRequest(
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("password")] string Password
);

public sealed record RegisterRequest(
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("password")] string Password,
    [property: JsonPropertyName("fullname")] string FullName
);
public sealed record AuthResponse(string Token, string Username, string FullName, string Role, int Id);
public sealed record UserInfo(string Username, string FullName, string Role, int Id);
