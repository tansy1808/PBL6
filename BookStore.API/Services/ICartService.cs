using BookStore.API.Data.Enities.Cart;
using BookStore.API.DTO.Cart;

namespace BookStore.API.Services
{
    public interface ICartService
    {
        Carts AddCart(CartDTO cartDTO);
        CartItem AddCartItem(CartItemDTO cartItemDTO);
        CartView GetCartId(int id);
        
        CartItem DeleteItem(int id);
        Carts DeleteCart(int id);

    }
}