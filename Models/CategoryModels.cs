using System.Text.Json.Serialization;

namespace frontendblazor.Models;

public sealed class CategoryRequest(
    [property: JsonPropertyName("categoryName")] string CategoryName
);

public sealed class CategoryResponse{
    
    [JsonPropertyName("categoryId")]
    public int CategoryId { get; init; }
    
    [JsonPropertyName("categoryName")]
    public string CategoryName { get; init; }

}

