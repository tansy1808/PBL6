using BookStore.API.Data.Enities.Cart;
using BookStore.API.DTOs.Views;

namespace BookStore.API.Services.IServices
{
    public interface ICartService
    {
        void InsertCart(Carts carts);
        void InsertCartItem(CartItem cartitem);
        void UpdateCart(Carts carts);
        void DeleteCart(Carts carts);
        void DeleteItem(CartItem cartitem);
        List<CartItem> getCartItem(int id);
        Carts GetCarts(int id);
        CartViewDTOs GetCartsId(int id);
        CartItem GetCartItemId(int id);
        bool IsSaveChanges();
    }
}