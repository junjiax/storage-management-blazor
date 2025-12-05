using System.Text.Json.Serialization;

namespace frontendblazor.Models;

public sealed record CategoryResponse(
    int CategoryId,
    string CategoryName
);
