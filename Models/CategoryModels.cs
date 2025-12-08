using System.Text.Json.Serialization;

namespace frontendblazor.Models;

public sealed record CategoryResponse(
    int CategoryId,
    string CategoryName
);
<<<<<<< HEAD

public sealed record CategoryResponse{
    
    [JsonPropertyName("categoryId")]
    public int CategoryId { get; init; }
    
    [JsonPropertyName("categoryName")]
    public string CategoryName { get; init; }

}

=======
>>>>>>> origin/ten
