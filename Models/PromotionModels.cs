using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace frontendblazor.Models;

public class CreatePromotionRequest
    {
        [JsonPropertyName("promoCode")]
        [Required(ErrorMessage = "Mã khuyến mãi là bắt buộc")]
        public string PromoCode { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("discountType")]
        [Required(ErrorMessage = "Loại giảm giá là bắt buộc")]
        public string DiscountType { get; set; } = string.Empty;

        [JsonPropertyName("discountValue")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá trị giảm phải lớn hơn 0")]
        public decimal DiscountValue { get; set; }

        [JsonPropertyName("startDate")]
        [Required(ErrorMessage = "Ngày bắt đầu là bắt buộc")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("endDate")]
        [Required(ErrorMessage = "Ngày kết thúc là bắt buộc")]
        public DateTime EndDate { get; set; }

        [JsonPropertyName("minOrderAmount")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá trị đơn tối thiểu phải >= 0")]
        public decimal MinOrderAmount { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Giá trị đơn tối thiểu phải >= 0")]
        [JsonPropertyName("usageLimit")]
        public int UsageLimit { get; set; }
        
        [JsonPropertyName("status")]
        [Required(ErrorMessage = "Trạng thái là bắt buộc")]
        public string Status { get; set; } = "active";
    }

public class UpdatePromotionRequest
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("discountValue")]
        [Required(ErrorMessage = "Giá trị giảm là bắt buộc")]
        public decimal? DiscountValue { get; set; }

        [JsonPropertyName("discountType")]
        [Required(ErrorMessage = "Loại giảm giá là bắt buộc")]
        public string? DiscountType { get; set; }

        [JsonPropertyName("startDate")]
        [Required(ErrorMessage = "Ngày bắt đầu là bắt buộc")]
        public DateTime? StartDate { get; set; }

        [JsonPropertyName("endDate")]
        [Required(ErrorMessage = "Ngày kết thúc là bắt buộc")]
        public DateTime? EndDate { get; set; }

        [JsonPropertyName("minOrderAmount")]
        public decimal? MinOrderAmount { get; set; }

        [JsonPropertyName("usageLimit")]
        public int? UsageLimit { get; set; }

        [JsonPropertyName("status")]
        [Required(ErrorMessage = "Trạng thái là bắt buộc")]
        public string? Status { get; set; }
    }


public sealed record PromotionResponse(int PromoId,string PromoCode, string? Description,string DiscountType,
										decimal DiscountValue,DateTime StartDate,DateTime EndDate,int UsageLimit, decimal MinOrderAmount,
										int UsedCount,string Status);