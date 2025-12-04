using System.Text.Json.Serialization;

namespace frontendblazor.Models;

public sealed record CreatePromotionRequest(
	[property: JsonPropertyName("promoCode")] string PromoCode,
	[property: JsonPropertyName("description")] string? Description,
	[property: JsonPropertyName("discountType")] string DiscountType,
	[property: JsonPropertyName("discountValue")] decimal DiscountValue,
	[property: JsonPropertyName("startDate")] DateTime StartDate,
	[property: JsonPropertyName("endDate")] DateTime EndDate,
	[property: JsonPropertyName("minOrderAmount")] string MinOrderAmount,
	[property: JsonPropertyName("usageLimit")] int UsageLimit,
	[property: JsonPropertyName("status")] string Status
);
public sealed record UpdatePromotionRequest(
	[property: JsonPropertyName("description")] string? Description,
	[property: JsonPropertyName("discountType")] string DiscountType,
	[property: JsonPropertyName("discountValue")] decimal DiscountValue,
	[property: JsonPropertyName("startDate")] DateTime StartDate,
	[property: JsonPropertyName("endDate")] DateTime EndDate,
	[property: JsonPropertyName("minOrderAmount")] string MinOrderAmount,
	[property: JsonPropertyName("usageLimit")] int UsageLimit,
	[property: JsonPropertyName("status")] string Status
);

public sealed record PromotionResponse(int PromoId,string PromoCode, string? Description,string DiscountType,
										decimal DiscountValue,DateTime StartDate,DateTime EndDate,int UsageLimit,
										int UsedCount,string Status);	