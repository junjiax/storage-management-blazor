using System.Text.Json.Serialization;

namespace frontendblazor.Models;

public record CategoryRequest
{
    [JsonPropertyName("categoryName")]
    public string CategoryName { get; set; } = string.Empty;
}

public record UpdateCategoryRequest
{
    [JsonPropertyName("categoryName")]
    public string CategoryName { get; set; } = string.Empty;
}


public record CategoryResponse
{

    [JsonPropertyName("categoryId")]
    public int CategoryId { get; init; }

    [JsonPropertyName("categoryName")]
    public string CategoryName { get; init; }

}

