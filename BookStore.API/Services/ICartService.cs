using BookStore.API.Data.Enities.Cart;
using BookStore.API.DTO.Cart;

namespace BookStore.API.Services
{
    public interface ICartService
    {
        ViewCartDTO AddCart(CartDTO cartDTO);
        ViewCartItemDTO AddCartItem(AddItemDTO addItemDTO);
        CartView GetCartId(int id);
        ViewCartItemDTO UpdateCartItem(int id, CartItemView cartItemView);
        CartItem DeleteItem(int id);
        Carts DeleteCart(int id);

    }
}