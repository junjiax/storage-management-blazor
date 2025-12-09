using System.Text.Json.Serialization;

namespace frontendblazor.Models;

public class CategoryRequest
{
    [JsonPropertyName("categoryName")]
    public string CategoryName { get; set; } = string.Empty;
}

public class UpdateCategoryRequest
{
    [JsonPropertyName("categoryName")]
    public string CategoryName { get; set; } = string.Empty;
}


public class CategoryResponse
{

    [JsonPropertyName("categoryId")]
    public int CategoryId { get; init; }

    [JsonPropertyName("categoryName")]
    public string CategoryName { get; init; }

}

