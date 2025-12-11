
namespace frontendblazor.Models;

public class CreateOrderRequest
{
   public int? CustomerId { get; set; }

   public int? UserId { get; set; }

   public int? PromoId { get; set; }

   public List<OrderItemRequest> Items { get; set; } = new();
}
public class OrderItemRequest
{
   public int ProductId { get; set; }

   public int Quantity { get; set; }
}

public class OrderResponse
{
   public int OrderId { get; set; }

   public int? CustomerId { get; set; }

   public string? CustomerName { get; set; }

   public int? UserId { get; set; }

   public string? UserName { get; set; }

   public int? PromoId { get; set; }

   public string? PromoCode { get; set; }

   public DateTime OrderDate { get; set; }

   public string Status { get; set; } = string.Empty;

   public decimal TotalAmount { get; set; }

   public decimal DiscountAmount { get; set; }

   public List<OrderItemResponse> Items { get; set; } = new();

   public OrderPaymentResponse? Payment { get; set; }
}

public class OrderItemResponse
{
   public int OrderItemId { get; set; }

   public int ProductId { get; set; }

   public string ProductName { get; set; } = string.Empty;

   public int Quantity { get; set; }

   public decimal Price { get; set; }

   public decimal Subtotal { get; set; }
}

public class OrderPaymentResponse
{
   public int PaymentId { get; set; }

   public decimal Amount { get; set; }

   public string? PaymentMethod { get; set; }

   public DateTime PaymentDate { get; set; }
}