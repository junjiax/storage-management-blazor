using System.Text.Json.Serialization;

namespace frontendblazor.Models;
public sealed record AddPaymentRequest(
    [property: JsonPropertyName("order_id")] int OrderId,
    [property: JsonPropertyName("amount")] decimal Amount,
    [property: JsonPropertyName("payment_method")] string PaymentMethod
);

public sealed record OrderPaymentResponse(
    int PaymentId,
    decimal Amount,
    string PaymentMethod,
    DateTime PaymentDate
);

public sealed record VnPayUrlResponse(
    [property: JsonPropertyName("paymentUrl")] string PaymentUrl
);

public sealed record PaymentInformationDto(
    [property: JsonPropertyName("orderId")] int OrderId,
    [property: JsonPropertyName("orderType")] string OrderType,
    [property: JsonPropertyName("amount")] double Amount,
    [property: JsonPropertyName("orderDescription")] string OrderDescription,
    [property: JsonPropertyName("name")] string Name
);
