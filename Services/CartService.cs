using Blazored.LocalStorage;
using frontendblazor.Models;
namespace frontendblazor.Services;

public class CartService
{
   private const string CART_KEY = "shopping_cart";
   private readonly ILocalStorageService _localStorage;

   public event Action? OnChange;

   public CartService(ILocalStorageService localStorage)
   {
      _localStorage = localStorage;
   }

   // Get toàn bộ giỏ hàng
   public async Task<List<CartItem>> GetCart()
   {
      return await _localStorage.GetItemAsync<List<CartItem>>(CART_KEY)
             ?? new List<CartItem>();
   }

   // Thêm sản phẩm vào giỏ
   public async Task AddToCart(CartItem item)
   {
      var cart = await GetCart();

      var existing = cart.FirstOrDefault(x => x.ProductId == item.ProductId);

      if (existing != null)
      {
         existing.Quantity += item.Quantity;
      }
      else
      {
         cart.Add(item);
      }

      await _localStorage.SetItemAsync(CART_KEY, cart);
      OnChange?.Invoke();
   }

   // Cập nhật số lượng
   public async Task UpdateQuantity(int productId, int qty)
   {
      var cart = await GetCart();

      var item = cart.FirstOrDefault(x => x.ProductId == productId);
      if (item != null)
      {
         item.Quantity = qty;
      }

      await _localStorage.SetItemAsync(CART_KEY, cart);
      OnChange?.Invoke();
   }

   // Xóa item
   public async Task RemoveItem(int productId)
   {
      var cart = await GetCart();

      cart.RemoveAll(x => x.ProductId == productId);

      await _localStorage.SetItemAsync(CART_KEY, cart);
      OnChange?.Invoke();
   }

   // Xóa toàn bộ
   public async Task ClearCart()
   {
      await _localStorage.RemoveItemAsync(CART_KEY);
      OnChange?.Invoke();
   }
}
