using System.Text.Json.Serialization;

namespace frontendblazor.Models;

public sealed record CategoryRequest(
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("password")] string Password
);

public sealed record CategoryResponse(string Token, string Username, string FullName, string Role, int Id);

