using System.Text.Json.Serialization;

namespace frontendblazor.Models;

public sealed record AddOrderRequest(
    [property: JsonPropertyName("customerId")] int CustomerId,
    [property: JsonPropertyName("userId")] int UserId,
    [property: JsonPropertyName("promoId")] int PromoId,
    [property: JsonPropertyName("items")] OrderItemRequest item
);

public sealed record OrderItemRequest
(
    [property: JsonPropertyName("productId")] int ProductId,
    
    [property: JsonPropertyName("quantity")] int Quantity
);

public sealed record OrderResponse(
    int OrderId,
    int? CustomerId,
    string? CustomerName,
    int? UserId,
    string? UserName,
    int? PromoId,
    string? PromoCode,
    DateTime OrderDate,
    string Status,
    decimal TotalAmount,
    decimal DiscountAmount,
    List<OrderItemResponse> Items,
    OrderPaymentResponse Payment
);

public sealed record OrderItemResponse(
    int OrderItemId,
    int ProductId,
    string ProductName,
    int Quantity,
    decimal Price,
    decimal Subtotal
);






