using System.Text.Json.Serialization;

namespace frontendblazor.Models;

public sealed record CategoryRequest(
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("password")] string Password
);

public sealed record CategoryResponse{
    
    [JsonPropertyName("categoryId")]
    public int CategoryId { get; init; }
    
    [JsonPropertyName("categoryName")]
    public string CategoryName { get; init; }

}

