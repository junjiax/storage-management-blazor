using System.Text.Json.Serialization;

namespace frontendblazor.Models;


public sealed record CategoryRequest
{
   [JsonPropertyName("categoryName")]
   public string CategoryName { get; init; }
}

public sealed record CategoryResponse{
    
    [JsonPropertyName("categoryId")]
    public int CategoryId { get; init; }
    
    [JsonPropertyName("categoryName")]
    public string CategoryName { get; init; }

}

