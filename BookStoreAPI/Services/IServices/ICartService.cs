using BookStoreAPI.DATA.Enities.Cart;
using BookStoreAPI.DTO.Cart;

namespace BookStoreAPI.Services.IServices
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