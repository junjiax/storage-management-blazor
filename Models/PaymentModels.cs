using System.Text.Json.Serialization;

namespace frontendblazor.Models;

public class PaymentInformationDto
{
   public int OrderId { get; set; } // Quan trọng: Phải có ID đơn hàng
   public string OrderType { get; set; } = "other";
   public double Amount { get; set; }
   public string OrderDescription { get; set; } = string.Empty;
   public string Name { get; set; } = string.Empty;

 }

// DTO 2: Hứng kết quả từ API create-vnpay
public class BackendResponse
{
   public PaymentUrlData Data { get; set; }
   public bool Success { get; set; }
}

public class PaymentUrlData
{
   public string PaymentUrl { get; set; }
}

// DTO 3: Dữ liệu để tạo đơn hàng mới (Gửi đi để lấy OrderId)
// Bạn cần điều chỉnh class này cho khớp với API "Tạo đơn hàng" của bạn
public class CreateOrderDto
{
   public CustomerInfo Customer { get; set; }
   public List<CartItem> Items { get; set; }
   public decimal TotalAmount { get; set; }
   public string PaymentMethod { get; set; }
}

// DTO 4: Hứng kết quả tạo đơn hàng (Chứa OrderId)
public class CreateOrderResponse
{
   public int OrderId { get; set; }
   // ... các field khác
}